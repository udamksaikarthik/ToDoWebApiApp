
using Microsoft.EntityFrameworkCore;
using ToDoWebApiApp.Models;


namespace ToDoWebApiApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskClass> Todos => Set<TaskClass>();
    }
}
