using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ErrorException
{
    public class AppExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public AppExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is AppException appEx)
                {
                    context.Response.StatusCode = appEx.HttpCode;
                    var errorResponse = new ResponseModel
                    {
                        HttpCode = appEx.HttpCode,
                        Message = appEx.MessageTitle,
                        DetailMessage = appEx.Message
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                }
                else
                {
                    context.Response.StatusCode = 500;
                    var errorResponse = new ResponseModel
                    {
                        HttpCode = 500,
                        Message = "伺服器內部錯誤",
                        DetailMessage = ex.Message
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                }
            }
        }
    }
}
