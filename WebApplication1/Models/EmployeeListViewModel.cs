using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class EmployeeListViewModel
    {
        public List<Employee> Employess { get; set; }
        public List<string> Cities { get; set; }
    }
}