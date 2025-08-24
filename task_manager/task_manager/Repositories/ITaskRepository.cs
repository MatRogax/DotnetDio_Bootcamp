using task_manager.Models;
using task_manager.Models.Dtos;

namespace task_manager.Repositories
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAllAsync();
        Task<Tasks?> GetByIdAsync(int id);
        Task<Tasks?> GetByTitle(string title);
        Task <List<Tasks?>> GetByDate(string date);
        Task<List<Tasks>> GetByStatus(EnumTaskStatus status);
        Task<Tasks> AddAsync(CreateTaskDto task);
        Task<Tasks?> UpdateAsync(int id, UpdateTaskDto updateData);
        Task DeleteAsync(int id);
    }
}
