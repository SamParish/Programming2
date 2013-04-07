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

        public void AddProgrammeLed(Programme programme)
        {
            ProgrammesLed.Add(programme);
            if (programme.ProgramLeader != this)
            {
                programme.ProgramLeader = this;
            }
        }

        public void RemoveProgrammeLed(Programme programme)
        {
            ProgrammesLed.Remove(programme);
        }

        public void AddModuleLed(Module module)
        {
            ModulesLed.Add(module);
            if (module.ModuleLeader != this)
            {
                module.ModuleLeader = this;
            }
        }

        public void RemoveModuleLed(Module module)
        {
            ModulesLed.Remove(module);
        }

        public Academic(string name, int ID, DateTime dob, string homeAddress, string office, string school)
            : base (name, ID, dob, homeAddress, office)
        {
            School = school;
            _programmesLed = new List<Programme>();
            _modulesLed = new List<Module>();
        }

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
