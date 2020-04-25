using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TaskManager.Business;
using TaskManager.Requests;
using TaskManager.Response;

namespace TaskManager.Controllers
{
    [Route("api/task")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TaskController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var tasks = TaskBusiness.GetTasks();
            var response = tasks.Select(t => new TaskResponse { Id = t.Id, Description = t.Description });
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncludeTaskRequest request)
        {
            TaskBusiness.AddTask(request);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(DeleteTaskRequest request)
        {
            var tasks = TaskBusiness.RemoveTask(request);
            var response = tasks.Select(t => new TaskResponse { Id = t.Id, Description = t.Description });
            return Ok(response);
        }
    }
}
