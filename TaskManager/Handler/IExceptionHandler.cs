using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Handler
{
    public interface IExceptionHandler
    {
        Task<ErrorModel> HandleAsync(Exception exception);
    }
}
