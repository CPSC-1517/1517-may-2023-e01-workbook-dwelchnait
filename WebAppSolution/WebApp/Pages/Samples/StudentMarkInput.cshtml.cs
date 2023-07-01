using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Pages.Samples
{
    public class StudentMarkInputModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }
        public IWebHostEnvironment _webHostEnvironment { get; set; }

        public List<Assessment> assessmentList { get; set; } = new List<Assessment>();
        public StudentMarks studentRecord { get; set; }
      
        [BindProperty]
        public string? FirstName { get; set; }
        [BindProperty]
        public string? LastName { get; set; }

        [BindProperty]
        public int Assessment { get; set; }

        [BindProperty]
        public int AssessmentVersion { get; set; }

        [BindProperty]
        public double Mark { get; set; }

        public StudentMarkInputModel(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
        public void OnGet()
        {
           PopulateAssessment();
        }
      
        public void PopulateAssessment()
        {
            //this is to simulate obtaining data that could come from a table in a database
            assessmentList.Add(new Assessment() { Id = 1, Description="Exercise" });
            assessmentList.Add(new Assessment() { Id = 2, Description="Lab" });
            assessmentList.Add(new Assessment() { Id = 3, Description="Assessment" });
            assessmentList.Add(new Assessment() { Id = 4, Description="Project" });
            assessmentList.Add(new Assessment() { Id = 5, Description="Quiz" });

            //x and y represent any two records in your collection at any point in time
            //.CompareTo will compare the property on each record
            //the default Sort is ascending x , y
            //to do a descending sort switch x.property.CompareTo(y.property) around so
            //   it would appears y.property.CompareTo(x.property)
            assessmentList.Sort((x,y) => x.Description.CompareTo(y.Description));

        }

        public IActionResult OnPostRecord()
        {
           
           
            return Page();
        }
        public IActionResult OnPostClear()
        {
            ModelState.Clear();
            FirstName = null;
            LastName = null;
            Assessment = 0;
            AssessmentVersion = 0;
            Mark = 0;
            //since the server does not remember anything that was done on this page
            //      the last time it was processed, you are required ensure all required
            //      data for the page is present
            PopulateAssessment();
            return Page();
        }
        public IActionResult OnPostRedirectToReport()
        {

            return RedirectToPage("StudentMarkReport");
        }
    }
}
