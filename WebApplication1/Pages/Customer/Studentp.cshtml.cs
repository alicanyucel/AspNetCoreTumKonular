using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Pages.Customer
{
    public class StudentpModel : PageModel
    {
        private readonly SchollContext _context;

        public StudentpModel(SchollContext context)
        {
            _context = context;
        }
        public List<Student> students { get; set; }
        public void OnGet(string search)
        {
            students = string.IsNullOrEmpty(search) ? _context.Students.ToList():
            _context.Students.Where(s=>s.FirstName.ToLower().Contains(search)).ToList();

        }
        [BindProperty]
        public Student student { get; set; }
        public IActionResult OnPost()
        {
            _context.Students.Add(student);
            _context.SaveChanges();
          return   RedirectToPage("/studentp");
        }
    }
}