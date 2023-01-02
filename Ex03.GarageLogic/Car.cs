using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private  eColor m_Color;
        private  eDoorsNumber m_DoorsNumber;
        private const int k_AmountOfTires = 5;
        private const float k_FullBatteryCapacity = 4.7f;

        public enum eColor
        {
            Red = 1,
            Green,
            White,
            Gray,
        }

        public enum eDoorsNumber
        {
            Two = 1,
            Three,
            Four,
            Five,
        }

        public eColor CarColor
        {
            get { return m_Color; }
            //set { m_Color = value; }
        }

        public eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber; }
            //set { m_DoorsNumber = value; }
        }

        public Car(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType,
           string i_TireManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
           : base(i_ModelName, i_LicensePlate, i_EngineType, i_TireManufacturerName, k_AmountOfTires, i_CurrentAirPressure,
                 (float)Tire.eMaxAirPressure.Car, (float)Fuel.eFuelTankCapacity.Car, (float)Fuel.eFuelType.Octan95, k_FullBatteryCapacity)
        {
            FillAndSetVechile(i_CurrentEnergyAmount);
        }


        public override void FillAndSetVechile(float i_CurrentEnergyAmount)
        {
            Engine.SetEnergy(i_CurrentEnergyAmount);
            CalculateEnergyPercent();
        }



        public void SetCarDetails(int i_UserSelectionDoorAmount, int i_UserSelectionColor)
        {
            this.m_Color= (eColor)i_UserSelectionColor;
            this.m_DoorsNumber = (eDoorsNumber)i_UserSelectionDoorAmount;
        }
        public override string ToString()
        {
            string carInformation;
            carInformation = string.Format(@"{0}
Car color: {1}
Car doors' number: {2}
",
VehicleData(), m_Color.ToString(), m_DoorsNumber.ToString());
            return carInformation;
        }
    }
}
