using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace IntegerBag
{
    public class IntegerBag
    {
        #region Exceptions
        public class NonExistingElementException : Exception { }
        public class EmptyBagException : Exception { }
        #endregion

        #region Attributes
        private struct numberFrequency
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
                this.frequency += 1;
            }
            public void DecreaseFrequency()
            {
                this.frequency -= 1;
            }
            public numberFrequency(int num, int feq)
            {
                number = num;
                frequency = feq;
            }
        }

        private List<numberFrequency> intList;
        private int maxIndexFre;
        #endregion

        #region Constructors
        public IntegerBag()
        {
            intList = new List<numberFrequency>();
            maxIndexFre = 0;
        }
        #endregion

        #region Methods
        public void insertInt(int element)
        {
            int index = intList.FindIndex(n => n.Number == element);

            if (index != -1)
            {
                intList[index] = new numberFrequency(element, intList[index].Frequency +1);
                if (maxIndexFre != index && intList[index].Frequency > maxIndexFre)
                {
                    maxIndexFre = index;
                }
            }
            else
            {
                numberFrequency newNumber = new numberFrequency(element,1);
                intList.Add(newNumber);
            }
        }
        public void removeInt(int element)
        {
            if (intList.Count() == 0) throw new EmptyBagException();
            int index = intList.FindIndex(n => n.Number == element);
            if (index == -1) throw new NonExistingElementException();

            intList[index] = new numberFrequency(element, intList[index].Frequency - 1);
            if (maxIndexFre == index)
            {
                MaximumSearch();
            }
            if(intList[index].Frequency == 0)
            {
                intList.RemoveAt(index);
            }
        }
        public int frequencyOf(int element)
        {
            if (intList.Count() == 0) throw new EmptyBagException();
            int index = intList.FindIndex(n => n.Number == element);
            if (index == -1) throw new NonExistingElementException();
            return intList[index].Frequency;
        }
        public int mostFrequent(out int element, out int frequency)
        {
            if (intList.Count() == 0) throw new EmptyBagException();
            element = intList[maxIndexFre].Number;
            frequency = intList[maxIndexFre].Frequency;
            return maxIndexFre;
        }

        private void MaximumSearch()
        {
            for(int i = 0; i < intList.Count(); i++)
            {
                int maxFre = 0;
                if (maxFre < intList[i].Frequency)
                {
                    maxIndexFre = i;
                    maxFre = intList[i].Frequency;
                }
            }
        }

        #endregion

        #region Complementary Methods
        public bool isEmpty()
        {
            return intList.Count() == 0;
        }
        public override string ToString()
        {
            string setString = "[ ";
            for (int i = 0; i < intList.Count(); i++)
            {
                if (i < intList.Count() - 1)
                {
                    setString += "(";
                    setString += intList[i].Number;
                    setString += ",";
                    setString += intList[i].Frequency;
                    setString += ")";
                    setString += ", ";
                }
                else
                {
                    setString += "(";
                    setString += intList[i].Number;
                    setString += ",";
                    setString += intList[i].Frequency;
                    setString += ")";
                }
            }
            setString += "]";
            return setString;
        }
        #endregion
    }
}