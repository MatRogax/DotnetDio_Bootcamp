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

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
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

        public async Task<List<TaskModel>> GetAllAsync()
        {
            List<TaskModel> allTasks = await _context.Tasks.ToListAsync();
            return allTasks;
        }
        public async Task<TaskModel?> GetByIdAsync(int id)
        {
            TaskModel? task = await _context.Tasks.FindAsync(id);
            return task;
        }
        public async Task<TaskModel?> GetByTitle(string title)
        {
            TaskModel? task = await _context.Tasks.FirstOrDefaultAsync(task => task.Title.Equals(title));
            return task;
        }

        public async Task<List<TaskModel?>> GetByDate(string date)
        {
            List<TaskModel?> tasks = new List<TaskModel?>();
            if (!DateTime.TryParse(date, out DateTime parsedDate))
            {
                return tasks;
            }

            tasks = await _context.Tasks
                .Where(task => task.Date.Date.Equals(parsedDate.Date))
                .Cast<TaskModel?>()
                .ToListAsync();

            return tasks;
        }

        public async Task<List<TaskModel>> GetByStatus(EnumTaskStatus status)
        {
            List<TaskModel> tasks = await _context.Tasks
                .Where(task => task.Status.Equals(status))
                .ToListAsync();

            return tasks;
        }

        public async Task<TaskModel?> UpdateAsync(int id, UpdateTaskDto updateData)
        {
            TaskModel? entity = await _context.Tasks.FindAsync(id);

            if (entity == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateData.Title))
                entity.Title = updateData.Title;

            if (!string.IsNullOrWhiteSpace(updateData.Description))
                entity.Description = updateData.Description;

            if (updateData.Date != null)
                entity.Date = updateData.Date.Value;

            if (updateData.Status != null)
                entity.Status = updateData.Status.Value;

            await _context.SaveChangesAsync();

            return entity;

        }
    }
}
