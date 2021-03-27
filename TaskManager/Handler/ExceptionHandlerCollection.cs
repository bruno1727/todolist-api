using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Handler
{
    public class ExceptionHandlerCollection
    {
        public List<IExceptionHandler> Handlers { get; private set; } = new List<IExceptionHandler>();

        public ExceptionHandlerCollection(IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            Handlers.AddRange(exceptionHandlers);
        }
    }
}
