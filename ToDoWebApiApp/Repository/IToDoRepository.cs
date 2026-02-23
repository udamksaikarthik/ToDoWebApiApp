using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Repository
{
    public interface IToDoRepository
    {
        Task<TaskClass> AddTaskAsync(TaskClass task);
    }
}
