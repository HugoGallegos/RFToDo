using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFToDo.Shared.Models;
using RFToDo.Shared.Services;

namespace RFToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet("GetTasks/{id:int}")]
        public async Task<ActionResult<List<Tasks>>> GetTasks(int id)
        {
            var tasks = await _taskService.GetTasks(id);
            return tasks;
        }
        [HttpPost("CreateTask")]
        public async Task<ActionResult<Task>> CreateTask(Tasks task)
        {
            var addedTask = await _taskService.CreateTask(task);
            return Ok(addedTask);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteTask(int id)
        {
            var deletedTask = await _taskService.DeleteTask(id);
            return deletedTask;
        }
        [HttpPut("FinishTask/{id}")]
        public async Task<ActionResult<string>> FinishTask(int id)
        {
            var finishedTask = _taskService.FinishTask(id);
            return Ok(finishedTask);
        }
        [HttpPut("ImportanceTask/{id:int}")]
        public async Task<ActionResult<string>> ImportanceTask(int id)
        {
            var importanceTask = _taskService.ImportanceTask(id);
            return Ok(importanceTask);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateTask(Tasks task)
        {
            var updatedTask = _taskService.UpdateTask(task);
            return Ok(updatedTask);
        }
    }
}
