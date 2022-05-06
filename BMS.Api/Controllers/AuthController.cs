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
        [HttpPost, Route("refresh")]
        public IActionResult Refresh(Response tokens)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(tokens.Access_Token);
            Request user = new Request();
            user.Username = principal.Identity?.Name;
            var token = _tokenService.GenerateRefreshToken(user);
            return Ok(token);
        }

    }
}
