using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicensePlate;
        private float m_EnergyPercent;
        private readonly List<Tire> r_Tires;
        private readonly Engine r_Engine;

        public enum eVehiclesType
        {
            Car = 1,
            Motorcycle,
            Truck,
        }

        public Vehicle(string i_CarModelName, string i_LicensePlate, Engine.eEngineType i_EngineType, 
            string i_WheelManufacturerName,int i_AmountOfTires,float i_CurrentAirPressure,float i_MaxAirPressure,float i_FuelCapacity,float i_FuelType,float i_ElectricCapacity)
        {
            r_ModelName = i_CarModelName;
            r_LicensePlate = i_LicensePlate;
            r_Tires = new List<Tire>();
             for (int i = 0; i < i_AmountOfTires; i++)
            {
                r_Tires.Add(new Tire(i_WheelManufacturerName, i_MaxAirPressure, i_CurrentAirPressure));
            }
            if (i_EngineType == Engine.eEngineType.Fuel)
            {
                r_Engine = new Fuel(i_FuelCapacity, i_FuelType);
            }
            else
            {
                r_Engine = new Electric(i_ElectricCapacity);
            }
        }
        public List<Tire> Tires
        {
            get { return r_Tires; }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public float EnergyPercent
        {
            get { return m_EnergyPercent; }
            set { m_EnergyPercent = value; }
        }

        public void CalculateEnergyPercent()
        {
            float calculatedEnergyPercent = Engine.CurrentEnergy / Engine.MaxCapacity;
            EnergyPercent = calculatedEnergyPercent;
        }

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }

        public abstract void FillAndSetVechile(float i_CurrentEnergyAmount);

        public string VehicleData()
        {
            CalculateEnergyPercent();
            string vehicleData = string.Format(@"Vehicle model name: {0}
Vehicle license plate number: {1}
Energy percentage: {2:0.00}%
{3}
{4}",
r_ModelName, r_LicensePlate, EnergyPercent*100, r_Tires[0].ToString(), r_Engine.ToString());
            return vehicleData;
        }


        public static Vehicle CreateVehicle(string i_LicensePlate, string i_ModelName, string i_WheelManufacturer,
                                            Engine.eEngineType i_EngineType, eVehiclesType i_VehiclesType, 
                                            float i_CurrentAirPressure, float i_CurrentEnergyAmount)
        {
            Vehicle newVehicle = null;
            switch (i_VehiclesType)
            {
                case eVehiclesType.Car:
                   newVehicle = new Car(i_ModelName, i_LicensePlate, i_EngineType, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break;
                case eVehiclesType.Motorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, i_EngineType, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break;
                case eVehiclesType.Truck:
                    newVehicle = new Truck(i_ModelName, i_LicensePlate, i_EngineType, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break;
            }

            return newVehicle;
        }

    }
}

        //string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType,
        //string i_TireManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount,int i_MotorcycleLicenseType,int i_MotorcycleVolume)

        //    X           X             X           X 
        //vehicleModel, licensePlate, engineType, tireManufacturer
        //                           , currentAirPressure, currentAirPressure, userSelectionMotorcycleLicense, userMotorcycleVolume
        //public static Vehicle CreateMotorcycle(string i_LicensePlate, string i_ModelName, string i_TireManufacturer,
        //                                   Engine.eEngineType i_EngineType,
        //                                   float i_CurrentAirPressure, float i_CurrentEnergyAmount,int i_MotorcycleLicense,int i_MotorcycleVolume)
        //{
        //    Vehicle newVehicle = null;
        //    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, i_EngineType, i_TireManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount,i_MotorcycleLicense,i_MotorcycleVolume);
        //    return newVehicle;

        //}
        //public static Vehicle CreateCar(string i_LicensePlate, string i_ModelName, string i_TireManufacturer,
        //                                 Engine.eEngineType i_EngineType,
        //                                 float i_CurrentAirPressure, float i_CurrentEnergyAmount, int i_CarColor, int i_CarAmountOfDoors)
        //{
        //    Vehicle newVehicle = null;
        //    newVehicle = new Car(i_ModelName, i_LicensePlate, i_EngineType, i_TireManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount, i_CarColor, i_CarAmountOfDoors);
        //    return newVehicle;

        //}

