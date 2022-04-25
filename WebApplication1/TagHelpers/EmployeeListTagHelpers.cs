using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelpers : TagHelper
    {
        private List<Employee> _employees;
        public EmployeeListTagHelpers()
        {
            _employees = new List<Employee>
            {
                new Employee{ Id=1,FirstName="ali can",LastName="yucel",CityId=1},
                new Employee{ Id=2,FirstName="ahmet can",LastName="yucel",CityId=2},
                new Employee{ Id=3,FirstName="aras can",LastName="yucel",CityId=3 },
                new Employee{ Id=4,FirstName="necla can",LastName="yucel",CityId=4 },
                new Employee{ Id=5,FirstName="polat can",LastName="yucel",CityId=5},
                new Employee{ Id=6,FirstName="caner can",LastName="yucel",CityId=6 }
            };
        }
        private const string ListCountAttributeName="count";
        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var querry = _employees.Take(ListCount);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var employee in querry)
            {
                stringBuilder.AppendFormat("<h2><a href='/employee/details/{0}'>{1}</a></h2>",employee.Id,employee.FirstName);
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);  
        }
    }
}