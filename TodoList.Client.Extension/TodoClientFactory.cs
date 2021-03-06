using Microsoft.Extensions.DependencyInjection;
using System;

namespace TodoList.Client.Extensions
{
    public class TodoClientFactory
    {
        private readonly string _baseUrl;

        public TodoClientFactory()
        {
            _baseUrl = "http://localhost:54879";
        }

        public ITodoClient CreateTodoClientInstance()
        {
            return new TodoClient(_baseUrl);
        }
    }
}
