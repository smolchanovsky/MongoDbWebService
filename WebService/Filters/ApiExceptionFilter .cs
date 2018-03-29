using System;
using System.Net;
using Infrastructure.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebService.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ApiError apiError;
            switch (context.Exception)
            {
                case Exception e:
                    SetErrorResponse(context, out apiError, HttpStatusCode.BadRequest, e.HResult, e.Message);
                    break;
                default:
                    SetErrorResponse(context, out apiError, HttpStatusCode.BadRequest, errorCode: 1, message: "Unknown error");
                    break;
            }
            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }

        private void SetErrorResponse(ActionContext context, out ApiError apiError, HttpStatusCode statusCode, int errorCode, string message)
        {
            context.HttpContext.Response.StatusCode = (int)statusCode;
            apiError = new ApiError
            {
                Code = errorCode,
                Message = message,
            };
        }
    }
}
