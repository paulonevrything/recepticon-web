using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Recepticon.Core.Exceptions;
using Recepticon.Domain.Models;

namespace Recepticon.Core.Helpers
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate requestDelegate;
        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorMessageObject = new Error { Message = ex.Message};
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if(ex.InnerException is AlreadyExistException)
            {
                statusCode = (int)HttpStatusCode.Conflict;
            }
            else if(ex.InnerException is CustomException)
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
            }
            else if (ex.InnerException is InvalidCheckInAndCheckOutException || ex.InnerException is OccupiedRoomException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (ex.InnerException is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }

            var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}
