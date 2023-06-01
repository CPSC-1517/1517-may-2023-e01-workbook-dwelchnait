using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName 
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("first name is required");
                }
                _FirstName = value;
            } 
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("last name is required");
                }
                _LastName = value;
            }
        }
        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public string FullName { get { return LastName + ", " + FirstName; } }

        public int NumberOfEmployments { get { return EmploymentPositions.Count(); } }

        public Person(string firstname, string lastname, Residence address, List<Employment> employmentpositions)
        {
            
          
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions;  //store the supplied list of employments
            }
         
        }

        

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";

        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException("Employment record position is required.");
            }
            EmploymentPositions.Add(employment);
        }
    }
}
