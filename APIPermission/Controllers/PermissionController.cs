using APIPermission.Data.Repositories;
using APIPermission.Models;
using APIPermission.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using Task = APIPermission.Models.Task;

namespace APIPermission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private INoSQL _taskRepository;

        public PermissionController(INoSQL taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/task
        [HttpGet]
        public IActionResult Get()
        {
            var response = _taskRepository.Get();

            return Ok(response);
        }

        // GET api/task/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var task = _taskRepository.Get(id);

            if (task == null)
                //return 404 de não encontrado
                return NotFound();

            //return 200 de sucesso
            return Ok(task);
        }

        // POST api/task
        [HttpPost]
        public IActionResult Post([FromBody] TaskInputModel newTask)
        {
            var task = new Task(newTask.Name, newTask.Description);

            _taskRepository.Add(task);
            //return 201 de criado
            return Created("", task);
        }

        // PUT api/task/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TaskInputModel taskUpdated)
        {
            var existingTask = _taskRepository.Get(id);

            if (existingTask == null)
                //return 404 de não encontrado
                return NotFound();

            existingTask.UpdateTask(taskUpdated.Name, taskUpdated.Description, taskUpdated.IsCompleted);

            _taskRepository.Update(id, existingTask);

            //return 200 de sucesso
            return Ok(existingTask);
        }

        // DELETE api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var existingTask = _taskRepository.Get(id);

            if (existingTask == null)
                return NotFound();

            _taskRepository.Delete(id);

            return NoContent();
        }
    }
}
