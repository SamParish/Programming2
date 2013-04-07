using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    public class Student : Person
    {
        string _termAddress;
        Programme _programOfStudy;
        int _yearOfStudy;
        // Modules studdied this term.
        List<Module> _modulesList;

        /// <summary>
        /// Creates a new instance of Student.
        /// </summary>
        /// <param name="name">The name of the student deliminated by a space.</param>
        /// <param name="ID">The students Identifiaction Number.</param>
        /// <param name="dob">The students date of birth.</param>
        /// <param name="homeAddress">The students home address.</param>
        /// <param name="termAddress">The students term time address.</param>
        /// <param name="programOfStudy">What program the student is studying.</param>
        /// <param name="yearOfStudy">On which year of their course the student is on.</param>
        /// 
        public Student(string name, int ID, DateTime dob, string homeAddress, string termAddress, Programme programOfStudy, int yearOfStudy)
            : base(name, ID, dob, homeAddress)
        {
            _termAddress = termAddress;
            ProgramOfStudy = programOfStudy;
            _yearOfStudy = yearOfStudy;
            _modulesList = new List<Module>();
            foreach (Module module in programOfStudy.ModulesList)
            {
                AddModule(module);
            }
        }

        public override int IdentificationNumber
        {
            get
            {
                return base.IdentificationNumber;
            }
            set
            {
                if (value.ToString().Length == 9)
                {
                    base.IdentificationNumber = value;
                }
                else
                {
                    throw new ArgumentException("Student ID number must be 9 digits.");
                }
            }
        }

        public string TermAddress
        {
            get { return _termAddress; }
            set { _termAddress = value; }
        }        

        public Programme ProgramOfStudy
        {
            get { return _programOfStudy; }
            set 
            {
                if (ProgramOfStudy != value)
                {
                    if (ProgramOfStudy != null)
                    {
                        ProgramOfStudy.RemoveStudent();
                    }
                    _programOfStudy = value;
                    value.AddStudent();
                }
            }
        }
        
        public int YearOfStudy
        {
            get { return _yearOfStudy; }
            set { _yearOfStudy = value; }
        }
        
        public List<Module> ModulesList
        {
            get { return _modulesList; }
        }

        public void AddModule(Module module)
        {
            ModulesList.Add(module);
            module.NumOfStudents++;
        }

        public void RemoveModule(Module module)
        {
            ModulesList.Remove(module);
            module.NumOfStudents--;
        }

        override public string[] GetDetails()
        {
            string[] output = new string[7];
            output[0] = Name;
            output[1] = IdentificationNumber.ToString();
            output[2] = DateOfBirth.ToString("dd/MM/yyyy");
            output[3] = Address;
            output[4] = TermAddress;
            output[5] = ProgramOfStudy.Name;
            output[6] = YearOfStudy.ToString();

            return output;
        }
    }
}
