using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApiApp.Models;
using ToDoWebApiApp.Services;

namespace ToDoWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _iToDoService;

        public ToDoController(IToDoService iToDoService)
        {
            _iToDoService = iToDoService;
        }
        // GET: /api/ToDo
        [HttpGet("getAllTasks")]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello, Welcome to the ToDo API!" });
        }

        [HttpPost("addTask")]
        public IActionResult Post([FromBody] TaskClass task)
        {
            // Here you would typically add the task to your database
            TaskClass savedTask = _iToDoService.saveTask(task);
            return Ok(new { Message = $"Task '{savedTask.Id}' with title: '{savedTask.Title}' added successfully!" });
        }
    }
}
