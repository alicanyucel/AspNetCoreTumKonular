using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [CustomFilter]
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
