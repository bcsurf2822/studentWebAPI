using CollegeApp.MyLogging;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [EnableCors(PolicyName ="AllowGoogle")]
  public class DemoController : ControllerBase
  {

    private readonly ILogger<DemoController> _logger;
    public DemoController(ILogger<DemoController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult Index()
    {
      _logger.LogTrace("Log message from Trace");
      _logger.LogDebug("Log message from LogDebug");
      _logger.LogInformation("Log message from LogInformation");
      _logger.LogWarning("Log message from LogWarning");
      _logger.LogError("Log message from LogError");
      _logger.LogCritical("Log message from LogCritical");

      return Ok();

    }

  }
}