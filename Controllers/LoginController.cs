using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace CollegeApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(Roles = "SuperAdmin, Admin")]

  public class LoginController : ControllerBase
  {
    private readonly IConfiguration _configuration;
    public LoginController(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    [HttpPost]
    public ActionResult Login(LoginDTO model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Please Provide Username and Passworld");
      }
      LoginResponseDTO response = new() { UserName = model.UserName };
      if (model.UserName == "Benjamin" && model.Password == "benben")
      {
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
          Subject = new ClaimsIdentity(new Claim[]
          {
            //Username
            new Claim(ClaimTypes.Name, model.UserName),
            //Role
            new Claim(ClaimTypes.Role, "Admin")
          }),
          Expires = DateTime.Now.AddHours(4),
          SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        response.token = tokenHandler.WriteToken(token);
      }
      else
      {
        return Ok("Invalid Username and password");
      }
      return Ok(response);
    }
  }
}