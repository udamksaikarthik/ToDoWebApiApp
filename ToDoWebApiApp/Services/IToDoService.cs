using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Services
{
    public interface IToDoService
    {
        Task<bool> deleteTask(int id);
        Task<List<TaskClass>> getAllTasks();
        Task<TaskClass> getTaskById(int id);
        Task<TaskClass> saveTask(TaskClass task);
        Task<TaskClass> UpdateTask(int id, TaskClass updatedTask);
    }
}
