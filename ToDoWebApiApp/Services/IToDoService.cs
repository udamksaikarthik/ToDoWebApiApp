using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Services
{
    public interface IToDoService
    {
        Task<List<TaskClass>> getAllTasks();
        Task<TaskClass> saveTask(TaskClass task);
    }
}
