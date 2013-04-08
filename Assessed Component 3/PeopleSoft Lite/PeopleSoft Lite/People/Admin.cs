using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    public class Admin : Staff
    {
        string _role;

        /// <summary>
        /// Creates a new instance of an Admin staff.
        /// </summary>
        public Admin(string name, int ID, DateTime dob, string homeAddress, string office, string role)
            : base(name, ID, dob, homeAddress, office)
        {
            Role = role;
        }

        // The role this person has at the university.
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        // returns an array of strings containing the details stored for this admin staff.
        override public string[] GetDetails()
        {
            string[] output = new string[6];
            output[0] = Name;
            output[1] = IdentificationNumber.ToString();
            output[2] = DateOfBirth.ToString("dd/MM/yyyy");
            output[3] = Address;
            output[4] = Office;
            output[5] = Role;
            return output;
        }
    }
}
