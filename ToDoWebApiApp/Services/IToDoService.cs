using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Services
{
    public interface IToDoService
    {
        TaskClass saveTask(TaskClass task);
    }
}
