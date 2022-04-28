using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationandAuthorization.Controllers
{
    public class AuthenticateController : ControllerBase
    {

        private readonly IConfiguration _config;

        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }
 
        private string GenerateJSONWebToken(LoginModel passData)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(signingCredentials: credentials,
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.MaxValue);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool CheckPassword(LoginModel password)
        {
            string rightPassword = "tokm_pass";

            if (password.Password == rightPassword)
                return true;
			else
                return false;
        }

        //--- LoginToAdmin ---
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] LoginModel password)
        {
            IActionResult response = Unauthorized();
            
            if (CheckPassword(password))
            {
                var tokenString = GenerateJSONWebToken(password);
                response = Ok(new { Token = tokenString });
            }
            return response;
        }
    }


    public class LoginModel
    {
        [Required]
        public string Password { get; set; }
    }

}
