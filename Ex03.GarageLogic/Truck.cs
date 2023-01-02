using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_AmountOfTires = 41;
        private bool m_ContainsDangerousMaterials;
        private float m_CargoVolume;

        public Truck(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType,
              string i_TireManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
              : base(i_ModelName, i_LicensePlate, i_EngineType, i_TireManufacturerName, k_AmountOfTires, i_CurrentAirPressure,
                    (float)Tire.eMaxAirPressure.Truck, (float)Fuel.eFuelTankCapacity.Truck, (float)Fuel.eFuelType.Soler, 0f)

        {
            FillAndSetVechile(i_CurrentEnergyAmount);
        }

        public float VolumeOfCargo
        {
            get { return m_CargoVolume; }
        }

        public bool IsContainDangerousMaterials
        {
            get { return m_ContainsDangerousMaterials; }
        }



        public void SetTruckDetails(bool i_IsDangerous,float i_CargoWeight)
        {
            this.m_CargoVolume = i_CargoWeight;
            this.m_ContainsDangerousMaterials = i_IsDangerous;
        }
        public override void FillAndSetVechile(float i_CurrentEnergyAmount)
        {
            Engine.SetEnergy(i_CurrentEnergyAmount);
            CalculateEnergyPercent();
        }

        public override string ToString()
        {
            string truckInformation;
            truckInformation = string.Format(@"{0}
Is transport dangerous materials : {1}
Volume of cargo: {2}
", VehicleData(), m_ContainsDangerousMaterials.ToString(), m_CargoVolume);
            return truckInformation;
        }
    }
}
