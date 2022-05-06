using BMS.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BMS.Infra.Repository.Authentication

{
    public interface ITokenRepository
    {
        Response AuthenticateToken(Request Users);
        string GenerateRefreshToken();
        Response GenerateRefreshToken(Request user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        bool IsValidUser(Request user);
    }
}
