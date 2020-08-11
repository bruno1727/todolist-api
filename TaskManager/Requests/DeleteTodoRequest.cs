using System.Collections.Generic;

namespace TodoList.Requests
{
    public class DeleteTodoRequest
    {
        public IEnumerable<int> TodosIds { get; set; }
    }
}
