using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    // An abstract class that inherits from Person and provides varibales and methods for staff.
     abstract public class Staff : Person
     {
        string _office;
                
        public Staff(string name, int ID, DateTime dob, string homeAddress, string office)
            : base(name, ID, dob, homeAddress)
        {
            Office = office;
        }
        # region Properties
        public string Office
        {
            get { return _office; }
            set { _office = value; }
        }

        // Accessor for the ID number, only accepts int 7 digits long.
        public override int IdentificationNumber
        {
            get
            {
                return base.IdentificationNumber;
            }
            set
            {
                if (value.ToString().Length == 7)
                {
                    base.IdentificationNumber = value;
                }
                else
                {
                    throw new ArgumentException("Staff ID number must be 7 digits.");
                }
            }
        }
        # endregion
    }
}
