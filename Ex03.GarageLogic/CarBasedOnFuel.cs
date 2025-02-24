using System;
using System.Collections.Generic;

namespace EX03.GarageLogic
{
    public class CarBasedOnFuel : VehicleUsesFuel
    {
        private Color m_color;
        private Doors m_numberOfDoors;

        public Color color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        public Doors numberOfDoors
        {
            get { return m_numberOfDoors; }
            set { m_numberOfDoors = value; }
        }

        public CarBasedOnFuel(String model, String licenseNumber)      ///constructor the recieves only 2 fields
            : base(model, licenseNumber)
        {
        }


        public CarBasedOnFuel(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, Color color, Doors numberOfDoors)
            : base(model, licenseNumber, energyLeftPercentage, wheels, fuelType, currentFuelAmount, maximumFuelCapacity)
        {
            this.m_color = color;
            this.m_numberOfDoors = numberOfDoors;
        }

        public void FillFields(float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity, Color color, Doors numberOfDoors)
        {
            ///vehicle fields
            this.energyLeftPercentage = energyLeftPercentage;
            this.m_wheels = wheels;
            ///fuel vehicle fields
            this.fuelType = fuelType;
            this.currentFuelAmount = currentFuelAmount;
            this.maximumFuelCapacity = maximumFuelCapacity;
            ///car fields
            this.m_color = color;
            this.m_numberOfDoors = numberOfDoors;
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the color is: {this.m_color.ToString()}, the number of doors are: {this.m_numberOfDoors.ToString()}");
        }
    }
}

