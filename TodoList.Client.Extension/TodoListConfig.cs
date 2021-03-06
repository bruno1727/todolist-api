using Microsoft.Extensions.DependencyInjection;
using System;

namespace TodoList.Client.Extensions
{
    public static class TodoListConfig
    {
        public static void AddTodoList(this IServiceCollection services)
        {
            services.AddTransient<TodoClientFactory>();
            services.AddScoped(x => x.GetService<TodoClientFactory>().CreateTodoClientInstance());
        }
    }
}
