using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WebApplication1.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
           // int b = 10;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //int i = 20;
        }
    }
}
