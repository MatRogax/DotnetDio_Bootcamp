using Microsoft.AspNetCore.Mvc;
using task_manager.Data;
using task_manager.Models;
using task_manager.Repositories;

namespace task_manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagerController : ControllerBase
    {
        private readonly TaskRepository _repository;

        public TaskManagerController(TaskRepository repository)
        {
            _repository = repository;
        }

    }
}
