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
      if (model.UserName == "ben" && model.Password == "benben")
      {
        var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret") ?? "Secret not found");
        var tokenHandler = new JwtSecurityTokenHandler();
        var now = DateTime.UtcNow;

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
          Subject = new ClaimsIdentity(new Claim[]
          {
    new Claim(ClaimTypes.Name, model.UserName),
    new Claim(ClaimTypes.Role, "Admin")
          }),
          NotBefore = now,
          IssuedAt = now,
          Expires = now.AddHours(4),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
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