using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class StudentListViewComponent:ViewComponent
    {
        private SchollContext _context;
        public StudentListViewComponent(SchollContext context)
        {
            _context = context;
        }
       public  ViewViewComponentResult Invoke(string filter)
        {
            filter = HttpContext.Request.Query["filter"];
            return View(new StudentListViewModel
            {
                students = _context.Students.Where(s => s.FirstName.ToLower().Contains(filter)).ToList()
            }) ; ;
        }
    }
}
