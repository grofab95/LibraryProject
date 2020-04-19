using AutoMapper;
using Library.Api.UsersDto;
using Library.Configs;
using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using Library.MsSqlPersistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserDao _userDao;
        private IMapper _mapper;
        private LibraryContext _dataContext;
        private string _secret;

        public UsersController(
            IUserDao userDao,
            IMapper mapper,
            LibraryContext dataContext)
        {
            _userDao = userDao;
            _mapper = mapper;
            _dataContext = dataContext;
            _secret = Config.Get().TokenSecret;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserWithToken>> Login([FromBody]UserAuthenticateDto userAuthenticateDto)
        {
            try
            {
                var user = _userDao.Authenticate(userAuthenticateDto.Email, userAuthenticateDto.Password);

                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens.Add(refreshToken);
                await _dataContext.SaveChangesAsync();

                var userWithToken = new UserWithToken(user);
                userWithToken.RefreshToken = refreshToken.Token;
                userWithToken.AccessToken = GenerateAccessToken(user.UserId);
                userWithToken.AccountType.Users = null;

                return Ok(_mapper.Map<UserWithTokenDto>(userWithToken));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserCreateDto userCreateDto)
        {
            try
            {
                _userDao.Register(_mapper.Map<User>(userCreateDto), userCreateDto.Password);
                return Ok();
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Ok(_mapper.Map<IList<UserDto>>(_userDao.GetAll()));
            return Ok(_mapper.Map<IList<UserDto>>(_userDao.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_mapper.Map<UserDto>(_userDao.GetById(id)));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            user.UserId = id;
            try
            {
                _userDao.Update(user, userUpdateDto.Password);
                return Ok();
            }
            catch (LibraryException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userDao.Delete(id);
            return Ok();
        }

        [HttpPost("token/refresh")]
        public async Task<ActionResult<User>> RefreshToken([FromBody] RefreshRequest refreshRequest)
        {
            User user = await GetUserFromAccessToken(refreshRequest.AccessToken);

            if (user != null && ValidateRefreshToken(user, refreshRequest.RefreshToken))
            {
                UserWithToken userWithToken = new UserWithToken(user);
                userWithToken.AccessToken = GenerateAccessToken(user.UserId);
                return user;
            }

            return null;
        }

        [AllowAnonymous]
        [HttpPost("token/getUser")]
        public async Task<ActionResult<User>> GetUserByAccessToken([FromBody] string accessToken)
        {
            var user = await GetUserFromAccessToken(accessToken);

            user.AccountType.Users = null;

            if (user != null)
            {
                return user;
            }

            return null;
        }

        private bool ValidateRefreshToken(User user, string refreshToken)
        {
            RefreshToken refreshTokenUser = _dataContext.RefreshTokens.Where(rt => rt.Token == refreshToken)
                                                .OrderByDescending(rt => rt.ExpiryDate)
                                                .FirstOrDefault();

            if (refreshTokenUser != null && refreshTokenUser.UserId == user.UserId
                && refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }

        private async Task<User> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                var jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.Name)?.Value;
                    return await _dataContext.Users.Include(x => x.AccountType).Where(u => u.UserId == Convert.ToInt32(userId)).FirstOrDefaultAsync();
                }
            }
            catch (Exception)
            {
                return new User();
            }

            return new User();
        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);

            return refreshToken;
        }

        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(userId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
