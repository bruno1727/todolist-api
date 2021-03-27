using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Requests
{
    public class IncludeTodoRequest
    {
        [Required(ErrorMessage = "teste {0}")]
        [Display(Name = "Tarefas")]
        public IEnumerable<TodoRequest> Todos { get; set; }
    }
}
