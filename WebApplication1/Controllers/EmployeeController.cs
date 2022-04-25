using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private ICalculator _calculator;
        public EmployeeController(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public IActionResult Add()
        {
            var employeeAddViewModel = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text="ankara",Value="6"},
                    new SelectListItem{Text="hatay",Value="31"},
                    new SelectListItem{Text="istanbul",Value="34"},
                    new SelectListItem{Text="izmir",Value="35"},
                    new SelectListItem{Text="konya",Value="42"},
                    new SelectListItem{Text="kocaeli",Value="41"}
                }
            };
            return View(employeeAddViewModel);
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            return View();
        }
        public string Calculate()
        {
            return _calculator.Calculate(100).ToString();
        }
    }
}
