using Microsoft.EntityFrameworkCore;
using task_manager.Models;

namespace task_manager.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .Property(t => t.Status)
                .HasConversion<string>(); 
        }
    }
}
