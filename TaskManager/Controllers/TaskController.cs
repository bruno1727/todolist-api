using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly TaskBusiness _taskBusiness;

        public TaskController(TaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _taskBusiness.GetTasks();
            var response = tasks.Select(t => new TaskResponse { Id = t.Id, Description = t.Description });
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncludeTaskRequest request)
        {
            _taskBusiness.AddTask(request);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(DeleteTaskRequest request)
        {
            var tasks = _taskBusiness.RemoveTask(request);
            var response = tasks.Select(t => new TaskResponse { Id = t.Id, Description = t.Description });
            return Ok(response);
        }
    }
}
