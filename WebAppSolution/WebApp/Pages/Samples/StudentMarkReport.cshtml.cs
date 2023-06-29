using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models; //the namespace of your source code
using System.IO;

namespace WebApp.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }

        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();

        // dependency injection (constructor injection technique)
        // a) create a constructor for your pagemodel class
        // b) the services you wish to inject will be parameters on the constructor
        // c) save the incoming parameter values in a public property

        public IWebHostEnvironment _webHostEnvironment { get; set; }
        public StudentMarkReportModel(IWebHostEnvironment env) 
        { 
            _webHostEnvironment = env;
        }
        public void OnGet()
        {
            //the student mark report will be loaded as the page comes up for the
            //  first time.
            //therefore, all code will be in the OnGet() event

            //get the path to your web app root
            string contentPathname = _webHostEnvironment.ContentRootPath;
            string filePathname = Path.Combine(contentPathname, @"Data\StudentMarks.txt");

            //userdata will contain all of the data file records in an array
            Array userdata = null;

            //to Parse the csv record into an instance of our class, I have setup
            //  a reusable variable capable of hold an instance of the class.
            StudentMarks markRecord = null;

            try
            {
                //There is a File class in PageModel
                //to use the File class of System.IO you MUST fully qualify your
                //  reference to the class when coding the read method.
                userdata = System.IO.File.ReadAllLines(filePathname);

                //process each record in the record array
                //each record could possibly throw an exception while Parsing
                //you should process all possible record while reporting records
                //    that could not be parsed
                foreach(string line in userdata)
                {
                    try
                    {
                        markRecord = StudentMarks.Parse(line);
                        if (markRecord != null)
                        {
                            studentMarks.Add(markRecord);
                        }
                    }
                    catch(FormatException ex)
                    {
                        ModelState.AddModelError("Record Format", $"{GetInnerException(ex).Message}: record {line}");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("System Error", $"{GetInnerException(ex).Message}: record {line}");
                    }
                }
              

            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("File Data", $"{GetInnerException(ex).Message}");
            }

        }

        public Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
