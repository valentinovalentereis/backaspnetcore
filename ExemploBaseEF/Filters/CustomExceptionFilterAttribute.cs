using ExemploBaseEF.APIException;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace ExemploBaseEF.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is UnauthorizedAccessException)
                SetExceptionResult(context, exception, HttpStatusCode.Unauthorized);
            else if (exception is Exception)
                SetExceptionResult(context, exception, HttpStatusCode.BadRequest);
            else
                SetExceptionResult(context, exception, HttpStatusCode.InternalServerError);
        }

        private static void SetExceptionResult(ExceptionContext context, Exception exception, HttpStatusCode code)
        {
            context.Result = new JsonResult(new ApiException(exception))
            {
                StatusCode = (int)code
            };
        }
    }
}
