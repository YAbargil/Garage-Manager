using System;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public enum eChoiceMenu
        {
            AddNewVehicle=1,
            PresentLicensedPlates,
            ChangeVehicleStatus,
            InflateTires,
            FillFuel,
            ChargeBattery,
            ShowVehicleDetails,
            Quit
        }

        public void GreetAndShowMenu()
        {
            string menu = @"

===========================

(1) - Add a new vehicle
(2) - Show a list of cars in my garrage based on licensed plate (or not)
(3) - Change vehicle status
(4) - Inflate vehicle's tires
(5) - Fill Vehicle's Fuel tank
(6) - Charge Vehicle's battery
(7) - Show vehicle details
(8) - Quit

===========================
            ";
            Console.WriteLine(string.Format(@"
Hello and welcome to my garrage
{0}
{1}",menu, Environment.NewLine));

        }
        public eChoiceMenu GetSelectionFromUser()
        {
            Console.WriteLine("Which Choice you desire ?");
            string input = Console.ReadLine();
            userMenuValidation(input,8);
            return (eChoiceMenu)(int.Parse(input));
        }





        public int GetLicensedDetails()
        {
            Console.WriteLine(string.Format(@"Please choose which status of license plates you want to see:
(0) - Everyone
(1) - In Repair
(2) - Repaired
(3) - Paid"));
            string input = Console.ReadLine();
            userMenuValidation(input, 3);
            return int.Parse(input);
        }

        public void GetVehicleDetails(out string io_ModelName, out string  io_TireManufacturer,out float  io_CurrentAirPressure,out float io_CurrentEnergy)
        {
            string inputModel, inputTire, inputAirPressure, inputCurrentEnergy;
            Console.WriteLine("Please enter vehicle model :");
            inputModel = Console.ReadLine();
            if (inputModel.Length < 1)
            {
                throw new FormatException("Error , Please re-enter model name");
            }
            Console.WriteLine("Please enter tire manufacturer:");
            inputTire = Console.ReadLine();
            isNameValid(inputTire);
            Console.WriteLine("Please enter current tire's air pressure :");
            inputAirPressure = Console.ReadLine();
            io_CurrentAirPressure =isFloatValid(inputAirPressure);
            Console.WriteLine("Please enter current energy amount:");
            inputCurrentEnergy = Console.ReadLine();
            io_CurrentEnergy = isFloatValid(inputCurrentEnergy);
            io_ModelName = inputModel;
            io_TireManufacturer = inputTire;
        }



        public string MatchingVehicleToLicense(Ex03.GarageLogic.GarageInventory i_Garage)
        {
            string licensePlate = GetLicensePlate(); 
            bool isExists = i_Garage.IsVechileAlreadyExists(licensePlate);
            if (!isExists)
            {
                throw new FormatException("No matching vehicle to your input , sorry!");
            }
            else
            {
                return licensePlate;
            }
        }
        public float GetFloat()
        {
            Console.WriteLine("Please enter amount of energy to be added");
            string input = Console.ReadLine();
            float returnFloat = isFloatValid(input);
            return returnFloat;
        }

        private float isFloatValid(string i_InputFloat)
        {
            bool isFloat = float.TryParse(i_InputFloat, out float number);
            if (!isFloat)
            {
                throw new FormatException("Error, Input is not a float");
            }
            return number;
        }


        public Ex03.GarageLogic.Engine.eEngineType GetEngineType()
        {
            Console.WriteLine(string.Format(@"Enter your vehicle engine type please :
(1) - Fuel
(2) - Electric"));
            string userChoice = Console.ReadLine();
            userMenuValidation(userChoice, 2);
            return (Ex03.GarageLogic.Engine.eEngineType)int.Parse(userChoice);

        }

        public Ex03.GarageLogic.Vehicle.eVehiclesType GetVehicleType()
        {
            Console.WriteLine(string.Format(@"Enter your vehicle type please :
(1) - Car
(2) - Motorcycle
(3) - Truck"));
            string userChoice = Console.ReadLine();
            userMenuValidation(userChoice, 3);
            return (Ex03.GarageLogic.Vehicle.eVehiclesType)int.Parse(userChoice);
        }






        public void GetOwnerDetails(out string io_OwnerName,out string io_OwnerPhone)
        {
            string ownerName, ownerPhone;
            Console.WriteLine("Please enter vehicle owner's name :");
            ownerName = Console.ReadLine();
            isNameValid(ownerName);
            Console.WriteLine("Please enter vehicle owner's phone number:");
            ownerPhone = Console.ReadLine();
            isPhoneValid(ownerPhone);
            io_OwnerName = ownerName;
            io_OwnerPhone = ownerPhone;
        }

        private void isPhoneValid(string i_PhoneNumber)
        {
            
            if (i_PhoneNumber.Length != 10)
            {
                throw new FormatException("Owner phone can be only 10 number long!");
            } 
            foreach(char c in i_PhoneNumber)
            {
                if(!Char.IsDigit(c))
                {
                    throw new FormatException("Owner phone can be only with digits!");
                }
            }
        }

        private void isNameValid(string i_Name)
        {
            if (i_Name.Length < 2)
            {
                throw new FormatException("Name can't be less than 2!");
            }

            foreach(char c in i_Name)
            {
                if((c < 'a' || c > 'z') &&( c<'A' || c>'Z'))
                {
                    throw new FormatException("Name must cotain only letters");
                }
            }

        }

        public void PrintList(System.Collections.Generic.List<String> i_ListToPrint)
        {
            PrintMessage(string.Join(Environment.NewLine, i_ListToPrint));
        }
        public void PrintMessage(string i_Message)
        {
            Console.Clear();
            Console.Write(string.Format("{0}{1}", i_Message,Environment.NewLine));
        }

        public void Goodbye()
        {
            PrintMessage("See ya !");
        }
        private void userMenuValidation(string i_UserInput,int i_MaxLength)
        {
            if(i_UserInput.Length>1)
            {
                throw new FormatException("Error, Please choose from the  options above");
            }

            bool isValid = int.TryParse(i_UserInput, out int userChoice);
            if (!isValid)
            {
                throw new FormatException("Error, Please enter a number:");
            }

            if(userChoice<0 || userChoice> i_MaxLength)
            {
                throw new FormatException("Eror , no matching option for this number please try again");
            }
        }

        private void isNumber(string i_UserInput)
        {
            if (i_UserInput.Length < 1)
            {
                    throw new FormatException("Error, input cant be empty");
            }
            foreach (char c in i_UserInput)
            {
                if (!Char.IsDigit(c))
                {
                    throw new FormatException("Input must cotain only numbers");
                }
            }

        }
        public void GetMotorcycleDetails(out int io_UserMotorcycleVolume,out int io_UserSelectionMotorcycleLicense, Ex03.GarageLogic.Vehicle i_Vehicle)
        {
            string inputLicense, inputVolume;
            Console.WriteLine(string.Format(@"Please choose your motorcycle license type 
(1) - A
(2) - A1
(3) - AA
(4) - B"));
            inputLicense = Console.ReadLine();
            userMenuValidation(inputLicense, 5);
            Console.WriteLine("Please enter motorcycle volume :");
            inputVolume = Console.ReadLine();
            isNumber(inputVolume);
            io_UserMotorcycleVolume = int.Parse(inputVolume);
            io_UserSelectionMotorcycleLicense = int.Parse(inputLicense);
        }



        public void GetTruckDetails(out bool io_UserSelectionIsDangerous,out float io_TruckWeight,Ex03.GarageLogic.Vehicle i_Vehicle)
        {
            string inputIsDangerous, inputWeight;
            Console.WriteLine(string.Format(@"Does truck transports dangerous materials ? 
(1) - Yes
(2) - No"));
            inputIsDangerous = Console.ReadLine();
            userMenuValidation(inputIsDangerous, 2);
            Console.WriteLine("Please enter your truck cargo's weight:");
            inputWeight = Console.ReadLine();
            io_TruckWeight=isFloatValid(inputWeight);
            io_UserSelectionIsDangerous = inputIsDangerous.Equals("1");
        }


        public void GetCarDetails(out int io_UserSelectionDoorAmount,out int io_UserSelectionColor,Ex03.GarageLogic.Vehicle i_Vehicle)
        {
            string inputColor, inputDoor;
            Console.WriteLine(string.Format(@"Please choose your car color: 
(1) - Red
(2) - Green
(3) - White
(4) - Grey"));
            inputColor = Console.ReadLine();
            userMenuValidation(inputColor, 4);
            Console.WriteLine(string.Format(@"Please choose your amount of doors in your car: 
(1) - Two
(2) - Three
(3) - Four
(4) - Five"));
            inputDoor = Console.ReadLine();
            userMenuValidation(inputDoor, 4);
            io_UserSelectionDoorAmount = int.Parse(inputDoor);
            io_UserSelectionColor = int.Parse(inputColor);
        }



        public int GetNewStatusVehicle()
        {
            Console.WriteLine(string.Format(@"Please choose your car's new status :
(1) - In Repair
(2) - Repaired
(3) - Paid"));
            string input = Console.ReadLine();
            userMenuValidation(input, 3);
            return int.Parse(input);
        }


        public int GetFuelDetails()
        {
            Console.WriteLine(string.Format(@"Please choose your matching fuel to your vehicle :
 (1) - Soler,
 (2) - Octan95
 (3) - Octan96
 (4) - Octan98"));
            string input = Console.ReadLine();
            userMenuValidation(input, 4);
            return int.Parse(input);


        }
        public string GetLicensePlate()
        {
            string userLicense = string.Empty;
            Console.WriteLine("Please enter your vehicle license plate:");
            string inputLicense = Console.ReadLine();
            userLicense = isLicenseValid(inputLicense);
            return userLicense;
        }


        private string isLicenseValid(string i_licensePlate)
        {

            const int maximumLicensePlateNumber = 8;
            const int minimumLicensePlateNumber = 7;
            bool result = int.TryParse(i_licensePlate, out _);
            if (!result)
            {
                throw new FormatException("Error, please try again :");
            }

            if (i_licensePlate.Length != maximumLicensePlateNumber && i_licensePlate.Length != minimumLicensePlateNumber)
            {
                throw new FormatException("Input's length suppose to be between 7 and 8, Please try again");
            }

            return i_licensePlate;

        }

        public void ScanLicensePlate(out string i_LicensePlate)
        {
            string licencePlateInputString;
            Console.WriteLine("Please enter license plate:");
            licencePlateInputString = Console.ReadLine();
            checkIfLicensePlateValid(licencePlateInputString);
            i_LicensePlate = licencePlateInputString;
        }

        private void checkIfLicensePlateValid(string i_licencsePlate)
        {
            int LicensePlateNumber;
            const int maximumLicensePlateNumber = 8;
            const int minimumLicensePlateNumber = 7;
            bool result = int.TryParse(i_licencsePlate, out LicensePlateNumber);
            if (!result)
            {
                throw new FormatException("You didnt enterd a number. Please tyr again:");
            }

            if (i_licencsePlate.Length != maximumLicensePlateNumber && i_licencsePlate.Length != minimumLicensePlateNumber)
            {
                throw new FormatException("The length of license plate should be 7 or 8 digits. Please try again:");
            }
        }
    }
}
