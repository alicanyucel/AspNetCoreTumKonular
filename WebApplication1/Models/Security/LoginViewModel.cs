using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Security
{
    public class LoginViewModel
    {
        
        public string UserName { get; set; }
       
        public string PassWord { get; set; }
    }
}
