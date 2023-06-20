using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // form controls properties
        //it is the asp-for that links the form control to the property
        //PROBLEM:
        // if a property does NOT have a [BindProperty] attribute,
        //      the value of the property is not updated when the form is submitted
        //      the property is considered as a read-only property (one way binding)
        //      the property value is "out going only" (from the server to the client)

        //[BindProperty] this attribute is not required
        //HOWEVER: if you wish to receive data from your client (form) into the server
        //            (PageModel) you MUST have the [BindProperty] attribute on the property
        //         the property will be a two-way binding
        //         the property values is BOTH "out going" and "in coming"

        [BindProperty]
        public double Num { get; set; }

        [BindProperty]
        public string MassText { get;set; }

        [BindProperty]
        public int FavouriteCourse { get; set; } //using integer value from select

        [BindProperty]
        public string FavouriteCourseNoValueOnOption { get; set; } //using string text from select

        public string FeedBack { get; set; } //one way property for messages
        public void OnGet()
        {
        }

        public void OnPostControlProcessing()
        {
            FeedBack = $"Number value is {Num}"
                     + $" Mass text is {MassText}"
                + $" Favourite course with value is {FavouriteCourse}"
                + $" Favourite course without value is {FavouriteCourseNoValueOnOption}";
        }
    }
}
