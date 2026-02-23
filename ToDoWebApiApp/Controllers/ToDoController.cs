using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        // GET: /api/ToDo
        [HttpGet("getAllTasks")]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello, Welcome to the ToDo API!" });
        }
    }
}
