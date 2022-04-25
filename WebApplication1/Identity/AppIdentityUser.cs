using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Identity
{
    public class AppIdentityUser:IdentityUser
    {
        public int Age { get; set; }
        
    }
}
