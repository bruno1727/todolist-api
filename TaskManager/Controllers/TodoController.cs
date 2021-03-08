using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Business;
using TodoList.Requests;
using TodoList.Response;

namespace TodoList.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TodoController : ControllerBase
    {
        private readonly TodoBusiness _todoBusiness;
        private readonly ConfigurationBusiness _configurationBusiness;

        public TodoController(TodoBusiness todoBusiness, ConfigurationBusiness configurationBusiness)
        {
            _todoBusiness = todoBusiness;
            _configurationBusiness = configurationBusiness;
        }

        [HttpGet]
        public ActionResult<List<TodoResponse>> Get()
        {
            var descriptionFromMiddleware = _configurationBusiness.Description;
            var todos = _todoBusiness.GetTodos();
            var response = todos.Select(t => new TodoResponse { Id = t.Id, Description = t.Description, CreationDate = t.CreationDate});
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncludeTodoRequest request)
        {
            _todoBusiness.AddTodo(request);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(DeleteTodoRequest request)
        {
            var todos = _todoBusiness.RemoveTodos(request);
            var response = todos.Select(t => new TodoResponse { Id = t.Id, Description = t.Description });
            return Ok(response);
        }
    }
}
