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

        public async Task<bool> deleteTask(int id)
        {
            return await _iToDoRepository.deleteTask(id);
        }

        public async Task<List<TaskClass>> getAllTasks()
        {
            return await _iToDoRepository.getAllTasks();
        }

        public async Task<TaskClass> getTaskById(int id)
        {
            return await _iToDoRepository.getTaskById(id);
        }

        public async Task<TaskClass> saveTask(TaskClass task)
        {
            return await _iToDoRepository.AddTaskAsync(task);
        }

        public async Task<TaskClass> UpdateTask(int id, TaskClass updatedTask)
        {
            return await _iToDoRepository.UpdateTask(id, updatedTask);
        }
    }
}
