using System.Collections.Generic;
using System.Linq;
using TodoList.Models;
using TodoList.Requests;
using TodoList.Response;

namespace TodoList.Business
{
    public class TodoBusiness
    {
        private readonly TodoContext _context;

        public TodoBusiness(TodoContext context)
        {
            _context = context;
        }

        public void AddTodo(IncludeTodoRequest request)
        {
            var todos = request.Todos.Select(t => new TodoModel { Description = t.Description });
            _context.Todo.AddRange(todos);
            _context.SaveChanges();
        }

        public IEnumerable<TodoModel> GetTodos()
        {
            return _context.Todo.ToList();
        }

        public IEnumerable<TodoModel> RemoveTodos(DeleteTodoRequest request)
        {
            var deleted = new List<TodoModel>();
            foreach(var id in request.TodosIds)
            {
                var todo = _context.Todo.Find(id);
                _context.Todo.Remove(todo);
                deleted.Add(todo);
            }
            _context.SaveChanges();
            return deleted;
        }
    }
}
