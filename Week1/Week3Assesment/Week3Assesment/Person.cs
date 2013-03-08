using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assesment
{
    class Person
    {
        //TODO: Add error checking for all values. 

        string _name;
        int _age;
        Address _address;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }        

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }        

        internal Address Address
        {
            get { return _address; }
            set { _address = value; }
        }


    }
}
