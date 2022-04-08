using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ActionResult<List<TodoResponse>> Get([FromQuery] DateTime? beginDate)
        {
            
            var descriptionFromMiddleware = _configurationBusiness.Description;
            var todos = _todoBusiness.GetTodos(beginDate);
            var response = todos.Select(t => new TodoResponse { Id = t.Id, Description = t.Description, CreationDate = t.CreationDate});
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncludeTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Erros: " + string.Join(". ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            }
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

        [HttpGet("apelidos")]
        public IActionResult GetApelidos([FromQuery] string searchText)
        {
            var list = new List<string> { "@Tony Stark", "@Steve Roger", "@Thanos", "@Goku", "@Gohan", "@John Wick", "@Spider Man"};
            return Ok(list.Where(a => a.ToUpper().Replace("@", "").StartsWith(searchText.ToUpper())).ToList());
        }
    }
}
