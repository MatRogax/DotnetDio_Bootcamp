using task_manager.Models;

namespace task_manager.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllAsync();
        Task<TaskModel?> GetByIdAsync(int id);
        Task<TaskModel> AddAsync(TaskModel task);
        Task UpdateAsync(TaskModel task);
        Task DeleteAsync(int id);
    }
}
