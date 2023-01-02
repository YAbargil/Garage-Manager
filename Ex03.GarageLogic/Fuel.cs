using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : Engine
    {

        private readonly eFuelType r_FuelType;
        public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98,
        }

        public enum eFuelTankCapacity
        {
            Motorcycle =6,
            Car = 50,
            Truck = 120,
        }

        public Fuel(float i_MaxEngineCapacity,float i_FuelType) : base(i_MaxEngineCapacity) {
            r_FuelType = (eFuelType)i_FuelType;

        }

        public eFuelType FuelType
        {
            get { return r_FuelType; }
           // set { r_FuelType = value; }
        }

        //public eFuelTankCapacity FuelTankCapacity
        //{
        //    get { return r_FuelTankCapacity; }
        //    //set { m_FuelTankCapacity = value; }
        //}

        public void CheckFuelType(eFuelType i_FuelType)
        {
            if (r_FuelType != i_FuelType)
            {
                throw new ArgumentException("ArgumentException: Your fuel type is not match");
            }
        }

        public override string ToString()
        {
            string message;
            message = string.Format(@"Fuel tank maximum capacity: {0}
Current fuel tank capacity: {1:0.00}L
Fuel type: {2}",
this.MaxCapacity, this.CurrentEnergy,this.r_FuelType);
            return message;
        }
       
    }
}
