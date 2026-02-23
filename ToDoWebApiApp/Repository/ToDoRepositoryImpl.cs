using Microsoft.EntityFrameworkCore;
using ToDoWebApiApp.Data;
using ToDoWebApiApp.Models;

namespace ToDoWebApiApp.Repository
{
    public class ToDoRepositoryImpl : IToDoRepository
    {
        private readonly AppDbContext _db;

        public ToDoRepositoryImpl(AppDbContext db)
        {
            _db = db;
        }

        public async Task<TaskClass> AddTaskAsync(TaskClass task)
        {
            await _db.Todos.AddAsync(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskClass>> getAllTasks()
        {
            List<TaskClass> taskClasses = await _db.Todos.ToListAsync();
            return taskClasses;
        }
    }
}
