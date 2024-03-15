using System;
using System.Collections.Generic;

namespace IntegerBag
{
    public class numberFrequency
    {
        #region Attributes
        private int number;
        private int frequency;
        #endregion

        #region Properties
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        #endregion

        #region Methods
        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }
        public void IncrementFrequency()
        {
            this.frequency++;
        }
        public void DecreaseFrequency()
        {
            this.frequency--;
        }
        public numberFrequency(int num, int feq)
        {
            number = num;
            frequency = feq;
        }
        #endregion
    }
}
