using task_manager.Models;
using task_manager.Models.Dtos;

namespace task_manager.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task<TaskModel?> GetByIdAsync(int id);
        Task<TaskModel?> GetByTitle(string title);
        Task <List<TaskModel?>> GetByDate(string date);
        Task<List<TaskModel>> GetByStatus(EnumTaskStatus status);
        Task<TaskModel> AddAsync(TaskModel task);
        Task<TaskModel?> UpdateAsync(int id, UpdateTaskDto updateData);
        Task DeleteAsync(int id);
    }
}
