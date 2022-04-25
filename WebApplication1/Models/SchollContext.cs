using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class SchollContext:DbContext
    {
        public SchollContext(DbContextOptions<SchollContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
