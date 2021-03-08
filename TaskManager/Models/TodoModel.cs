using System;

namespace TodoList.Models
{
    public class TodoModel
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
