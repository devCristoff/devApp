﻿using Vimenpaq.Core.Application.Exceptions;
using Vimenpaq.Core.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace Vimenpaq.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/xml";

                var responseModel = new Response<string>()
                {
                    Succeeded = false,
                    Message = error?.Message
                };
                
                switch (error)
                {
                    case ApiException e:
                        switch (e.ErrorCode)
                        {
                            case (int)HttpStatusCode.BadRequest:
                                response.StatusCode = (int)HttpStatusCode.BadRequest;
                                break;
                            case (int)HttpStatusCode.NotFound:
                                response.StatusCode = (int)HttpStatusCode.NotFound;
                                break;
                            default:
                                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                        }
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default: 
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
