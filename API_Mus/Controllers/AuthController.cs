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
 
        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginModel AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;

   
            if (login.Password == "admin")
            {
                user = new LoginModel { Password = "admin" };
            }
            return user;
        }

        //--- LoginToAdmin ---
        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] LoginModel data)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(data);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
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
