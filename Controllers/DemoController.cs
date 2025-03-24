// using CollegeApp.MyLogging;
// using Microsoft.AspNetCore.Mvc;

// namespace CollegeApp.Controllers
// {
//   [Route("api/[controller]")]
//   [ApiController]
//   public class DemoController : ControllerBase
//   {

//     private readonly IMyLogger _myLogger;
//     //1. Strongly Coupled/tightly Coupled
//     // public DemoController()
//     // {
//     //   _myLogger = new LogToServerMemory();
//     // }


//     //2 Loosely Coupled
//     public DemoController(IMyLogger myLogger)
//     {
//       _myLogger = myLogger;
//     }
//     [HttpGet]
//     public ActionResult Index()
//     {
//       _myLogger.Log("Index method started");
//       return Ok();
//     }

//   }
// }