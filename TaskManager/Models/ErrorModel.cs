using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class ErrorModel
    {
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public int? HttpStatusCode { get; set; }
    }
}
