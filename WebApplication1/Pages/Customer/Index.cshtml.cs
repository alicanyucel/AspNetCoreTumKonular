using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            //onget ilk �al��an metot main metodu olarak d���nebilirsiniz.
            Message = "tarih:" + DateTime.Now.ToString();
        }
    }
}
