using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electric : Engine
    {
        public Electric(float i_MaxEngineCapacity) : base(i_MaxEngineCapacity) 
        {

        }

        public override string ToString()
        {
            string message;
            message = string.Format(@"Battery Maximum capacity: {0}h
Current battery capacity: {1:0.00}h", MaxCapacity, CurrentEnergy);
            return message;
        }


        public void ChargeBattery(float i_AmountOfHours)
        {
            if(this.CurrentEnergy + i_AmountOfHours >this.MaxCapacity || this.CurrentEnergy + i_AmountOfHours < 0)
            {
                throw new ValueOutOfRangeException(0, this.MaxCapacity);
            }
            this.CurrentEnergy += i_AmountOfHours;
        }
        //public override void fillVechile(float i_EnergyAmount)
        //{
        //    if (this.CurrentEnergy + i_EnergyAmount > this.MaxCapacity || this.CurrentEnergy + i_EnergyAmount  < 0)
        //    {
        //        throw new ValueOutOfRangeException(0, this.MaxCapacity);
        //    }
        //    else
        //    {
        //        this.CurrentEnergy += i_EnergyAmount / 60;
        //    }
        //}
    }
}
