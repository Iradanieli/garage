using System;
namespace EX03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return MaxValue; }
            set { MaxValue = value; }
        }

        public ValueOutOfRangeException(float maxValue)
        {
            this.m_MinValue = 0;
            this.m_MaxValue = maxValue;
        }

        public override string Message
        {
            get
            {
                return String.Format("Value is out of range. Minimum value allowed: {0}. Maximum value allowed: {1}.", m_MinValue, m_MaxValue);
            }
        }
    }
}

