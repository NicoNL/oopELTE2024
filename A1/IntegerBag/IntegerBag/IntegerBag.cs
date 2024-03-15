using System;

namespace IntegerBag
{
    public class IntegerBag
    {
        #region Exceptions
        public class NonExistingElementException : Exception { }
        public class EmptyBagException : Exception { }
        #endregion

        #region Attributes

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
            int index;
            if (contains(in element, out index))
            {
                intList[index].IncrementFrequency();
                if (maxIndexFre != index && intList[index].Frequency > intList[maxIndexFre].Frequency)
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
            int index;
            if (!contains(element, out index)) throw new NonExistingElementException();
            intList[index].DecreaseFrequency();
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
            int index;
            if (!contains(element, out index)) throw new NonExistingElementException();
            return intList[index].Frequency;
        }
        public int mostFrequent(out int element, out int frequency)
        {
            if (intList.Count() == 0) throw new EmptyBagException();
            element = intList[maxIndexFre].Number;
            frequency = intList[maxIndexFre].Frequency;
            return maxIndexFre;
        }

        #endregion

        #region Complementary Methods

        private void MaximumSearch()
        {
            int maxFre = 0;
            for (int i = 0; i < intList.Count(); i++)
            {
                if (maxFre < intList[i].Frequency)
                {
                    maxIndexFre = i;
                    maxFre = intList[i].Frequency;
                }
            }
        }
        private bool contains(in int element, out int index)
        {
            //The method iterates trough every element of the list until it finds the expected element
            for(int i = 0; i < intList.Count(); i++)
            {
                if (intList[i].Number == element)
                {
                    index = i;
                    return true;
                    //The search was successful
                }
            }
            //The search was unsuccessful
            // If the search was not successful then it will return false and the index will be -1;
            // Even though the index is -1, when false is returned, there would be an exception which
            // will be catch or if it is an insertion, the element will be created with a frequency
            // of 1
            index = -1;
            return false;
        }
        public bool isEmpty()
        {
            return intList.Count() == 0;
        }
        // The method takes a bool, so it check if the frequency should be printed as well
        public string ToStringElements(bool plusFrequency)
        {
            string setString = "[ ";
            for (int i = 0; i < intList.Count(); i++)
            {
                if (i < intList.Count() - 1)
                {
                    setString += "(";
                    setString += intList[i].Number;
                    if(plusFrequency)
                    {
                        setString += ",";
                        setString += intList[i].Frequency;
                    }
                    setString += ")";
                    setString += ", ";
                }
                else
                {
                    setString += "(";
                    setString += intList[i].Number;
                    if (plusFrequency)
                    {
                        setString += ",";
                        setString += intList[i].Frequency;
                    }
                    setString += ")";
                }
            }
            setString += "]";
            return setString;
        }
        #endregion
    }
}