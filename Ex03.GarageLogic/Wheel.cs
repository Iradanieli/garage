using System;

namespace EX03.GarageLogic
{
    public class Wheel
    {
        private String m_manufacturer;
        private float m_currentAirPressure;
        private float m_maximumAirPressure;

        public String manufacturer
        {
            get { return m_manufacturer; }
            set { m_manufacturer = value; }
        }

        public float airPressure
        {
            get { return m_currentAirPressure; }
            set { m_currentAirPressure = value; }
        }

        public float maximumAirPressure
        {
            get { return m_maximumAirPressure; }
            set { m_maximumAirPressure = value; }
        }

        public Wheel(String manufacturer, float airPressure, float maximumAirPressure)
        {
            this.m_manufacturer = manufacturer;
            this.m_currentAirPressure = airPressure;
            this.m_maximumAirPressure = maximumAirPressure;
        }

        public void inflate(float airToInflate)
        {
            if (this.m_currentAirPressure + airToInflate > this.maximumAirPressure)
            {
                throw new ValueOutOfRangeException(m_maximumAirPressure - m_currentAirPressure);
            }
            else
            {
                this.m_currentAirPressure += airToInflate;
            }
        }

        public string SoleWheelToString()
        {
            return ($"Manufacturer: {this.m_manufacturer}, air pressure: {this.m_currentAirPressure}");
        }
    }
}

