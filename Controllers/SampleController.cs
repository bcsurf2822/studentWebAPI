using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    [HttpGet]
    public string GetstudentName()
    {
      return "Student name 1";
    }
  }
}