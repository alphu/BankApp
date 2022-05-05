using BMS.Application.Interfaces;
using BMS.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {

            _tokenService = tokenService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Request usersdata)
        {
            var token = _tokenService.AuthenticateToken(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
      
    }
}
