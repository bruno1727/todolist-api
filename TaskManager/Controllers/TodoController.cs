using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
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

        public TodoController(TodoBusiness todoBusiness)
        {
            _todoBusiness = todoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var todos = _todoBusiness.GetTodos();
            var response = todos.Select(t => new TodoResponse { Id = t.Id, Description = t.Description });
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
