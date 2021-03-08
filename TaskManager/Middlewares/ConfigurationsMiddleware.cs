using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Business;

namespace TodoList.Middlewares
{
    public class ConfigurationsMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigurationsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, TodoBusiness todoBusiness, ConfigurationBusiness configurationBusiness)
        {
            configurationBusiness.Description = todoBusiness.GetTodos().FirstOrDefault()?.Description;
            Console.WriteLine("teste");

            await _next(context);
        }
    }
}
