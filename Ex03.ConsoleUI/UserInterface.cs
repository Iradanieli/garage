using System;
using System.Collections.Generic;
using EX03.GarageLogic;

namespace EX3.ConsoleUI
{
    public class UserInterface
    {
        public UserInterface()
        {
        }

        public static void Main()
        {
            Garage clerk = new Garage();
            Console.WriteLine("Welcome!");
            bool skipUserChoice = false;
            string licenseNumber = " ";
            string userAction = " ";

            while (userAction != "0")
            {
                if (skipUserChoice == false)
                {
                    Console.WriteLine("\nWhat would you like to do? ");
                    userAction = InitializeProgram();
                    Console.WriteLine("Please enter the vehicle's license number:");
                    licenseNumber = Console.ReadLine();
                }
                skipUserChoice = false;   /// in order to get user choice next time
                switch (userAction)
                {
                    case "1":
                        if (clerk.CheckIfVehicleExistsInGarage(licenseNumber) == true)
                        {
                            userAction = "3";
                            skipUserChoice = true;   /// skip the user choice next time, in purpose to get to case 3
                            break;
                        }
                        else   /// add new one
                        {
                            Vehicle currentVehicle = CreateVehicleFromData(licenseNumber);
                            VehicleOwnerData currentCarOwner = GetCarOwnerData(licenseNumber);
                            clerk.AddNewCarToGarage(currentVehicle, currentCarOwner);
                            Console.WriteLine("Vehicle added successfuly!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Would you like to filter the search by the vehicles status at the garage? (type Yes/No) :");
                        string ToFilter = Console.ReadLine();
                        if (ToFilter == "Yes" || ToFilter == "yes")
                        {
                            VehicleStatus filterType = functionsAndValidations.ValidateVehicleStatusType();
                            Console.WriteLine("The filtered license plates in the garage as you requested are:");
                            Console.WriteLine(Garage.CreateStringListOfLicensePlates(clerk.CreateListByStatusFilter(filterType))); ///filtered list
                            
                        }
                        else
                        {
                            Console.WriteLine("The license plates in the garage are:");
                            Console.WriteLine(Garage.CreateStringListOfLicensePlates(clerk.ListOfKeys)); // no filtered list
                        }
                        break;

                    case "3":

                        bool carStatusSuccess = clerk.ChangeVehicleStatus(licenseNumber);
                        if (carStatusSuccess == false)
                        {
                            Console.WriteLine("car does not exist in garage, try again");
                        }
                        else
                        {
                            Console.WriteLine("car status changed successfully");
                        }
                        break;

                    case "4":

                        bool succeeded = clerk.InflateAirInTires(licenseNumber);
                        if (succeeded == true)
                        {
                            Console.WriteLine("Inflate suucceeded!");
                        }
                        else
                        {
                            Console.WriteLine("Inflate failed, wrong license input!");
                        }
                        break;

                    case "5":

                        FuelType fuelType = functionsAndValidations.ConvertInputStringToEnumFuelType();
                        float fuelAmountToAdd = functionsAndValidations.ValidFloatValue();
                        if (clerk.Refuel(licenseNumber, fuelType, fuelAmountToAdd) == false)
                        {
                            Console.WriteLine("Refuel failed, invalid input");
                        }
                        else
                        {
                            Console.WriteLine("Refuel succeeded!");
                        }
                        break;

                    case "6":

                        Console.WriteLine("enter the time you wish to charge");
                        float timeToCharge = functionsAndValidations.ValidFloatValue();
                        if (clerk.ChargeElectricVehicle(licenseNumber, timeToCharge) == false)
                        {
                            Console.WriteLine("Charge failed, invalid input");
                        }
                        else
                        {
                            Console.WriteLine("Charge succeeded!");
                        }
                        break;

                    case "7":
                        string fullDetails = clerk.FullDetails(licenseNumber);
                        if (fullDetails.Length < 10)
                        {
                            Console.WriteLine("No corresponding vehicle found.");
                        }
                        else
                        {
                            Console.WriteLine(fullDetails);
                        }
                        break;
                }
            }
            Console.WriteLine("Thank you and good bye");
        }


        public static string InitializeProgram()
        {
            string inputAction = functionsAndValidations.ValidActionChoiceInGarage();   /// ensures the input is valid(0 to 7)
            return inputAction;
        }


        public static VehicleOwnerData GetCarOwnerData(string i_LicenseNumber)   ///and create struct
		{
            VehicleOwnerData result = new VehicleOwnerData();
            Console.WriteLine("Please enter the vehicle's owner name:");
            string OwnerName = Console.ReadLine();
            string PhoneNumber = functionsAndValidations.ValidatePhoneNumber();

            result.OwnerName = OwnerName;
            result.PhoneNumber = PhoneNumber;
            result.VehicleStatus = VehicleStatus.inRepair; ;
            result.Licenseplate = i_LicenseNumber;

            return result;
        }


        public static Vehicle CreateVehicleFromData(string i_LicenseNumber)
        {
            string modelName;
            string vehicleTypeInput;
            float energyLeftPercentage; /// will be calculated according to the type of vehicle
            List<Wheel> wheels;         /// will be recieved according to the vehicle type, /// option to insert all of wheels as one input
            string FuelOrElectric;

            vehicleTypeInput = functionsAndValidations.ValidVehicleType();
            Console.WriteLine("Please enter the vehicle's model name:");
            modelName = Console.ReadLine();
            bool isBasedOn = vehicleTypeInput.Contains("Fuel");
            if (isBasedOn == true)
            {
                FuelOrElectric = "Fuel";
            }
            else
            {
                FuelOrElectric = "Electric";
            }
            Vehicle currentVehicle = VehicleFactory.createVehicle(vehicleTypeInput, modelName, i_LicenseNumber);/// create an object, initializing only 2 of his fields

            switch (FuelOrElectric)
            {
                case "Fuel":
                    FuelType fuelType = functionsAndValidations.ConvertInputStringToEnumFuelType();
                    float maximumFuelCapacity = functionsAndValidations.ValidMaxFuel();
                    float currentFuelAmount = functionsAndValidations.ValidCurrentFuelAmount(maximumFuelCapacity);
                    energyLeftPercentage = (currentFuelAmount / maximumFuelCapacity) * 100;
                    switch (vehicleTypeInput)
                    {
                        case "CarBasedOnFuel":
                            Color color = functionsAndValidations.ConvertInputStringToEnumColor();
                            Doors numberOfDoors = functionsAndValidations.ConvertInputStringToEnumDoors();
                            wheels = functionsAndValidations.CreateListOfWheels(5);
                            (currentVehicle as CarBasedOnFuel).FillFields(energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity, color, numberOfDoors);
                            break;

                        case "MotorcycleBasedOnFuel":

                            MotorcycleLicense licenseType = functionsAndValidations.ValidateMotorcycleLicense();
                            int engineCapacity = functionsAndValidations.ValidateIntInput();
                            wheels = functionsAndValidations.CreateListOfWheels(2);
                            (currentVehicle as MotorcycleBasedOnFuel).FillFields(energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity, licenseType, engineCapacity);
                            break;

                        case "TrackBasedOnFuel":

                            bool hazardMaterials = functionsAndValidations.ValidCarriesHazardMaterials();
                            float cargoVolume = functionsAndValidations.ValidCargoVolume();
                            wheels = functionsAndValidations.CreateListOfWheels(12);
                            (currentVehicle as TrackBasedOnFuel).FillFields(energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity, hazardMaterials, cargoVolume);
                            break;
                    }
                    break;

                case "Electric":
                    float batteryMaximumTime = functionsAndValidations.ValidMaxBatteryCapacity();
                    float batteryTimeLeft = functionsAndValidations.ValidCurrentBattery(batteryMaximumTime);
                    energyLeftPercentage = (batteryTimeLeft / batteryMaximumTime) * 100;
                    switch (vehicleTypeInput)
                    {
                        case "ElectricCar":
                            Color color = functionsAndValidations.ConvertInputStringToEnumColor();
                            Doors numberOfDoors = functionsAndValidations.ConvertInputStringToEnumDoors();
                            wheels = functionsAndValidations.CreateListOfWheels(5);
                            (currentVehicle as ElectricCar).FillFields(energyLeftPercentage, wheels, batteryTimeLeft, batteryMaximumTime, color, numberOfDoors);
                            break;

                        case "ElectricMotorcycle":
                            MotorcycleLicense licenseType = functionsAndValidations.ValidateMotorcycleLicense();
                            int engineCapacity = functionsAndValidations.ValidateIntInput();
                            wheels = functionsAndValidations.CreateListOfWheels(2);
                            (currentVehicle as ElectricMotorcycle).FillFields(energyLeftPercentage, wheels, batteryTimeLeft, batteryMaximumTime, licenseType, engineCapacity);
                            break;
                    }
                    break;
            }

            return currentVehicle;
        }
    }
}

