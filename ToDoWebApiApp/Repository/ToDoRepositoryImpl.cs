using Microsoft.EntityFrameworkCore;
using ToDoWebApiApp.Data;
using ToDoWebApiApp.Models;
using ToDoWebApiApp.Services;

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

        public async Task<bool> deleteTask(int id)
        {
            var existing = await _db.Todos.FindAsync(id);
            if (existing == null)
            {
                return false;
            }

            _db.Todos.Remove(existing);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskClass>> getAllTasks()
        {
            List<TaskClass> taskClasses = await _db.Todos.ToListAsync();
            return taskClasses;
        }

        public async Task<TaskClass> getTaskById(int id)
        {
            return await _db.Todos.FindAsync(id);
        }

        public async Task<TaskClass> UpdateTask(int id, TaskClass updatedTask)
        {
            var existing = await _db.Todos.FindAsync(id);
            if (existing == null)
            {
                return null;
            }

            existing.Title = updatedTask.Title;
            existing.Description = updatedTask.Description;
            existing.Priority = updatedTask.Priority;
            existing.Status = updatedTask.Status;
            existing.UpdatedAt = DateTime.UtcNow;

            _db.Todos.Update(existing);
            await _db.SaveChangesAsync();
            return existing;
        }
    }
}
