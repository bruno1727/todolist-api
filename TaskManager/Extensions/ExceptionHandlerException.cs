using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoList.Handler;
using TodoList.Models;
using TodoList.Response;

namespace TodoList.Extensions
{
    public static class ExceptionHandlerException
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                async context =>
                {
                    //var env = builder.ApplicationServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
                    var handleCollection = builder.ApplicationServices.GetService(typeof(ExceptionHandlerCollection)) as ExceptionHandlerCollection;
                    int statusCode = (int)HttpStatusCode.InternalServerError;
                    var response = new ErrorResponse();
                    var exHandler = context.Features.Get<IExceptionHandlerFeature>();
                    var ex = exHandler.Error;
                    ErrorModel errorModel = null;

                    foreach (var item in handleCollection.Handlers)
                    {
                        errorModel = await item.HandleAsync(ex);

                        if (errorModel != null)
                            break;
                    }

                    if (errorModel != null)
                    {
                        response.Error = errorModel.Error;
                        response.ErrorDescription = errorModel.ErrorDescription;
                        statusCode = errorModel.HttpStatusCode ?? 400;
                    }
                    else
                    {
                        //if (env.IsDevelopment())
                        //{
                            response.Error = ex.Message;
                            response.ErrorDescription = ex.StackTrace;
                        //}
                        //else
                        //{
                        //    response.Error = "Um erro inesperado ocorreu.";
                        //}
                    }

                    var json = JsonConvert.SerializeObject(response);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;
                    await context.Response.WriteAsync(json).ConfigureAwait(false);
                });
            }
            );

            return app;
        }
    }
}
