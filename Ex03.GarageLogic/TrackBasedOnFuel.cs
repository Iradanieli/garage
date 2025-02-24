using System;
using System.Collections.Generic;
namespace EX03.GarageLogic
{
    public class TrackBasedOnFuel : VehicleUsesFuel
    {
        private bool m_hazardMaterials;
        private float m_cargoVolume;

        public bool hazardMaterials
        {
            get { return m_hazardMaterials; }
            set { m_hazardMaterials = value; }
        }

        public float cargoVolume
        {
            get { return m_cargoVolume; }
            set { m_cargoVolume = value; }
        }

        public TrackBasedOnFuel(String model, String licenseNumber)      ///constructor the recieves only 2 fields
            : base(model, licenseNumber)
        {
        }


        public TrackBasedOnFuel(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, bool hazardMaterials, float volume)
            : base(model, licenseNumber, energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity)
        {
            this.m_hazardMaterials = hazardMaterials;
            this.m_cargoVolume = volume;
        }

        public void FillFields(float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, bool hazardMaterials, float volume)
        {
            ///vehicle fields
            this.energyLeftPercentage = energyLeftPercentage;
            this.m_wheels = wheels;
            ///fuel vehicle fields
            this.fuelType = fuelType;
            this.currentFuelAmount = currentFuelAmount;
            this.maximumFuelCapacity = maximumFuelCapacity;
            ///truck fields
            this.m_hazardMaterials = hazardMaterials;
            this.m_cargoVolume = volume;
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the truck has hazard materials: {this.m_hazardMaterials}, the cargo volume is: {this.m_cargoVolume}");
        }
    }
}

