using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    abstract public class Person : IPerson
    {
        string _forename;
        string _surname;
        int _identificationNumber;
        DateTime _dateOfBirth;
        string _address;

        // Base constructor for decendant classes.
        public Person(string name, int ID, DateTime dob, string address)
        {
            ChangeName(name);
            IdentificationNumber = ID;
            _dateOfBirth = dob;
            Address = address;
        }
        # region Properties
        public string Forename
        {
            get { return _forename; }
        }

        public string Surname
        {
            get { return _surname; }
        }

        public string Name
        {
            get { return _forename + " " + _surname; }
        }

        virtual public int IdentificationNumber
        {
            get { return _identificationNumber; }
            set { _identificationNumber = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
        }

        public void SetDoB(string input)
        {
            string[] splitInput = input.Split('/');
            int[] dateInput = new int[splitInput.Length];
            for (int i = 0; i < splitInput.Length; i++)
            {
                if (!int.TryParse(splitInput[i], out dateInput[i]) || splitInput.Length != 3)
                {
                    throw new FormatException("Please enter the date in the format dd/mm/yyyy.");
                }
            }
            try
            {
                _dateOfBirth = new DateTime(dateInput[2], dateInput[1], dateInput[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new FormatException("Please enter the date in the format dd/mm/yyyy.");
            }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        # endregion

        /// <summary>
        /// Takes a string and splits it into substrings deliminated by a space.
        /// Sets forename to the first substring and surname to the second.
        /// </summary>
        public void ChangeName(string newName)
        {
            string[] splitName = newName.Split(' ');
            if (splitName.Length < 2)
            {
                throw new FormatException("A person must have a forename and a surname seperated by spaces.");
            }
            else
            {
                _forename = splitName[0];
                _surname = splitName[splitName.Length - 1];
            }
        }

        /// <summary>
        /// Returns true if the persons name contains the search term.
        /// </summary>
        public bool HasName(string name)
        {
            name = name.ToLower();
            return Forename.ToLower().Contains(name) || Surname.ToLower().Contains(name);
        }
        ///<summary>
        /// Returns true if the ID searched matches exactly the persons ID.
        /// </summary>
        public bool HasID(int id)
        {
            return IdentificationNumber == id;
        }

        /// <summary>
        /// Returns the data contained within the class as an array of strings.
        /// </summary>
        virtual public string[] GetDetails()
        {
            string[] output = new string[4];
            output[0] = Forename;
            output[1] = Surname;
            output[2] = IdentificationNumber.ToString();
            output[3] = DateOfBirth.ToString();
            output[4] = Address;

            return output;
        }
    }
}
