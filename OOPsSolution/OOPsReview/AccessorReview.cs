using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public  class AccessorReview
    {
        //this class will be used to review the how an accessor
        //  can be used to control access to calculate a value

        //on a property
        // the get returns a value to the calling client
        //      the value is the data associated with the property
        //      the get can have logic to calculate the return value
        // the set receives a value from the calling client
        //      the incoming value is placed into a data hold
        //      the set can have logic to validate the incoming data
        public int Number1 { get; set; }  //auto implemented property
        public int Number2 { get; private set; }
        public int Add 
        { 
            get
            {
                return Number1 + Number2;
            }
            set { }   
        }

        public void SetNumber2(int value)
        {
           
                Number2 = value;
            
        }
    }
}
