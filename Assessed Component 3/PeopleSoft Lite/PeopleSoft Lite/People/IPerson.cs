using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SoftPeople_Lite
{
    /// <summary>
    /// This interface is designed to provide access to key information for
    /// any Person that is stored within the SoftPeople system.
    /// </summary>
    interface IPerson
    {
        #region Properties

        string Forename {get;}
        string Surname {get;}
        int IdentificationNumber {get;set;}
        DateTime DateOfBirth {get;}
        string Address {get;set;}

        #endregion

        #region Methods
        /// <summary>
        /// Change the name of this Person
        /// </summary>
        /// <param name="newName">The full new name</param>
        void ChangeName(string newName);
        #endregion
    }
}
