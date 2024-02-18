
namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPutIn()
        {
            Bag b = new Bag(2);
            b.PutIn(1);
            Assert.AreEqual(b.MostFrequent(), 1);
            b.PutIn(2);
            b.PutIn(2);
            Assert.AreEqual(b.MostFrequent(), 2);
        }

        [TestMethod]
        public void TestBag_NegativeParam()
        {
            Assert.ThrowsException<Bag.NegativeSizeException>(() => new Bag(-2));

        }
    }
}