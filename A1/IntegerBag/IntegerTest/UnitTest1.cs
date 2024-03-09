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
            Assert.IsTrue(!b1.isEmpty());
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
            b1.insertInt(4);

        }
    }
}