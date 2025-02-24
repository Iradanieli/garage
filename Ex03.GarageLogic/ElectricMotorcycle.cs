using System;
using System.Collections.Generic;
namespace EX03.GarageLogic
{
    public class ElectricMotorcycle : ElectricVehicle
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

        public ElectricMotorcycle(String model, String licenseNumber)      ///constructor the recieves only 2 fields
         : base(model, licenseNumber)
        {
        }

        public ElectricMotorcycle(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, float batteryTimeLeft, float batteryMaximumTime, MotorcycleLicense licenseType, int engineCapacity)
            : base(model, licenseNumber, energyLeftPercentage, wheels, batteryTimeLeft, batteryMaximumTime)
        {
            this.m_licenseType = licenseType;
            this.m_engineCapacity = engineCapacity;
        }

        public void FillFields(float energyLeftPercentage, List<Wheel> wheels, float batteryTimeLeft, float batteryMaximumTime, MotorcycleLicense licenseType, int engineCapacity)
        {
            ///vehicle fields
            this.energyLeftPercentage = energyLeftPercentage;
            this.m_wheels = wheels;
            ///electric vehicles fields
            this.batteryTimeLeft = batteryTimeLeft;
            this.m_batteryMaximumTime = batteryMaximumTime;
            ///motorcycle fields
            this.m_licenseType = licenseType;
            this.engineCapacity = engineCapacity;
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the license type is: {this.m_licenseType.ToString()}, the engine capacity is: {this.m_engineCapacity}");
        }
    }
}

