using BMS.Application.Models;
using BMS.Domain.Entities;
using BMS.Infra.Repository.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepositroy _registerRepository;
        public RegisterController(IRegisterRepositroy registerRepository)
        {
            _registerRepository = registerRepository;
        }
        [HttpGet, Route("getAccountlist")]
        public IActionResult GetAccountDetails()
        {
            return Ok(_registerRepository.GetListofAccounts());
        }
        [AllowAnonymous]
        [HttpPost, Route("createaccount")]
        public IActionResult CreateAccount([FromBody] Customer customer)
        {
            try
            {
                var result = _registerRepository.CreateAccount(customer);
                return Ok("Successfully Created !!!");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet,Route("getAccount/{accountNo}")]
        public IActionResult GetAccount(int accountNo)
        {
            try
            {
                var result = _registerRepository.GetAccount(accountNo);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
