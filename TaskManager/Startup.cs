﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Business;
using TodoList.Extensions;
using TodoList.Handler;
using TodoList.Middlewares.Extensions;

namespace TodoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });//teste

            //services.AddDbContext<TodoContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=todolist;Trusted_Connection=True;"));

            services.AddScoped<TodoBusiness>();
            services.AddScoped<ConfigurationBusiness>();
            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddTransient<ExceptionHandlerCollection, ExceptionHandlerCollection>();

            services.AddSwaggerDocument();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvcCore().AddApiExplorer();
        }
        
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {

            //app.UseCustomExceptionHandler();
            app.UseConfigurations();

            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

        }
    }
}
