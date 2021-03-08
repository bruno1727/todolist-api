using System;
using System.Collections.Generic;

namespace TodoList.Requests
{
    public class IncludeTodoRequest
    {
        public IEnumerable<TodoRequest> Todos { get; set; }
    }
}
