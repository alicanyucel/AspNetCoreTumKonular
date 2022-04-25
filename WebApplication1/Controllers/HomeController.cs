using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "ali can";
        
        }
        
        public ViewResult Index3()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="ali can",LastName="yucel",CityId=6},
                new Employee{Id=2,FirstName="selcuk",LastName="inan",CityId=34},
                new Employee{Id=3,FirstName="aydın can",LastName="yucel",CityId=6},
                new Employee{Id=4,FirstName="salihcan",LastName="inan",CityId=34},
                new Employee{Id=5,FirstName="ahmet can",LastName="yucel",CityId=6},
                new Employee{Id=6,FirstName="sinan",LastName="inan",CityId=34}
            };
            List<string> cities = new List<string> { "istanbul", "ankara", "adana", "izmir" };
            var employeeListViewModel = new EmployeeListViewModel
            {
                Employess = employees,
                Cities = cities
            };
            return View(employeeListViewModel);
        }
        public IActionResult Index4()
        {
            return Ok();
        }
        public IActionResult Index5()
        {
            return BadRequest();
        }
        public RedirectResult Index6()
        {
            return Redirect("/home/index3");
        }
        public IActionResult Index7()
        {
            return RedirectToAction("index5");
        }
        public IActionResult Index8()
        {
            return RedirectToRoute("default");
        }
        public JsonResult Index9()
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="ali can",LastName="yucel",CityId=6},
                new Employee{Id=2,FirstName="selcuk",LastName="inan",CityId=34}
            };
            List<string> cities = new List<string> { "istanbul", "ankara", "adana", "izmir" };
            var employeeListViewModel = new EmployeeListViewModel
            {
                Employess = employees,
                Cities = cities
            };

            return Json(employeeListViewModel);
        }
        public IActionResult RazorDemo()
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="ali can",LastName="yucel",CityId=6},
                new Employee{Id=2,FirstName="selcuk",LastName="inan",CityId=34}
            };
            List<string> cities = new List<string> { "istanbul", "ankara", "adana", "izmir" };
            var model = new EmployeeListViewModel
            {
                Employess = employees,
                Cities = cities
            };

            return View(model);
        }
        public JsonResult Index10(string key)
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,FirstName="ali can",LastName="yucel",CityId=6},
                new Employee{Id=2,FirstName="eser",LastName="yucel",CityId=6},
                new Employee{Id=3,FirstName="mehmet",LastName="yucel",CityId=6},
                new Employee{Id=4,FirstName="vural",LastName="yucel",CityId=6},
                new Employee{Id=5,FirstName="burhan",LastName="yucel",CityId=6},
                new Employee{Id=6,FirstName="selcuk",LastName="inan",CityId=34}
            };
            if(string.IsNullOrEmpty(key))
            {
                return Json(employees);
            }
            var result = employees.Where(e=>e.FirstName.ToLower().Contains(key));
            return Json(result);
        }
        public ViewResult EmployeeForm()
        {
            return View();
        }
        
    }
}