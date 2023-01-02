using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Owner
    {
        private readonly string r_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private readonly Vehicle r_OwnersVechile;

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paid,
        }

        public Owner(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            r_OwnersVechile = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public Vehicle ownersVechile
        {
            get { return r_OwnersVechile; }
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public override string ToString()
        {
            string message;
            message = string.Format(@"Owner name: {0}
Owner phone number: {1}
vehicle status: {2}
{3}",
r_OwnerName, m_OwnerPhoneNumber, m_VehicleStatus.ToString(), r_OwnersVechile.ToString());

            return message.ToString();
        }

        public Vehicle OwnersVechile
        {
            get
            {
                return r_OwnersVechile;
            }
        }
    }
}
