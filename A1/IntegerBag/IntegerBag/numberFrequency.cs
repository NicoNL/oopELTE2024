using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerBag
{
    public class numberFrequency
    {
        private int number;
        private int frequency;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
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
    }
}
