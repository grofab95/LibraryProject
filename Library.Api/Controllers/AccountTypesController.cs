using AutoMapper;
using Library.Api.AccountsTypesDto;
using Library.Domain.Adapters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypesController : ControllerBase
    {
        private IAccountTypeDao _accountType;
        private IMapper _mapper;

        public AccountTypesController(IAccountTypeDao accountTypeDao, IMapper mapper)
        {
            _accountType = accountTypeDao;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_mapper.Map<IList<AccountTypeDto>>(_accountType.GetAll()));
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }
    }
}