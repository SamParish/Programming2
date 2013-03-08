using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Assesment
{
    class Vehicle
    {
        string _type;
        string _model;
        int _wheelNo;
        bool _isLandVehicle;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }        

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }        

        public int WheelNo
        {
            get { return _wheelNo; }
            set { _wheelNo = value; }
        }        

        public bool IsLandVehicle
        {
            get { return _isLandVehicle; }
            set { _isLandVehicle = value; }
        }
    }
}
