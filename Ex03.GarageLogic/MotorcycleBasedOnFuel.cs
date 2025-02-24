using System;
using System.Collections.Generic;
namespace EX03.GarageLogic
{
    public class MotorcycleBasedOnFuel : VehicleUsesFuel
    {
        private MotorcycleLicense m_licenseType;
        private int m_engineCapacity;

        public MotorcycleLicense licenseType
        {
            get { return m_licenseType; }
            set { m_licenseType = value; }
        }

        public int engineCapacity
        {
            get { return m_engineCapacity; }
            set { m_engineCapacity = value; }
        }

        public MotorcycleBasedOnFuel(String model, String licenseNumber)      ///constructor the recieves only 2 fields
          : base(model, licenseNumber)
        {
        }

        public MotorcycleBasedOnFuel(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, MotorcycleLicense licenseType, int engineCapacity)
            : base(model, licenseNumber, energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity)
        {
            this.m_licenseType = licenseType;
            this.m_engineCapacity = engineCapacity;
        }

        public void FillFields(float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, MotorcycleLicense licenseType, int engineCapacity)
        {
            ///vehicle fields
            this.energyLeftPercentage = energyLeftPercentage;
            this.m_wheels = wheels;
            ///fuel vehicle fields
            this.fuelType = fuelType;
            this.currentFuelAmount = currentFuelAmount;
            this.maximumFuelCapacity = maximumFuelCapacity;
            /// motorcycle fields
            this.m_licenseType = licenseType;
            this.m_engineCapacity = engineCapacity;
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the license type is: {this.m_licenseType.ToString()}, the engine capacity is: {this.m_engineCapacity}");
        }
    }
}

