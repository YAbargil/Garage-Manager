using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageInventory
    {
        private Dictionary<string, Owner> m_GarageInventory = new Dictionary<string, Owner>();
        public Dictionary<string, Owner> MyGarage
        {
            get
            {
                return m_GarageInventory;
            }
        }

        public void UpdateStatus(string i_LicensePlate, Owner.eVehicleStatus i_NewStatus)
        {
            if(m_GarageInventory[i_LicensePlate].VehicleStatus != i_NewStatus)
            {
              m_GarageInventory[i_LicensePlate].VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new FormatException("You cant change status to your current one!!");
            }
        }

        public void AddNewVhicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_NewVehicale)
        {
            Owner vechileOwner = new Owner(i_OwnerName, i_OwnerPhoneNumber, i_NewVehicale);
            m_GarageInventory.Add(i_NewVehicale.LicensePlate, vechileOwner);
        }

        public bool IsVechileAlreadyExists(string i_LicensePlate)
        {
            return m_GarageInventory.ContainsKey(i_LicensePlate);
        }
    }
}
