using System;
using System.Collections.Generic;
namespace EX03.GarageLogic
{
    public class Garage
    {
        private Dictionary<VehicleOwnerData, Vehicle> m_ServiceDictionary;
        private List<VehicleOwnerData> m_ListOfKeys;

        public Garage()
        {
            this.m_ServiceDictionary = new Dictionary<VehicleOwnerData, Vehicle>();
            m_ListOfKeys = new List<VehicleOwnerData>();
        }
        public Dictionary<VehicleOwnerData, Vehicle> ServiceDictionary
        {
            get { return m_ServiceDictionary; }
        }

        public List<VehicleOwnerData> ListOfKeys
        {
            get { return m_ListOfKeys; }
        }

        public bool CheckIfVehicleExistsInGarage(string i_LicensePlate)
        {
            bool alreadyInGarage = false;

            foreach (VehicleOwnerData keyVehicel in this.m_ListOfKeys)
            {
                if (keyVehicel.m_Licenseplate == i_LicensePlate)
                {
                    alreadyInGarage = true;
                    break;
                }
            }

            return alreadyInGarage;
        }


        public void AddNewCarToGarage(Vehicle i_CurrentVehicle, VehicleOwnerData i_CurrentCarOwner)
        {
            this.m_ServiceDictionary.Add(i_CurrentCarOwner, i_CurrentVehicle);
            this.m_ListOfKeys.Add(i_CurrentCarOwner);
        }


        public static string CreateStringListOfLicensePlates(List<VehicleOwnerData> i_List)
        {
            string toReturn = "";

            foreach (VehicleOwnerData key in i_List)
            {
                toReturn += $"{key.m_Licenseplate}, ";

            }
            toReturn = toReturn.Substring(0, toReturn.Length - 2);
            toReturn += "\n";
            return toReturn;
        }


        public List<VehicleOwnerData> CreateListByStatusFilter(VehicleStatus i_Filter)
        {
            List<VehicleOwnerData> list = new List<VehicleOwnerData>();

            foreach (VehicleOwnerData vehicle in this.m_ListOfKeys)
            {
                if (vehicle.VehicleStatus == i_Filter)
                {
                    list.Add(vehicle);
                }
            }

            return list;
        }


        public bool ChangeVehicleStatus(string i_LicenseNumber)
        {
            bool statusChangeSuccessful = true;
            bool doesCarExist = CheckIfVehicleExistsInGarage(i_LicenseNumber);

            if (doesCarExist == false)
            {
                statusChangeSuccessful = false;
            }
            else
            {
                VehicleOwnerData correspondingOwnerData = FindKeyOfLicensePlate(i_LicenseNumber);
                if (correspondingOwnerData.VehicleStatus == VehicleStatus.inRepair)
                {
                    VehicleOwnerData tempOwnerData = correspondingOwnerData;
                    Vehicle tempVehicle = this.m_ServiceDictionary[correspondingOwnerData];
                    tempOwnerData.VehicleStatus = VehicleStatus.repaired;

                    this.m_ServiceDictionary.Remove(correspondingOwnerData);                     ///remove and add from dictionary
                    this.m_ServiceDictionary.Add(tempOwnerData, tempVehicle);
                    this.ListOfKeys.Remove(correspondingOwnerData);                              ///remove and add from list
                    this.ListOfKeys.Add(tempOwnerData);
                }
                if (correspondingOwnerData.VehicleStatus == VehicleStatus.repaired)
                {
                    VehicleOwnerData tempOwnerData = correspondingOwnerData;
                    Vehicle tempVehicle = this.m_ServiceDictionary[correspondingOwnerData];
                    tempOwnerData.VehicleStatus = VehicleStatus.paid;

                    this.m_ServiceDictionary.Remove(correspondingOwnerData);
                    this.m_ServiceDictionary.Add(tempOwnerData, tempVehicle);
                    this.ListOfKeys.Remove(correspondingOwnerData);
                    this.ListOfKeys.Add(tempOwnerData);
                }
                if (correspondingOwnerData.VehicleStatus == VehicleStatus.paid)
                {
                    VehicleOwnerData tempOwnerData = correspondingOwnerData;
                    Vehicle tempVehicle = this.m_ServiceDictionary[correspondingOwnerData];
                    tempOwnerData.VehicleStatus = VehicleStatus.inRepair;

                    this.m_ServiceDictionary.Remove(correspondingOwnerData);
                    this.m_ServiceDictionary.Add(tempOwnerData, tempVehicle);
                    this.ListOfKeys.Remove(correspondingOwnerData);
                    this.ListOfKeys.Add(tempOwnerData);
                }
                statusChangeSuccessful = true;
            }

            return statusChangeSuccessful;
        }


        public bool InflateAirInTires(string i_licensePlate)
        {
            bool exists = true;

            if (CheckIfVehicleExistsInGarage(i_licensePlate) == false)
            {
                exists = false;
            }
            else
            {
                VehicleOwnerData correspondingOwnerData = FindKeyOfLicensePlate(i_licensePlate);
                foreach (Wheel currentWheel in (this.m_ServiceDictionary[correspondingOwnerData] as Vehicle).wheels)
                {
                    float inflateToMaximum = currentWheel.maximumAirPressure - currentWheel.airPressure;
                    currentWheel.inflate(inflateToMaximum);
                }
            }

            return exists;
        }


