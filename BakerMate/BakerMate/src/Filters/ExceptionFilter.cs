/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BakerMate.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException)
            {
                MapException(context, HttpStatusCode.BadRequest);
            }
            else if (context.Exception is InvalidOperationException)
            {
                MapException(context, HttpStatusCode.Conflict);
            }
            else if (context.Exception is Services.ObjectNotFoundException)
            {
                MapException(context, HttpStatusCode.NotFound);
            }
            else
            {
                MapException(context, HttpStatusCode.InternalServerError);
            }
        }

        private void MapException(ExceptionContext context, HttpStatusCode statusCode)
        {
            _logger.LogInformation(context.Exception.ToString());
            if (context.Exception.Data.Values.Count > 0)
            {
                foreach (var item in context.Exception.Data.Keys)
                {
                    // destruct object properties // this is done automatically by serilog when we added the '@'
                    _logger.LogError("Function additional data [{Key}] = {@Value}", item, context.Exception.Data[item]);
                }
            }

            context.HttpContext.Response.StatusCode = (int) statusCode;
            context.Result = new JsonResult(context.Exception.Message);
            //context.Result = new StringContent($@"{{""Message"": ""{context.Exception.Message}""}}");
            //context.Result = new StringContent(actionContext.Exception.Message.ToString());
            context.ExceptionHandled = true;
        }
    }
}
