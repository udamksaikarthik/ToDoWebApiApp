using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoWebApiApp.Models;
using ToDoWebApiApp.Services;

namespace ToDoWebApiApp.Controllers
{
    [Authorize(Roles = "User")]
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
            return Ok(new { Message = tasks });
        }

        //POST: /api/ToDo/addTask   
        [HttpPost("addTask")]
        public async Task<IActionResult> Post([FromBody] TaskClass task)
        {
            // Here you would typically add the task to your database
            TaskClass savedTask = await _iToDoService.saveTask(task);
            return Ok(savedTask);
        }

        // DELETE: /api/ToDo/deleteTask/{id}
        [HttpDelete("deleteTask/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _iToDoService.deleteTask(id);
            if (isDeleted)
            {
                return Ok(new { Message = $"Task with ID {id} deleted successfully!" });
            }
            else
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }

        }

        //Find Task by ID: /api/ToDo/getTaskById/{id}
        [HttpGet("getTaskById/{id}")]
        public async Task<IActionResult> getTaskById(int id)
        {
            TaskClass task = await _iToDoService.getTaskById(id);
            if (task != null)
            {
                return Ok(new { Message = task });
            }
            else
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }
        }

        //Update the task: /api/ToDo/updateTask/{id}
        [HttpPut("updateTask/{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskClass updatedTask)
        {
            TaskClass taskClass = await _iToDoService.UpdateTask(id, updatedTask);
            if (taskClass == null)
            {
                return NotFound(new { Message = $"Task with ID {id} not found." });
            }

            return Ok(new { Message = taskClass });
        }



    }
}
