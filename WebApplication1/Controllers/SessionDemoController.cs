using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.ExtensionsMethods;

namespace WebApplication1.Controllers
{
    public class SessionDemoController : Controller
    {
        public string Index()
        {
              HttpContext.Session.SetInt32("age",29);
              HttpContext.Session.SetString("name","alican");
              HttpContext.Session.SetObject("student",new Student { Email = "yucelalican@hotmail.com", FirstName = "ali can", LastName = "yucel", Id = 1 });
              return "oturum olusturuldu";


        }
        public string GetSessions()
        {
             return string.Format("merhaba {0}, you are:{1} Student is {2}",HttpContext.Session.GetString("name"),HttpContext.Session.GetInt32("age"),HttpContext.Session.GetObject<Student>("student").FirstName);
             
        }
    }
}