        public bool Refuel(string i_LicensePlate, FuelType i_FuelType, float i_FuelAmountToAdd)
        {
            bool succeeded = true;

            if (CheckIfVehicleExistsInGarage(i_LicensePlate) == false)
            {
                succeeded = false;
            }
            else
            {
                VehicleOwnerData keyVehicle = FindKeyOfLicensePlate(i_LicensePlate);
                VehicleUsesFuel defaultic = new VehicleUsesFuel("", "");
                try
                {
                    VehicleUsesFuel valueVehicle = (VehicleUsesFuel)(this.m_ServiceDictionary[keyVehicle]);
                    if (i_FuelType != valueVehicle.fuelType)
                    {
                        succeeded = false;
                    }
                    else
                    {
                        valueVehicle.insertFuel(i_FuelAmountToAdd, i_FuelType);
                        valueVehicle.energyLeftPercentage = (valueVehicle.currentFuelAmount / valueVehicle.maximumFuelCapacity) * 100;
                    }
                }
                catch (Exception e)
                {
                    succeeded = false;
                }
            }

            return succeeded;
        }


        public bool ChargeElectricVehicle(string i_LicensePlate, float i_TimeToCharge)
        {
            bool succeeded = true;

            if (CheckIfVehicleExistsInGarage(i_LicensePlate) == false)
            {
                succeeded = false;
            }
            else
            {
                VehicleOwnerData keyVehicle = FindKeyOfLicensePlate(i_LicensePlate);
                ElectricVehicle defaultic = new ElectricVehicle("", "");
                try
                {
                    ElectricVehicle valueVehicle = (ElectricVehicle)(this.m_ServiceDictionary[keyVehicle]);
                    valueVehicle.chargeBattery(i_TimeToCharge);
                    valueVehicle.energyLeftPercentage = (valueVehicle.batteryTimeLeft / valueVehicle.batteryMaximumTime) * 100;
                }
                catch (Exception e)
                {
                    succeeded = false;
                }
            }

            return succeeded;
        }


        public string FullDetails(string i_LicensePlate)
        {
            string toReturn = "empty";

            if (CheckIfVehicleExistsInGarage(i_LicensePlate) == true)
            {
                toReturn = "";
                VehicleOwnerData keyOwnerData = FindKeyOfLicensePlate(i_LicensePlate);
                Vehicle valueVehicle = this.m_ServiceDictionary[keyOwnerData];
                toReturn += keyOwnerData.ToString();
                toReturn += "\n";
                toReturn += valueVehicle.ToString();
            }

            return toReturn;
        }

        ///use this method ONLY AFTER USING CheckIfVehicleExistsInGarage() so it doesnt throw an exception
        public VehicleOwnerData FindKeyOfLicensePlate(string i_LicensePlate)
        {
            VehicleOwnerData keyVehicle;

            foreach (VehicleOwnerData key in this.m_ListOfKeys)
            {
                if (key.m_Licenseplate == i_LicensePlate)
                {
                    keyVehicle = key;
                    return keyVehicle;
                }
            }

            throw new ArgumentException();
        }


        public static bool CheckIfInsertedValueSmallerThanMaxValue(float i_Current, float i_Maximum)   ///smaller or equal
        {
            bool isSmaller = false;

            if (i_Current >= 0 && i_Current <= i_Maximum)
            {
                isSmaller = true;
            }

            return isSmaller;
        }


        public static T[] GetEnumValues<T>() where T : Enum
        {
            List<T> valuesList = new List<T>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                valuesList.Add((T)value);
            }

            return valuesList.ToArray();
        }


        public static string PrintEnum(VehicleTypes[] i_ToPrint)
        {
            string print = "";

            foreach (Enum e in i_ToPrint)
            {
                print += e.ToString();
                print += " ";
            }

            return print;
        }
    }


    public struct VehicleOwnerData
    {
        internal string m_OwnerName;
        internal string m_PhoneNumber;
        internal VehicleStatus m_VehicleStatus;
        internal string m_Licenseplate;

        public string Licenseplate
        {
            get { return m_Licenseplate; }
            set { m_Licenseplate = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public VehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public VehicleOwnerData(string OwnerName, string PhoneNumber, VehicleStatus VehicleStatus, string licenseplate)
        {
            this.m_OwnerName = OwnerName;
            this.m_PhoneNumber = PhoneNumber;
            this.m_VehicleStatus = VehicleStatus;
            this.m_Licenseplate = licenseplate;
        }

        override public string ToString()
        {
            return $"The owner name is: {this.m_OwnerName}, phone number for contact is: {this.m_PhoneNumber}, the vehicle status is: {this.m_VehicleStatus.ToString()}";
        }
    }

    public enum Color
    {
        Yellow,
        White,
        Red,
        Black
    }

    public enum Doors
    {
        Two,
        Three,
        Four,
        Five
    }

    public enum FuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    public enum MotorcycleLicense
    {
        A,
        A1,
        AA,
        B1
    }

    public enum VehicleStatus
    {
        inRepair,
        repaired,
        paid
    }

    public enum VehicleTypes
    {
        CarBasedOnFuel,
        ElectricCar,
        MotorcycleBasedOnFuel,
        ElectricMotorcycle,
        TrackBasedOnFuel
    }
}

