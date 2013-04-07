using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftPeople_Lite
{
    class PeopleList : List<Person>
    {
        public IEnumerable<Person> GetAllStudents()
        {
            // Gets all the studnets....
            foreach (Person currentPerson in this)
            {
                if (currentPerson is Student)
                {
                    yield return (Student)currentPerson;
                }
            }
        }

        public IEnumerable<Person> GetAllStaff()
        {
            // Gets all the staff....
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
