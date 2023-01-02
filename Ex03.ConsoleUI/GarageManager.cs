using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private readonly UserInterface r_UserInterface = new UserInterface();
        private readonly Ex03.GarageLogic.GarageInventory r_Garage = new Ex03.GarageLogic.GarageInventory();
        private UserInterface.eChoiceMenu m_SelectedByUser;

        public void Initialize()
        {
            do
            {
                r_UserInterface.GreetAndShowMenu();
                try
                {
                    m_SelectedByUser = r_UserInterface.GetSelectionFromUser();
                    switch(m_SelectedByUser)
                    {
                        case UserInterface.eChoiceMenu.AddNewVehicle:
                            addVehicle();
                            break;
                        case UserInterface.eChoiceMenu.PresentLicensedPlates:
                            presentLicensedPlates();
                            break;
                        case UserInterface.eChoiceMenu.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;
                        case UserInterface.eChoiceMenu.InflateTires:
                            inflateVehicleTires();
                            break;
                        case UserInterface.eChoiceMenu.FillFuel:
                            fillVehicleFuel();
                            break;
                        case UserInterface.eChoiceMenu.ChargeBattery:
                            chargeBattery();
                            break;
                        case UserInterface.eChoiceMenu.ShowVehicleDetails:
                            showVehicleDetails();
                            break;
                    }
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);
                }
            }
            while (m_SelectedByUser != UserInterface.eChoiceMenu.Quit);
            r_UserInterface.Goodbye();
        }


        private void showVehicleDetails()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    string licensePlate = r_UserInterface.MatchingVehicleToLicense(r_Garage);
                    r_UserInterface.PrintMessage(r_Garage.MyGarage[licensePlate].ToString());
                    isFinished = true;
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);

                }
            }
            while (!isFinished);

            
        }
        private void chargeBattery()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    string licensePlate = r_UserInterface.MatchingVehicleToLicense(r_Garage);
                    if (!(r_Garage.MyGarage[licensePlate].ownersVechile.Engine is Ex03.GarageLogic.Electric))
                    {
                        r_UserInterface.PrintMessage("Your vehicle runs by Fuel!");
                    }
                    else
                    {
                        float amountOfHoursToAdd = r_UserInterface.GetFloat();
                        r_Garage.MyGarage[licensePlate].ownersVechile.Engine.SetEnergy(amountOfHoursToAdd);
                        isFinished = true;
                        r_UserInterface.PrintMessage("Vehicle's battery has been charged successfully");
                    }

                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);

                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException i_ValueOutOfRangeException)
                {
                    r_UserInterface.PrintMessage(i_ValueOutOfRangeException.Message);
                }
            }
            while (!isFinished);

        }

        private void fillVehicleFuel()
        {
            bool isFinished = false;
            do
            {
                string licensePlate = r_UserInterface.MatchingVehicleToLicense(r_Garage);
                try
                {
                    int userChoiceOfFuels = r_UserInterface.GetFuelDetails();
                    if (!(r_Garage.MyGarage[licensePlate].ownersVechile.Engine is Ex03.GarageLogic.Fuel))
                    {
                        r_UserInterface.PrintMessage("Your vehicle runs by electric!");
                    }
                    else
                    {
                        try
                        {
                            ((Ex03.GarageLogic.Fuel)r_Garage.MyGarage[licensePlate].ownersVechile.Engine).CheckFuelType((Ex03.GarageLogic.Fuel.eFuelType)userChoiceOfFuels);
                            float amountOfFuelToAdd = r_UserInterface.GetFloat();
                            r_Garage.MyGarage[licensePlate].ownersVechile.Engine.SetEnergy(amountOfFuelToAdd);
                            isFinished = true;
                            r_UserInterface.PrintMessage("Vehicle's fuel has been filled successfully");

                        }
                        catch (Ex03.GarageLogic.ValueOutOfRangeException i_ValueOutOfRangeException)
                        {
                            r_UserInterface.PrintMessage(i_ValueOutOfRangeException.Message);
                        }
                        catch (ArgumentException i_ArgumentException)
                        {
                            r_UserInterface.PrintMessage(i_ArgumentException.Message);
                        }
                    }

                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);
                }
            }
            while (!isFinished);
        }
        private void inflateVehicleTires()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    string licensePlate = r_UserInterface.MatchingVehicleToLicense(r_Garage);

                    foreach (Ex03.GarageLogic.Tire tire in r_Garage.MyGarage[licensePlate].ownersVechile.Tires)
                    {
                        float diffFromMaxAirPressure = tire.MaxtAirPressure - tire.CurrentAirPressure;
                        tire.InflateAir(diffFromMaxAirPressure);
                    }
                    isFinished = true;
                    r_UserInterface.PrintMessage("Vehicle's tire inflated successfully");
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);

                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException i_ValueOutOfRangeException)
                {
                    r_UserInterface.PrintMessage(i_ValueOutOfRangeException.Message);
                }
            }
            while (!isFinished);
        }
        private void changeVehicleStatus()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    string licensePlate = r_UserInterface.MatchingVehicleToLicense(r_Garage);

                    int userChoice = r_UserInterface.GetNewStatusVehicle();
                    try
                    {
                        r_Garage.UpdateStatus(licensePlate, (Ex03.GarageLogic.Owner.eVehicleStatus)userChoice);
                        r_UserInterface.PrintMessage("Vehicle's status changed successfully");
                        isFinished = true;
                    }
                    catch (FormatException i_FormatException)
                    {
                        r_UserInterface.PrintMessage(i_FormatException.Message);
                    }
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);

                }
            }
            while (!isFinished);
        }
        private void presentLicensedPlates()
        {
            bool isFinished = false;
            do
            {
                try
                {
                    int userChoice = r_UserInterface.GetLicensedDetails();

                    if (userChoice == 0)
                    {
                        isFinished = true;
                        if (r_Garage.MyGarage.Count == 0)
                        {
                            r_UserInterface.PrintMessage("Sorry , No vehicles yet !");
                        }
                        else
                        {
                            List<String> licenseMatched = new List<String>();
                            foreach (KeyValuePair<string, Ex03.GarageLogic.Owner> pair in r_Garage.MyGarage)
                            {
                                licenseMatched.Add(pair.Key);
                            }
                            r_UserInterface.PrintList(licenseMatched);
                        }
                    }
                    else
                    {

                        Ex03.GarageLogic.Owner.eVehicleStatus vehicleStatus = (Ex03.GarageLogic.Owner.eVehicleStatus)userChoice;
                            List<String> licenseMatched = new List<String>();
                        int sumMatchingStatus = 0;
                        foreach (KeyValuePair<string, Ex03.GarageLogic.Owner> pair in r_Garage.MyGarage)
                        {
                            if (vehicleStatus == pair.Value.VehicleStatus)
                            {
                               licenseMatched.Add(pair.Key);
                                sumMatchingStatus++;
                            }
                        }
                        r_UserInterface.PrintList(licenseMatched);

                        if (sumMatchingStatus == 0)
                        {
                            r_UserInterface.PrintMessage("Sorry no vehicles fit your filter!");
                        }
                        else
                        {
                            isFinished = true;

                        }
                    }
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);
                }
            }
            while (!isFinished);
        }
        private void addVehicle()
        {
            string ownerPhoneNumber = string.Empty;
            string ownerName = string.Empty;
            bool userCompletedInputs = false;
            bool IsLicenseExists = false;
            Ex03.GarageLogic.Vehicle ownerVehicle = null;
            do
            {
                try
                {
                    string licensePlate = r_UserInterface.GetLicensePlate();
                    IsLicenseExists = r_Garage.IsVechileAlreadyExists(licensePlate);
                    if (IsLicenseExists)
                    {
                        r_Garage.UpdateStatus(licensePlate, GarageLogic.Owner.eVehicleStatus.Repaired);
                        r_UserInterface.PrintMessage("Vehicle already exists in my garrage !");
                    }
                    else
                    {
                        try
                        {
                            string vehicleModel;
                            string tireManufacturer;
                            float currentEnergy;
                            float currentAirPressure;
                            Ex03.GarageLogic.Engine.eEngineType engineType;
                            Ex03.GarageLogic.Vehicle.eVehiclesType vehicleType;
                            r_UserInterface.GetOwnerDetails(out ownerName, out ownerPhoneNumber);
                            vehicleType = r_UserInterface.GetVehicleType();
                            if (vehicleType == Ex03.GarageLogic.Vehicle.eVehiclesType.Truck)
                            {
                                engineType = Ex03.GarageLogic.Engine.eEngineType.Fuel;
                            }
                            else
                            {
                                engineType = r_UserInterface.GetEngineType();
                            }
                            r_UserInterface.GetVehicleDetails(out vehicleModel, out tireManufacturer, out currentAirPressure, out currentEnergy);
                            ownerVehicle = Ex03.GarageLogic.Vehicle.CreateVehicle(licensePlate, vehicleModel, tireManufacturer, engineType, vehicleType, currentAirPressure, currentEnergy);
                            switch (vehicleType)
                            {
                                case Ex03.GarageLogic.Vehicle.eVehiclesType.Motorcycle:
                                    r_UserInterface.GetMotorcycleDetails(out int userMotorcycleVolume, out int userSelectionMotorcycleLicense, ownerVehicle);
                                    ((Ex03.GarageLogic.Motorcycle)ownerVehicle).SetMotorcycleDetails(userMotorcycleVolume, userSelectionMotorcycleLicense);
                                    break;
                                case Ex03.GarageLogic.Vehicle.eVehiclesType.Car:
                                    r_UserInterface.GetCarDetails(out int userSelectionDoorAmount, out int userSelectionColor, ownerVehicle);
                                    ((Ex03.GarageLogic.Car)ownerVehicle).SetCarDetails(userSelectionDoorAmount, userSelectionColor);
                                    break;
                                case Ex03.GarageLogic.Vehicle.eVehiclesType.Truck:
                                    r_UserInterface.GetTruckDetails(out bool userSelectionIsDangerous, out float userCargoWeight, ownerVehicle);
                                    ((Ex03.GarageLogic.Truck)ownerVehicle).SetTruckDetails(userSelectionIsDangerous, userCargoWeight);
                                    break;
                            }
                            userCompletedInputs = true;
                        }
                        catch(Ex03.GarageLogic.ValueOutOfRangeException i_ValueOutOfRangeException)
                        {
                            r_UserInterface.PrintMessage(i_ValueOutOfRangeException.Message);
                        }
                    }
                }
                catch (FormatException i_FormatException)
                {
                    r_UserInterface.PrintMessage(i_FormatException.Message);
                }
            }
            while (!userCompletedInputs && !IsLicenseExists);
            if (userCompletedInputs)
            {
            r_Garage.AddNewVhicle(ownerName, ownerPhoneNumber, ownerVehicle);
            r_UserInterface.PrintMessage("Vehicle added successfully");
            }
        }
    }
}
