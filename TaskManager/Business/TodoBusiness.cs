using System.Collections.Generic;
using System.Linq;
using TodoList.Models;
using TodoList.Requests;
using TodoList.Response;

namespace TodoList.Business
{
    public class TodoBusiness
    {
        public void AddTodo(IncludeTodoRequest request)
        {
            using (var db = new TodoContext())
            {
                var todos = request.Todos.Select(t => new TodoModel { Description = t.Description });
                db.Todo.AddRange(todos);
                db.SaveChanges();
            }
        }

        public IEnumerable<TodoModel> GetTodos()
        {
            using (var db = new TodoContext())
            {
                return db.Todo.ToList();
            }
        }

        public IEnumerable<TodoModel> RemoveTodos(DeleteTodoRequest request)
        {
            using (var db = new TodoContext())
            {
                var deleted = new List<TodoModel>();
                foreach(var id in request.TodosIds)
                {
                    var todo = db.Todo.Find(id);
                    db.Todo.Remove(todo);
                    deleted.Add(todo);
                }
                db.SaveChanges();
                return deleted;
            }
        }
    }
}
