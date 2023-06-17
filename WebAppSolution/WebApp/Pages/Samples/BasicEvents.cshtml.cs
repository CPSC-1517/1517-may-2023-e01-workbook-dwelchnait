using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        // page properties
        public string FeedBack { get; set; }  //public property within the class
                                              //that can be used in the cshtml page
        private Random random = new Random(); //private field within the class

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

        /*************************************************
         *          
         * OnPost is a method that is call by default if the
         *        submit button is clicked AND there is no code for the specific
         *        event handler for the button
         *                                   
         *    Remember that the internet is a state-less enivornment
         *    That means the any web page that is requested exists in
         *       memory for as long a the page is executing code
         *    After the page is sent to the user's browser, the system
         *          does NOT know about the page
         *          
         *************************************************/
        //public void OnPost()
        public void OnPostFirstButton()
        {
            int oddeven = random.Next(1, 101);
            if (oddeven % 2 == 0)
            {
                FeedBack = $"Your value {oddeven} is even.";
            }
            else
            {
                FeedBack = $"Your value {oddeven} is odd.";
            }
        }

        //this event will execute in response to a button on the
        //  form that has asp-page-handler parameter set to the
        //  appended name on OnPost
        public void OnPostSecondButton()
        {
            FeedBack = "You clicked the second button and there is a coded event for the button page handler name";
        }
    }
}
