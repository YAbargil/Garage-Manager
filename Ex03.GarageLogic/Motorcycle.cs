namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_AmountOfTires = 2;
        private const float k_FullBatteryCapacity = 1.6f;
        private eLicenseType m_LicenseType;
        private int m_MotorcycleVolume;
        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        public int MotorcycleVolume
        {
            get { return m_MotorcycleVolume; }
        }
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public Motorcycle(string i_ModelName, string i_LicensePlate, Engine.eEngineType i_EngineType,
            string i_TireManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
            : base(i_ModelName, i_LicensePlate, i_EngineType, i_TireManufacturerName, k_AmountOfTires, i_CurrentAirPressure,
                  (float)Tire.eMaxAirPressure.Motorcycle,(float)Fuel.eFuelTankCapacity.Motorcycle, (float)Fuel.eFuelType.Octan98, k_FullBatteryCapacity)
        {
            FillAndSetVechile(i_CurrentEnergyAmount);
        }

        public override void FillAndSetVechile(float i_CurrentEnergyAmount)
        {
            Engine.SetEnergy(i_CurrentEnergyAmount);
            CalculateEnergyPercent();
        }


        public void SetMotorcycleDetails(int i_UserSelectionuserMotorcycleVolume,int i_UserSelectionMotorcycleLicense)
        {
            this.m_MotorcycleVolume= i_UserSelectionuserMotorcycleVolume;
            this.m_LicenseType = (eLicenseType)i_UserSelectionMotorcycleLicense;
        }
       

        public override string ToString()
        {
            string motorcycleInformation;
            motorcycleInformation = string.Format(@"{0}
Engine capacity: {1}
License type: {2}
",
VehicleData(), m_MotorcycleVolume, m_LicenseType.ToString());
            return motorcycleInformation;
        }

    }
}
