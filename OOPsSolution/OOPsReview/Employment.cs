using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        /// <summary>
        /// data members for the class
        /// </summary>
        private SupervisoryLevel _Level;
        private string _Title;      //default of a string is null
        private double _Years;      //default of a numeric is 0

        /// <summary>
        /// Properties
        /// 
        /// are associated with a single piece of data.
        /// Properties can be implemented by:
        ///   a) fully implemented properties
        ///   b) auto implemented properties
        ///   
        /// Fully implemented property usually has additional logic to execute for
        ///     the control over the data; such as validation
        /// Fully implemented properties will have a declared data member to store the data 
        /// 
        /// Auto implemented properties do not have additional logic
        /// Auto implemented properties do not have a declared data member to
        ///     store the data instead the o/s will create on the property's behave a
        ///     storage area that is accessable ONLY by using the property
        ///     
        /// </summary>

        /// <summary>
        /// PropertY: Title
        /// validation: there must be a character string
        /// a property will always have an accessor (get)
        /// a property may or may not have a mutator
        ///     no mutator the property is consider "read-only" and is usually
        ///         returning a computed value:
        ///         example a FullName  made up of 2 pieces of data FirstName and Lastname
        ///     has a mutator the property will a some point save the data to storage
        ///     the mutator may be public (default) or private
        ///          public: accessable by outside users of the class
        ///          private: accessable ONLY within the class
        ///  a property DOES NOT have ANY declare incoming parameter list!!!!!
        ///  </summary> 
        
        public string Title 
        { 
            //referred to as the accessor
            //returns the string associated with this property
            get { return _Title; } 
            //referred to as the mutator
            //it is within the set that the validation of the data
            //  is done to determine if the data is acceptable
            //by default set is public
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                //else
                //{
                    _Title = value;
                //}
            }
        }

        public  SupervisoryLevel Level
        {
            get { return _Level; }
            private set
            {
                //a private set means that the property can only be set
                //  by code within the class definition
                //an advantage of doing this is increaseing security on the
                //  field as any change is under the control of the class definition
                //
                //validate tha the value given as an enum is actually defined
                //
                //a user of this class could send in an integer value that was
                //  type casted as this enum datatype BUT have a non-defined value
                //
                //to test for a defined enum value use Enum.IsDefined(typeof(xxxx), value)
                //  where xxxx is the name of the enum datatype
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value)) 
                {
                    throw new ArgumentException($"Supervisory level is invalid: {value}");
                }
                _Level = value;
            }
        }

        //validate the years of service in the employee position as a positive value.

        public double Years
        {
            get { return _Years; } //used on the right side of an assignment statement or in an expression
            set                   //used on the left side of an assignment statement
            {
                //if ( value < 0 ) //using a Utilities generic method to do this test
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _Years = value;
            }
        }

        //this property is an example of an auto-implemented property
        //there is no validation within the property
        //there is NO private data member for this property
        //the system will generate an internal storage area for the data
        //      and handle the setting and getting from that storage area
        //the private set means that the property will only be able to be
        //      set via a constructor or method.
        //auto-implemented properties can have either a public or private set
        //using a public or private set is a design decision
        public DateTime StartDate { get; private set; }


    }
}