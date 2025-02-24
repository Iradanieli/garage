using System;
using System.Collections.Generic;

namespace EX03.GarageLogic
{
    public class VehicleUsesFuel : Vehicle
    {
        protected FuelType m_fuelType;
        protected float m_currentFuelAmount;   /// in litres
		protected float m_maximumFuelCapacity;

        public FuelType fuelType
        {
            get { return m_fuelType; }
            set { m_fuelType = value; }
        }

        public float currentFuelAmount
        {
            get { return m_currentFuelAmount; }
            set { m_currentFuelAmount = value; }
        }

        public float maximumFuelCapacity
        {
            get { return m_maximumFuelCapacity; }
            set { m_maximumFuelCapacity = value; }
        }

        public VehicleUsesFuel(String model, String licenseNumber)      ///constructor the recieves only 2 fields
            : base(model, licenseNumber)
        {
        }


        public VehicleUsesFuel(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, FuelType fuelType, float currentFuelAmount, float maximumFuelCapacity)
            : base(model, licenseNumber, energyLeftPercentage, wheels)
        {
            this.m_fuelType = fuelType;
            this.m_currentFuelAmount = currentFuelAmount;
            this.m_maximumFuelCapacity = maximumFuelCapacity;
        }

        public void insertFuel(float amountOfFuelToInsert, FuelType fuelType)
        {
            if (this.m_fuelType != fuelType)
            {
                throw new ArgumentException();
            }

            if (this.m_currentFuelAmount + amountOfFuelToInsert > this.m_maximumFuelCapacity)
            {
                throw new ValueOutOfRangeException(m_maximumFuelCapacity - m_currentFuelAmount);
            }
            else
            {
                this.m_currentFuelAmount += amountOfFuelToInsert;
            }
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the fuel type is: {this.m_fuelType.ToString()}, the current fuel amount is: {this.m_currentFuelAmount}," +
                $" the maximum fuel capacity is: {this.m_maximumFuelCapacity}");
        }
    }
}

