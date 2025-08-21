using Microsoft.EntityFrameworkCore;
using task_manager.Models;

namespace task_manager.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
