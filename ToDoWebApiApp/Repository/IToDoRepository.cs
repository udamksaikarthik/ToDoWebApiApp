using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Repository
{
    public interface IToDoRepository
    {
        Task<TaskClass> AddTaskAsync(TaskClass task);
        Task<bool> deleteTask(int id);
        Task<List<TaskClass>> getAllTasks();
        Task<TaskClass> getTaskById(int id);
        Task<TaskClass> UpdateTask(int id, TaskClass updatedTask);
    }
}
