using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using task_manager.Data;
using task_manager.Models;
using task_manager.Models.Dtos;
using task_manager.Repositories;

namespace task_manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagerController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskManagerController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Tasks? task = _repository.GetByIdAsync(id).Result;

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("ObterTodos")]
        public IActionResult GetAllTasks()
        {
            List<Tasks> tasks = _repository.GetAllAsync().Result;
            return Ok(tasks);

        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult GetByTitle(string titulo)
        {
            Tasks? task = _repository.GetByTitle(titulo).Result;
            return Ok(task);
        }

        [HttpGet("ObterPorData")]
        public IActionResult GetByData(string data)
        {
            List<Tasks?> tasks = _repository.GetByDate(data).Result;
            return Ok(tasks);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult GetByStatus(EnumTaskStatus status)
        {
            List<Tasks> tasks = _repository.GetByStatus(status).Result;
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskDto task)
        {
            var createdTask = _repository.AddAsync(task).Result;
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto TaskData)
        {
            try
            {
                var updateTask = await _repository.UpdateAsync(id, TaskData);
                return Ok(updateTask);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskExists = await _repository.GetByIdAsync(id);

            if (taskExists == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
