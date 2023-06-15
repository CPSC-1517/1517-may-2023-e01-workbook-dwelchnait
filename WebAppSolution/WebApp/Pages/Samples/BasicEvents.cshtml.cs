using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        // page properties
        public string FeedBack { get; set; }

        /*************************************************
         * 
         * OnGet is a method that is call each and every time
         *    this page is created
         *    this page is call first when the page is retrieved
         *    
         * Remember that the internet is a state-less enivornment
         * That means the any web page that is requested exists in
         *    memory for as long a the page is executing code
         *    After the page is sent to the user's browser, the system
         *      does NOT know about the page
         ************************************************/ 
        public void OnGet()
        {
            FeedBack = "in OnGet";
        }
    }
}
