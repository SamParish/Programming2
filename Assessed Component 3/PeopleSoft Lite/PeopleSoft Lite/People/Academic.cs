using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    public class Academic : Staff
    {
        string _school;
        List<Module> _modulesLed;
        List<Programme> _programmesLed;

        /// <summary>
        /// Creates a new instance of an academic staff member.
        /// </summary>
        /// <param name="name">Name of the Academic</param>
        /// <param name="ID">Academics ID number, 7 digits long.</param>
        /// <param name="dob">Date of birth in dd/mm/yyyy format.</param>
        /// <param name="homeAddress">Home address.</param>
        /// <param name="office">The academics office.</param>
        /// <param name="school">To which school they belong in the university.</param>
        public Academic(string name, int ID, DateTime dob, string homeAddress, string office, string school)
            : base(name, ID, dob, homeAddress, office)
        {
            School = school;
            _programmesLed = new List<Programme>();
            _modulesLed = new List<Module>();
        }

        # region Properties 
        public string School
        {
            get { return _school; }
            set { _school = value; }
        }
        
        public List<Module> ModulesLed
        {
            get { return _modulesLed; }
        }        

        public List<Programme> ProgrammesLed
        {
            get { return _programmesLed; }
        }
        # endregion

        // Sets this Academic to lead a program, removes this program from old leader and updates the programmes to reflect these changes.
        public void AddProgrammeLed(Programme programme)
        {
            if (!ProgrammesLed.Contains(programme))
            {
                ProgrammesLed.Add(programme);
                if (programme.ProgramLeader != this)
                {
                    programme.ProgramLeader = this;
                }
            }
        }

        // Removes a programme from this academic.
        public void RemoveProgrammeLed(Programme programme)
        {
            ProgrammesLed.Remove(programme);
        }

        // Sets this Academic to lead a module, removes this module from old leader and updates the modules to reflect these changes.
        public void AddModuleLed(Module module)
        {
            if (!ModulesLed.Contains(module))
            {
                ModulesLed.Add(module);
                if (module.ModuleLeader != this)
                {
                    module.ModuleLeader = this;                
                }       
            }
        }
        // Removes the module from this academic.
        public void RemoveModuleLed(Module module)
        {
            ModulesLed.Remove(module);
        }       

        // returns an array of strings containing the details stored for this academic.
        override public string[] GetDetails()
        {
            string[] output = new string[8];
            output[0] = Name;
            output[1] = IdentificationNumber.ToString();
            output[2] = DateOfBirth.ToString("dd/MM/yyyy");
            output[3] = Address;
            output[4] = Office;
            output[5] = School;

            StringBuilder builder = new StringBuilder();
            foreach (Module module in ModulesLed)
            {
                builder.Append(module.Name);
            }
            output[6] = builder.ToString();

            builder.Clear();
            foreach (Programme programme in ProgrammesLed)
            {
                builder.Append(programme.Name);
            }
            output[7] = builder.ToString();

            return output;
        }
    }
}
