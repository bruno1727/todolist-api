using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Handler
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async Task<ErrorModel> HandleAsync(Exception exception)
        {

            //if (exception is BusinessException)
            //{
            //    return new ErrorModel()
            //    {
            //        Error_description = exception.Message,
            //        HttpStatusCode = 400
            //    };
            //}
            return null;
        }
    }
}
