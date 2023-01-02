using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        public enum eMaxAirPressure
        {
            Motorcycle = 28,
            Car = 32,   
            Truck = 34
        }
        private readonly string r_ManufacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure = 0;


        public Tire(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;
            InflateAir(i_CurrentAirPressure);
        }

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        ////    set { m_CurrentAirPressure = value; }
        }

        public float MaxtAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public void InflateAir(float i_AirPressure)
        {
            if (m_CurrentAirPressure + i_AirPressure > MaxtAirPressure || m_CurrentAirPressure + i_AirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, MaxtAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirPressure;
            }
        }

        public override string ToString()
        {
            string wheelInformation;
            wheelInformation = string.Format(@"Wheel manufacturer name: {0}
Current wheel air pressure: {1}
Maximum wheel air pressure: {2}",
r_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressure);
            return wheelInformation;
        }
    }
}
