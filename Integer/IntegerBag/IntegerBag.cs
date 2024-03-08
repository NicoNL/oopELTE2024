using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace IntegerBag{
    public class IntegerBag
    {
        #region Exceptions
        public class DuplicateElementException : Exception { }
        public class NonExistingElementException : Exception { }
        public class EmptySetException : Exception { }
        #endregion
        #region Attributes
        private List<int> intSet;
        private int evenCnt;        
        #endregion

        #region Constructors
        public IntegerBag()
        {
            intSet = new List<int>();
            evenCnt = 0;
        }
        #endregion

        #region Methods
        public void insertInt(int element)
        {
            if (intSet.Contains(element)) throw new DuplicateElementException();
            if (element % 2 == 0) evenCnt++;
            intSet.Add(element);
        }
        public void removeInt(int element)
        {
            if (!intSet.Contains(element)) throw new NonExistingElementException();
            if (element % 2 == 0) evenCnt--;
            intSet.Remove(element);
        }
        public bool isEmpty()
        {
            return (intSet.Count == 0) ? true : false;
        }
        public bool isContained(int element)
        {
            bool emptyChecker = isEmpty();
            if (emptyChecker) throw new EmptySetException();
            return (intSet.Contains(element)) ? true : false;
        }
        public int returnRandom()
        {
            bool emptyChecker = isEmpty();
            if (emptyChecker) throw new EmptySetException();
            Random random = new Random();
            int randomIndex = random.Next(intSet.Count()+1);
            return intSet[randomIndex];
        }
        public override string ToString()
        {
            string setString = "[";
            for(int i = 0; i < intSet.Count(); i++)
            {
                if(i < intSet.Count() - 1)
                {
                    setString += intSet[i];
                    setString += ",";
                }
                else{
                    setString += intSet[i];
                }
            }
            setString += "]";
            return setString;
        }

        #endregion



    }
}