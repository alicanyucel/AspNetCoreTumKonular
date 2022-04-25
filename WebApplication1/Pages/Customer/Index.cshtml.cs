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
            //onget ilk çalışan metot main metodu olarak düşünebilirsiniz.
            Message = "tarih:" + DateTime.Now.ToString();
        }
    }
}
