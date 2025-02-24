using System;
namespace EX03.GarageLogic
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {
        }

        public static Vehicle createVehicle(string i_VehicleTypeInput, string i_ModelName, string i_LicenseNumber)
        {
            switch (i_VehicleTypeInput)
            {
                case "CarBasedOnFuel":
                    return new CarBasedOnFuel(i_ModelName, i_LicenseNumber);

                case "ElectricCar":
                    return new ElectricCar(i_ModelName, i_LicenseNumber);

                case "MotorcycleBasedOnFuel":
                    return new MotorcycleBasedOnFuel(i_ModelName, i_LicenseNumber);

                case "ElectricMotorcycle":
                    return new ElectricMotorcycle(i_ModelName, i_LicenseNumber);

                default:  /// TrackBasedOnFuel:
                    return new TrackBasedOnFuel(i_ModelName, i_LicenseNumber);
            }
        }
    }
}

