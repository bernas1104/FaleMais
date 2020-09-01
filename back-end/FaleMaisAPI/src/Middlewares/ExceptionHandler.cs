using System;
using System.Threading.Tasks;
using FaleMaisServices.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace FaleMaisAPI.Middlewares {
  public class ExceptionHandler : IMiddleware {
    private string Json;
    private int StatusCode;
    private readonly IWebHostEnvironment Environment;
    private readonly string ContentType = "application/json";

    public ExceptionHandler(IWebHostEnvironment environment) {
      Environment = environment;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
      try {
        await next(context);
      } catch (FaleMaisException fme) {
        HandleFaleMaisException(fme);
        StatusCode = fme.StatusCode;
      } catch (Exception ex) {
        HandleUnknownException(ex);
        StatusCode = StatusCodes.Status500InternalServerError;
      } finally {
        context.Response.StatusCode = StatusCode;
        context.Response.ContentType = ContentType;

        await context.Response.WriteAsync(Json);
      }
    }

    private void HandleFaleMaisException(FaleMaisException exception) {
      Json = JsonConvert.SerializeObject(
        new {
          StatusCode = exception.StatusCode,
          Message = exception.Message,
        },
        new JsonSerializerSettings() {
          NullValueHandling = NullValueHandling.Ignore,
        }
      );
    }

    private void HandleUnknownException(Exception exception) {
      Json = JsonConvert.SerializeObject(
        new {
          StatusCode = StatusCodes.Status500InternalServerError,
          Message = exception.Message,
          Details = Environment.IsDevelopment() ? exception : null
        },
        new JsonSerializerSettings() {
          NullValueHandling = NullValueHandling.Ignore,
        }
      );
    }
  }
}
