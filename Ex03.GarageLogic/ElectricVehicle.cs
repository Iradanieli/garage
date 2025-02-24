using System;
using System.Collections.Generic;

namespace EX03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        protected float m_batteryTimeLeft;
        protected float m_batteryMaximumTime;

        public float batteryTimeLeft
        {
            get { return m_batteryTimeLeft; }
            set { m_batteryTimeLeft = value; }
        }

        public float batteryMaximumTime
        {
            get { return m_batteryMaximumTime; }
            set { m_batteryMaximumTime = value; }
        }

        public ElectricVehicle(String model, String licenseNumber)      ///constructor the recieves only 2 fields
            : base(model, licenseNumber)
        {

        }


        public ElectricVehicle(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels, float batteryTimeLeft, float batteryMaximumTime)
           : base(model, licenseNumber, energyLeftPercentage, wheels)
        {
            this.m_batteryTimeLeft = batteryTimeLeft;
            this.m_batteryMaximumTime = batteryMaximumTime;
        }

        public void chargeBattery(float additionalChargeTime)
        {
            if (this.m_batteryTimeLeft + additionalChargeTime > this.m_batteryMaximumTime)
            {
                throw new ValueOutOfRangeException(m_batteryMaximumTime - m_batteryTimeLeft);
            }
            else
            {
                this.m_batteryTimeLeft += additionalChargeTime;
            }
        }

        override public string ToString()
        {
            return ($"{base.ToString()}, the battery time left is: {this.m_batteryTimeLeft}, the battery maximum time is: {this.m_batteryMaximumTime}");
        }
    }
}

