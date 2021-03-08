using System;

namespace TodoList.Requests
{
    public class TodoRequest
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
