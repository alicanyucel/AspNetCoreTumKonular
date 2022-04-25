using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : Controller
    {
        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        [HttpGet]
        [Route("get")]
        public List<Customer> Get()
        {
            return new List<Customer>
            {
                new Customer{Id=1,FirstName="ali can",LastName="yucel"},
                new Customer{Id=1,FirstName="ahmet",LastName="yuksel"},
                new Customer{Id=1,FirstName="akin",LastName="yuce"},
            };
        }
    }
}