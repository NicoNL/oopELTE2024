using System.Runtime.Intrinsics.X86;

namespace IntegerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void insertTest()
        {
            IntegerBag.IntegerBag b1 = new IntegerBag.IntegerBag();
            b1.insertInt(2);
            b1.insertInt(12);
            b1.insertInt(20);
            b1.insertInt(102);

            //Check if the bag is Empty
            Assert.IsFalse(b1.isEmpty());
        }
        [TestMethod]
        public void removeTest()
        {
            IntegerBag.IntegerBag b1 = new IntegerBag.IntegerBag();
            try
            {
                b1.removeInt(2);
                Assert.Fail("No exception thrown");
            }
            catch(Exception e)
            {
                //Exception in case the bag is Empty when using remove
                Assert.IsTrue(e is IntegerBag.IntegerBag.EmptyBagException);
            }
            b1.insertInt(1);
            try
            {
                b1.removeInt(2);
                Assert.Fail("No exception thrown");
            }
            catch (Exception e)
            {
                //Exception in case the given element is not in the bag
                Assert.IsTrue(e is IntegerBag.IntegerBag.NonExistingElementException);
            }
            b1.insertInt(2);
            b1.insertInt(3);

            b1.removeInt(1);
            b1.removeInt(2);
            b1.removeInt(3);
            //Test to check if all of the elements were removed
            Assert.IsTrue(b1.isEmpty());
        }
        [TestMethod]
        public void frequencyTest()
        {
            IntegerBag.IntegerBag b1 = new IntegerBag.IntegerBag();
            try
            {
                b1.frequencyOf(2);
                Assert.Fail("No Exception thrown");

            }catch(Exception e)
            {
                //Exception in case the bag is empty
                Assert.IsTrue(e is IntegerBag.IntegerBag.EmptyBagException);
            }
            b1.insertInt(1);
            try
            {
                b1.frequencyOf(2);
                Assert.Fail("No Exception thrown");

            }
            catch (Exception e)
            {
                //Exception in case the element is not in the bag
                Assert.IsTrue(e is IntegerBag.IntegerBag.NonExistingElementException);
            }
            b1.insertInt(1);
            b1.insertInt(2);
            b1.insertInt(2);
            //Test to check if the frequency of 1 is 2 after inserting it to the bag two times
            Assert.IsTrue(b1.frequencyOf(1) == 2);
        }
        [TestMethod]
        public void mostFrequentTest()
        {
            IntegerBag.IntegerBag b1 = new IntegerBag.IntegerBag();
            try
            {
                //These INTs are declared for obtaining the element and the frequency of the element plus the index
                int elem, fre;
                b1.mostFrequent(out elem,out fre);
                Assert.Fail("No Exception thrown");
            }
            catch (Exception e)
            {
                //Exception in case the bag is empty
                Assert.IsTrue(e is IntegerBag.IntegerBag.EmptyBagException);
            }
            b1.insertInt(3);
            b1.insertInt(3);
            b1.insertInt(3);
            b1.insertInt(2);
            b1.insertInt(2);
            b1.insertInt(1);
            int element, frequency;
            //Test to check if 3 is the most frequent element, its index is 0
            int index = b1.mostFrequent(out element, out frequency);
            Assert.IsTrue( index == 0);
            //Test to check if element is the most frequent element, which is 3 in this case
            Assert.IsTrue(element == 3);
            //Test to check if frequency is 3, which is the frequency of 3
            Assert.IsTrue(frequency == 3);

            //Now 2 has the current max frequency as 3. However, as 3 was the first max it
            //will remain as the current max
            b1.insertInt(2);
            index = b1.mostFrequent(out element, out frequency);
            //Test to check if 3 is the most frequent element, its index is 0
            Assert.IsTrue(index == 0);
            //Test to check if element is the most frequent element
            Assert.IsTrue(element == 3);
            Assert.IsTrue(frequency == 3);

            b1.insertInt(2);
            index = b1.mostFrequent(out element, out frequency);
            //Test to check if now 2 is the most frequent element, its index is 1
            Assert.IsTrue(index == 1);
            //Test to check if 2 is the most frequent element
            Assert.IsTrue(element == 2);
            Assert.IsTrue(frequency == 4);

            b1.removeInt(2);
            b1.removeInt(2);

            index = b1.mostFrequent(out element, out frequency);
            //Test to check if 3 is now the most frequent element
            Console.WriteLine(element);
            Assert.IsTrue(index == 0);
            Assert.IsTrue(element == 3);
            Assert.IsTrue(frequency == 3);
        }
        [TestMethod]
        public void stringTest()
        {
            IntegerBag.IntegerBag b1 = new IntegerBag.IntegerBag();
            //Test to check if the representation of the Bag is an Empty set
            //We use this bool to have a complete representation of
            // the bag
            bool withFrequency = true;
            Assert.IsTrue(b1.ToStringElements(withFrequency) == "[ ]");

            b1.insertInt(1);
            b1.insertInt(2);
            b1.insertInt(2);
            //Test to check if the representation of the Bag contains the inserted Elements
            Assert.IsTrue(b1.ToStringElements(withFrequency) == "[ (1,1), (2,2)]");

            b1.removeInt(1);
            b1.removeInt(2);
            b1.removeInt(2);
            //Test to check if the representation of the Bag is empty again
            Assert.IsTrue(b1.ToStringElements(withFrequency) == "[ ]");
        }
        //Test method of Contains was not added because it is a private method
        //and since it needs two parameters user should not deal with these
        //two expected parameters
    }
}