using System.Threading.Tasks;
using ToDoWebApiApp.Data;
using ToDoWebApiApp.Models;
using ToDoWebApiApp.Repository;

namespace ToDoWebApiApp.Services
{
    public class ToDoServiceImpl : IToDoService
    {
        private readonly IToDoRepository _iToDoRepository;

        public ToDoServiceImpl(IToDoRepository iToDoRepository)
        {
            _iToDoRepository = iToDoRepository;
        }

        public async Task<List<TaskClass>> getAllTasks()
        {
            return await _iToDoRepository.getAllTasks();
        }

        public async Task<TaskClass> saveTask(TaskClass task)
        {
            return await _iToDoRepository.AddTaskAsync(task);
        }
    }
}
