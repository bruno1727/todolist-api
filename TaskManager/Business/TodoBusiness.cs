using System;
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
            if (request.Todos == null || !request.Todos.Any())
                throw new Exception("Nenhum item informado");

            var todos = request.Todos.Select(t =>
            {
                return new TodoModel
                {
                    Description = t.Description,
                    CreationDate = t.CreationDate.HasValue ? t.CreationDate : DateTime.Now
                };
            });
            _context.Todo.AddRange(todos);
            _context.SaveChanges();
        }

        public IEnumerable<TodoModel> GetTodos(DateTime? beginDate)
        {
            if(!beginDate.HasValue)
                return _context.Todo.ToList();
            else
                return _context.Todo.Where(t => t.CreationDate > beginDate).ToList();
        }

        public IEnumerable<TodoModel> RemoveTodos(DeleteTodoRequest request)
        {
            if (request.TodosIds == null || !request.TodosIds.Any())
                throw new Exception("Nenhum item informado");

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
