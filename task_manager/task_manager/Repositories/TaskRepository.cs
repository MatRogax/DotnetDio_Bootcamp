using Microsoft.EntityFrameworkCore;
using System;
using task_manager.Data;
using task_manager.Models;
using task_manager.Models.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task_manager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<Tasks> AddAsync(CreateTaskDto task)
        {
            EnumTaskStatus status = EnumTaskStatusExtension.ToTaskStatus(task.Status);
            DateTime date = DateTime.Now.ToUniversalTime();

            Tasks newTask = new Tasks
            {
                Title = task.Title,
                Description = task.Description,
                Date = date,
                Status = status
            };

            await _context.Tasks.AddAsync(newTask);
            await _context.SaveChangesAsync();

            return newTask;
        }

        public async Task DeleteAsync(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);

            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            List<Tasks> allTasks = await _context.Tasks.ToListAsync();
            return allTasks;
        }
        public async Task<Tasks?> GetByIdAsync(int id)
        {
            Tasks? task = await _context.Tasks.FindAsync(id);
            return task;
        }
        public async Task<Tasks?> GetByTitle(string title)
        {
            Tasks? task = await _context.Tasks.FirstOrDefaultAsync(task => task.Title.Equals(title));
            return task;
        }

        public async Task<List<Tasks?>> GetByDate(string date)
        {
            List<Tasks?> tasks = new List<Tasks?>();
            if (!DateTime.TryParse(date, out DateTime parsedDate))
            {
                return tasks;
            }

            tasks = await _context.Tasks
                .Where(task => task.Date.Date.Equals(parsedDate.Date))
                .Cast<Tasks?>()
                .ToListAsync();

            return tasks;
        }

        public async Task<List<Tasks>> GetByStatus(EnumTaskStatus status)
        {
            List<Tasks> tasks = await _context.Tasks
                .Where(task => task.Status.Equals(status))
                .ToListAsync();

            return tasks;
        }

        public async Task<Tasks?> UpdateAsync(int id, UpdateTaskDto updateData)
        {
            Tasks? entity = await _context.Tasks.FindAsync(id);

            if (entity == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateData.Title))
                entity.Title = updateData.Title;

            if (!string.IsNullOrWhiteSpace(updateData.Description))
                entity.Description = updateData.Description;

            if (updateData.Status != null)
                entity.Status = updateData.Status.Value;

            entity.Date = DateTime.Now.ToUniversalTime();

            await _context.SaveChangesAsync();

            return entity;

        }
    }
}
