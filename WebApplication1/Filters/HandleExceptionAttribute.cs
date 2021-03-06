using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Filters
{
    public class HandleExceptionAttribute:ExceptionFilterAttribute
    {
        public string ViewName { get; set; } = "Error";
        public override void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName =ViewName };
            var modelDataProvider = new EmptyModelMetadataProvider();
            result.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(modelDataProvider, context.ModelState);
            result.ViewData.Add("HandleException",context.Exception);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
