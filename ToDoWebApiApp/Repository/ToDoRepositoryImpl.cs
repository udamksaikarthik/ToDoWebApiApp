
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

        public Task<TaskClass> AddTaskAsync(TaskClass task)
        {
            _db.Add(task);
            _db.SaveChangesAsync();
            return Task.FromResult(task);
        }

    }
}
