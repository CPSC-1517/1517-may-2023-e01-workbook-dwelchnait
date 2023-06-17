using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // form controls properties
        public double Num { get; set; }

        public string MassText { get;set; }
        public void OnGet()
        {
        }
    }
}
