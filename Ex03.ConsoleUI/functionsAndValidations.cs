using System;
using System.Collections.Generic;
using EX03.GarageLogic;
namespace EX3.ConsoleUI
{
    public class functionsAndValidations
    {
        public functionsAndValidations()
        {
        }


        public static string ValidatePhoneNumber()
        {
            string phoneNumber = " ";
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Please enter the owner's phone number(type a 10 digit phone: 05********) ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber != null)
                {
                    if (phoneNumber.Length == 10 && phoneNumber[0] == '0' && phoneNumber[1] == '5')
                    {
                        foreach (char character in phoneNumber)
                        {
                            if (character < '0' || character > '9')
                            {
                                Console.WriteLine("Invalid phone number.");
                                break;
                            }
                        }
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number.");
                    }
                }
            }

            return phoneNumber;
        }


        public static FuelType ConvertInputStringToEnumFuelType()
        {
            bool validInput = false;
            FuelType currentFuelType = FuelType.Octan95;  ///default
            int userINTinput;

            while (validInput == false)
            {
                Console.WriteLine("Enter a fuel type (Soler, Octan95, Octan96, Octan98):");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userINTinput))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (Enum.TryParse(userInput, true, out currentFuelType))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid fuel type.");
                }
            }

            return currentFuelType;
        }


        public static float ValidMaxFuel()
        {
            float maxFuel = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter a maximum fuel capacity:");
                string input = Console.ReadLine();

                if (float.TryParse(input, out maxFuel))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return maxFuel;
        }


        public static float ValidCurrentFuelAmount(float i_MaxCapacity)
        {
            float currentFuel = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter the current fuel amount:");
                string input = Console.ReadLine();
                if (float.TryParse(input, out currentFuel))
                {
                    if (Garage.CheckIfInsertedValueSmallerThanMaxValue(currentFuel, i_MaxCapacity) == true)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("The current amount cant be more than the maximum capacity");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return currentFuel;
        }


        public static Color ConvertInputStringToEnumColor()
        {
            bool validInput = false;
            Color currentCollor = Color.Black;  ///default
            int userINTinput;

            while (validInput == false)
            {
                Console.WriteLine("Enter a color (Black, Red, White, Yellow):");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userINTinput))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (Enum.TryParse(userInput, true, out currentCollor))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid color");
                }
            }
            return currentCollor;

        }


        public static Doors ConvertInputStringToEnumDoors()
        {
            bool validInput = false;
            Doors currentDoors = Doors.Four;  ///default
            int userINTinput;

            while (validInput == false)
            {
                Console.WriteLine("Enter number of doors (Two, Three, Four, Five):");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userINTinput))
                {
                    if (userINTinput == 2 || userINTinput == 3 || userINTinput == 4 || userINTinput == 5)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        continue;
                    }
                }

                if (Enum.TryParse(userInput, true, out currentDoors))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number of doors");
                }
            }

            return currentDoors;
        }


        public static float ValidMaxAirPressure()
        {
            float maxAirPressure = 0;
            bool validInput = false;

            while (validInput == false)
            {
                string input = Console.ReadLine();

                if (float.TryParse(input, out maxAirPressure))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return maxAirPressure;
        }


        public static float ValidCurrentAirPressure(float i_MaxAirPressure)
        {
            float currentAirPressure = 0;
            bool validInput = false;

            while (validInput == false)
            {
                string input = Console.ReadLine();
                if (float.TryParse(input, out currentAirPressure))
                {
                    if (Garage.CheckIfInsertedValueSmallerThanMaxValue(currentAirPressure, i_MaxAirPressure) == true)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("The current amount cant be more than the maximum capacity");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return currentAirPressure;
        }


        public static List<Wheel> CreateListOfWheels(int i_NumberOfWheels)
        {
            List<Wheel> WheelsList = new List<Wheel>();
            String manufacturer;
            float maximumAirPressure;
            float currentAirPressure;
            Wheel currentWheel;
            int numberOfIterations = i_NumberOfWheels;

            Console.WriteLine("would you like to insert details for each one of the {0} wheels? answer Yes/No: ", i_NumberOfWheels);
            string answer = Console.ReadLine();
            if (answer == "No" || answer == "no")
            {
                numberOfIterations = 1;
            }

            for (int i = 1; i <= numberOfIterations; i++)
            {
                Console.WriteLine("Insert wheel number {0} details as follows", i);
                Console.WriteLine("Insert manufacturer:");
                manufacturer = Console.ReadLine();

                Console.WriteLine("Insert maximum air pressure:");
                maximumAirPressure = ValidMaxAirPressure();

                Console.WriteLine("Insert current air pressure:");
                currentAirPressure = ValidCurrentAirPressure(maximumAirPressure);

                currentWheel = new Wheel(manufacturer, currentAirPressure, maximumAirPressure);
                WheelsList.Add(currentWheel);
                if (numberOfIterations == 1)   /// in case the user inserts only once, add it more times
                {
                    for (int remaining = 1; remaining < i_NumberOfWheels; remaining++)
                    {
                        WheelsList.Add(currentWheel);
                    }
                }
            }

            return WheelsList;
        }


        public static string ValidVehicleType()
        {
            VehicleTypes vehicleTypeInput = VehicleTypes.ElectricCar; /// temporary default
            string userInput = "";
            bool isVehicleExists = false;
            int userINTinput;

            while (isVehicleExists == false)
            {
                Console.WriteLine("Please enter the type of the vehicle(out of the following options):");
                VehicleTypes[] array = Garage.GetEnumValues<VehicleTypes>();
                string toPrint = Garage.PrintEnum(array);
                Console.WriteLine(toPrint);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userINTinput))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (userInput != "CarBasedOnFuel" && userInput != "ElectricCar" && userInput != "MotorcycleBasedOnFuel" && userInput != "ElectricMotorcycle" && userInput != "TrackBasedOnFuel")
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (Enum.TryParse(userInput, true, out vehicleTypeInput))
                {
                    isVehicleExists = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid type of the vehicle");
                }
            }

            return userInput;
        }


        public static MotorcycleLicense ValidateMotorcycleLicense()
        {
            bool validInput = false;
            MotorcycleLicense currentLicense = MotorcycleLicense.A;  ///temporary default
            int userINTinput;

            while (validInput == false)
            {
                Console.WriteLine("Enter a motorcycle license type (A, A1, AA, B1):");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userINTinput))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (Enum.TryParse(userInput, true, out currentLicense))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid color");
                }
            }

            return currentLicense;
        }


        public static int ValidateIntInput()
        {
            bool validInput = false;
            int toReturn = 0;

            while (validInput == false)
            {
                Console.WriteLine("Enter engine capacity:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out toReturn))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid engine capacity");
                }
            }

            return toReturn;
        }


        public static float ValidCargoVolume()
        {
            float CargoVolume = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter cargo volume: ");
                string input = Console.ReadLine();

                if (float.TryParse(input, out CargoVolume))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return CargoVolume;
        }


        public static bool ValidCarriesHazardMaterials()
        {
            bool carriesHazardMaterials = false;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter if the truck carries hazardous materials or not (type True/False): ");
                string input = Console.ReadLine();

                if (input == "true" || input == "True") //input it true and is valid
                {
                    validInput = true;
                    carriesHazardMaterials = true;
                }
                else if (input == "false" || input == "False") //input is false and valid
                {
                    validInput = true;
                    carriesHazardMaterials = false;
                }
                else //input is invalid
                {
                    Console.WriteLine("Invalid input");
                }
            }

            return carriesHazardMaterials;
        }


        public static float ValidMaxBatteryCapacity()
        {
            float maxBatteryCapacity = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter the maximum battery capacity:");
                string input = Console.ReadLine();

                if (float.TryParse(input, out maxBatteryCapacity))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return maxBatteryCapacity;
        }


        public static float ValidCurrentBattery(float i_MaxBatteryCapacity)
        {
            float currentBattery = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter the current battery value:");
                string input = Console.ReadLine();

                if (float.TryParse(input, out currentBattery))
                {
                    if (Garage.CheckIfInsertedValueSmallerThanMaxValue(currentBattery, i_MaxBatteryCapacity) == true)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("The current battery amount cant be more than the maximum battery capacity");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return currentBattery;
        }


        public static float ValidFloatValue()
        {
            float maxFuel = 0;
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Enter an amount: ");
                string input = Console.ReadLine();

                if (float.TryParse(input, out maxFuel))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid float number.");
                }
            }

            return maxFuel;
        }


        public static VehicleStatus ValidateVehicleStatusType()
        {
            bool validInput = false;
            VehicleStatus statusType = VehicleStatus.inRepair;  ///default

            while (validInput == false)
            {
                int userINTinput;
                Console.WriteLine("Enter the status filter you want to search by(type inRepair/repaired/paid) :");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userINTinput))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (userInput != "inRepair" && userInput != "repaired" && userInput != "paid")
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (Enum.TryParse(userInput, true, out statusType))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid status.");
                }
            }

            return statusType;
        }


        public static string ValidActionChoiceInGarage()
        {
            string choice = " ";
            bool validInput = false;

            while (validInput == false)
            {
                Console.WriteLine("Please enter: \n1 for adding a vehicle to the garage, \n2 for seeing the list of the vehicles license numbers that are in the garage," +
                "\n3 to change the status of a vehicle which is in the garage, \n4 to inflate air to maximum in a vehicle's wheels," +
                "\n5 to refule a vehicle, \n6 to charge an electric vehicle, \n7 to represent full details of a vehicle \n0 to exit");
                choice = Console.ReadLine();
                if (choice != null)
                {
                    if (choice.Equals("0") || choice.Equals("1") || choice.Equals("2") || choice.Equals("3") || choice.Equals("4") || choice.Equals("5") || choice.Equals("6") || choice.Equals("7"))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }

            return choice;
        }
    }
}

