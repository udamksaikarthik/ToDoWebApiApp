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

        public TaskClass saveTask(TaskClass task)
        {
            return _iToDoRepository.AddTaskAsync(task).Result;
        }
    }
}
