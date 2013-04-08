using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    // A modification of List<Person> that allows all the styaff to be returned and all the students to be returned.
    class PeopleList : List<Person>
    {
        // Gets all the studnets....
        public IEnumerable<Person> GetAllStudents()
        {            
            foreach (Person currentPerson in this)
            {
                if (currentPerson is Student)
                {
                    yield return (Student)currentPerson;
                }
            }
        }

        // Gets all the staff....
        public IEnumerable<Person> GetAllStaff()
        {            
            foreach (Person currentPerson in this)
            {
                if (currentPerson is Staff)
                {
                    yield return (Staff)currentPerson;
                }
            }
        }
    }
}
