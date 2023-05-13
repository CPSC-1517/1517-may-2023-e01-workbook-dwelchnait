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
    }
}