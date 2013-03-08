using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assesment
{
    class Address
    {
        int _streetNum;
        string _street;
        string _street2;
        string _street3;
        string _town;
        string _county;
        string _postCode;

        public int StreetNum
        {
            get { return _streetNum; }
            set { _streetNum = value; }
        }        

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }        

        public string Street2
        {
            get { return _street2; }
            set { _street2 = value; }
        }        

        public string Street3
        {
            get { return _street3; }
            set { _street3 = value; }
        }        

        public string Town
        {
            get { return _town; }
            set { _town = value; }
        }        

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }        

        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }
    }
}
