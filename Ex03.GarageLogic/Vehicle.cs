using System;
using System.Collections.Generic;
namespace EX03.GarageLogic
{
    public class Vehicle
    {
        protected String m_model;
        protected String m_licenseNumber;
        protected float m_energyLeftPercentage;
        protected List<Wheel> m_wheels;

        public String model
        {
            get { return m_model; }
            set { m_model = value; }
        }

        public String licenseNumber
        {
            get { return m_licenseNumber; }
            set { m_licenseNumber = value; }
        }

        public float energyLeftPercentage
        {
            get { return m_energyLeftPercentage; }
            set { m_energyLeftPercentage = value; }
        }

        public List<Wheel> wheels
        {
            get { return m_wheels; }
            set { m_wheels = value; }
        }

        public Vehicle(String model, String licenseNumber)      ///constructor the recieves only 2 fields
        {
            this.m_model = model;
            this.m_licenseNumber = licenseNumber;
            this.m_wheels = new List<Wheel>(); ///default

        }

        public Vehicle(String model, String licenseNumber, float energyLeftPercentage, List<Wheel> wheels)
        {
            this.m_model = model;
            this.m_licenseNumber = licenseNumber;
            this.m_energyLeftPercentage = energyLeftPercentage;
            this.m_wheels = wheels;
        }

        public string WheelstoString()
        {
            string toReturn = "";
            int i = 1;
            foreach (Wheel currentWheel in this.m_wheels)
            {
                toReturn += $"\nwheel number {i}: {currentWheel.SoleWheelToString()}.";
                i++;
            }
            toReturn += "\n";
            return toReturn;
        }

        override public string ToString()
        {
            return ($"The model is: {this.m_model}, the license number is: {this.m_licenseNumber}, the energy left percentage is: {this.m_energyLeftPercentage}%," +
                $" {WheelstoString()} ");
        }
    }
}

