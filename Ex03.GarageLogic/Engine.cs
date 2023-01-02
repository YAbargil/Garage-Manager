using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            Fuel = 1,
            Electric,
        }
        private float m_CurrentEnergy = 0;
        private readonly float r_MaxCapacity;



        public Engine(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set
            {
                if (value > MaxCapacity)
                {
                    throw new ValueOutOfRangeException(0, MaxCapacity);
                }
                else
                {
                    m_CurrentEnergy = value;
                }
            }
        }

        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }

        public  void SetEnergy(float i_EnergyAmount)
        {
            if (m_CurrentEnergy + i_EnergyAmount > MaxCapacity || m_CurrentEnergy + i_EnergyAmount < 0)
            {
                throw new ValueOutOfRangeException(0, MaxCapacity);
            }
            m_CurrentEnergy += i_EnergyAmount;
        }

       
    }
}
