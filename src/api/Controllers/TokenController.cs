using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    private IConfiguration _config;

    public TokenController(IConfiguration config)
    {
      _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreateToken([FromBody]LoginModel login)
    {
      IActionResult response = Unauthorized();
      var user = Authenticate(login);

      if (user == true)
      {
        var tokenString = BuildToken();
        response = Ok(new { token = tokenString });
      }

      return response;
    }

    private string BuildToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Issuer"],
          expires: DateTime.Now.AddMinutes(30),
          signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
     }

     private bool Authenticate(LoginModel login)
     {
        if (login.Username == _config["Jwt:AppAuthUsername"] && login.Password == _config["Jwt:AppAuthPassword"])
        {
            return true;
        }
        return false;
     }

    public class LoginModel
    {
      public string Username { get; set; }
      public string Password { get; set; }
    }
  }
}