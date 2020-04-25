using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManager.Business;
using TaskManager.Requests;

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
            return Ok(TaskBusiness.GetTasks());
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncludeTaskRequest request)
        {
            TaskBusiness.AddTask(request);
            return Ok();
        }

        [HttpDelete("{task}")]
        public IActionResult Delete(string task)
        {
            TaskBusiness.RemoveTask(task);
            return Ok();
        }
    }
}
