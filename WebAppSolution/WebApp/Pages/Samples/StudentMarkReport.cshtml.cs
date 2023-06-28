using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models; //the namespace of your source code

namespace WebApp.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }

        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();
        public void OnGet()
        {
        }
    }
}
