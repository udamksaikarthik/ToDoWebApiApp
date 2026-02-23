using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<IActionResult> Get()
        {
            List<TaskClass> tasks = await _iToDoService.getAllTasks();
            return Ok(new { Message = tasks});
        }

        [HttpPost("addTask")]
        public async Task<IActionResult> Post([FromBody] TaskClass task)
        {
            // Here you would typically add the task to your database
            TaskClass savedTask = await _iToDoService.saveTask(task);
            return Ok(new { Message = $"Task '{savedTask.Id}' with title: '{savedTask.Title}' added successfully!" });
        }
    }
}
