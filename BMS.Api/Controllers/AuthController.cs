using BMS.Application.Models;
using BMS.Infra.Repository.Authentication;
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
        private readonly ITokenRepository _tokenRespository;

        public AuthController(ITokenRepository tokenRespository)
        {

            _tokenRespository = tokenRespository;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Request usersdata)
        {
            var token = _tokenRespository.AuthenticateToken(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpPost, Route("refresh")]
        public IActionResult Refresh(Response tokens)
        {
            var principal = _tokenRespository.GetPrincipalFromExpiredToken(tokens.Access_Token);
            Request user = new Request();
            user.Username = principal.Identity?.Name;
            var token = _tokenRespository.GenerateRefreshToken(user);
            return Ok(token);
        }

    }
}
