using System;
using System.Threading.Tasks;
using FaleMaisServices.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace FaleMaisAPI.Middlewares {
  public class ExceptionHandler : IMiddleware {
    private readonly IWebHostEnvironment Environment;
    private readonly string ContentType = "application/json";

    public ExceptionHandler(IWebHostEnvironment environment) {
      Environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
      try {
        await next(context);
      } catch (FaleMaisException fme) {
        await HandleFaleMaisException(context, fme);
      } catch (Exception ex) {
        await HandleUnknownException(context, ex);
      }
    }

    private Task HandleFaleMaisException(
      HttpContext context,
      FaleMaisException exception
    ) {
      var json = JsonConvert.SerializeObject(
        new {
          StatusCode = exception.StatusCode,
          Message = exception.Message,
        },
        new JsonSerializerSettings() {
          NullValueHandling = NullValueHandling.Ignore,
        }
      );

      context.Response.StatusCode = exception.StatusCode;
      context.Response.ContentType = ContentType;

      return context.Response.WriteAsync(json);
    }

    private Task HandleUnknownException(
      HttpContext context,
      Exception exception
    ) {
      var json = JsonConvert.SerializeObject(
        new {
          StatusCode = StatusCodes.Status500InternalServerError,
          Message = exception.Message,
          Details = Environment.IsDevelopment() ? exception : null
        },
        new JsonSerializerSettings() {
          NullValueHandling = NullValueHandling.Ignore,
        }
      );

      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      context.Response.ContentType = ContentType;

      return context.Response.WriteAsync(json);
    }
  }
}
