using System;
using task_manager.Data;
using task_manager.Models;

namespace task_manager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public Task<TaskModel> AddAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TaskModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TaskModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TaskModel task)
        {
            throw new NotImplementedException();
        }
    }
}
