using Library.Domain.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private IAccountTypeDao _accountType;

        public AccountTypeController(IAccountTypeDao accountTypeDao)
        {
            _accountType = accountTypeDao;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var accountTypes = _accountType.GetAll();
                return Ok(accountTypes);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var accountTypes = _accountType.Get(id);
                return Ok(accountTypes);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}