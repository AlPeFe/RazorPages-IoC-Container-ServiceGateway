using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Helpers;
using Mappers.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        IUserAuthService _userAuthService;

        public AuthController(IUserAuthService userAuthService)
        {
            _userAuthService = userAuthService;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {

            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (_userAuthService.GetUserAuthorization(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44321",
                    audience: "https://localhost:44321",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new Token{ JwtToken = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
