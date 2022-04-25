using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("/error")]
    public class CommonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
