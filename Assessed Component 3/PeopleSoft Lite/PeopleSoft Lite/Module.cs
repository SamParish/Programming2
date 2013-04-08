using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    public class Module
    {
        string _name;
        Academic _moduleLeader;
        int _numOfStudents;

        // An instance of module that keeps track of the number of students that are enrolled and who leads the module.
        public Module(string name, Academic moduleLeader)
        {
            Name = name;
            ModuleLeader = moduleLeader;
            NumOfStudents = 0;
        }

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }        

        public Academic ModuleLeader
        {
            get { return _moduleLeader; }
            set 
            {
                if (ModuleLeader != null && ModuleLeader != value)
                {
                    ModuleLeader.RemoveModuleLed(this);
                    _moduleLeader = value;
                    value.AddModuleLed(this);
                }
                else if (ModuleLeader != value)
                {
                    _moduleLeader = value;
                    value.AddModuleLed(this);
                }
            }
        }

        public int NumOfStudents
        {
            get { return _numOfStudents; }
            set { _numOfStudents = value; }
        }
        # endregion
    }
}