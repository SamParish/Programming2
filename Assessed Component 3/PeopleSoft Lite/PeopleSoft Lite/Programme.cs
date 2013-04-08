using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    public class Programme
    {
        string _name;
        List<Module> _modulesList;
        Academic _programLeader;
        int _length, _numOfStudents;

        /// <summary>
        ///  Constructs a new university programme.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="programmeLeader">The academic staff member who leads the course.</param>
        /// <param name="length">The lenth of the course in years.</param>
        public Programme(string name, Academic programmeLeader, int length)
        {
            Name = name;
            ProgramLeader = programmeLeader;
            Length = length;
            _modulesList = new List<Module>();
        }
        # region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }        

        internal List<Module> ModulesList
        {
            get { return _modulesList; }
            set { _modulesList = value; }
        }        

        // Sets the ProgramLeader. If there was already a prorgam leader and its different to the new one
        // remove this program from his list of Programs led.
        public Academic ProgramLeader
        {
            get { return _programLeader; }
            set 
            {
                if (ProgramLeader != null && ProgramLeader != value)
                {
                    ProgramLeader.RemoveProgrammeLed(this);
                    _programLeader = value;
                    value.AddProgrammeLed(this);
                }
                else if (ProgramLeader != value)
                {
                    _programLeader = value;
                    value.AddProgrammeLed(this);
                }
            }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public int NumOfStudents
        {
            get { return _numOfStudents; }
        }
        # endregion

        // Increments teh number of students
        public void AddStudent()
        {
            _numOfStudents++;
        }

        // decrements the number of students
        // unused as no way to remove students from a course...
        internal void RemoveStudent()
        {
            _numOfStudents--;
        }
    }
}
