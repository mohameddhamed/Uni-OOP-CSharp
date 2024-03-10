// using System.Numerics;
using PriorityQueue;

namespace TestPriorityQueue
{
    [TestClass]
    public class TestPrQueue
    {
        [TestMethod]
        public void TestAdd()
        {
            ///Items for testing
            Item e1 = new Item(1, "a");
            Item e2 = new Item(2, "b");

            PriQueue Q = new PriQueue();
            Assert.IsTrue(Q.IsEmpty());
            Q.Add(e1);
            Assert.AreEqual(1, Q.GetLength());
            Q.Add(e2);
            Assert.AreEqual(2, Q.GetLength());
        }

        [TestMethod]
        public void TestGetMax()
        {
            ///maxindex and remMax
            PriQueue Q = new PriQueue();
            try
            {
                Q.GetMax();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is PriQueue.EmptyPriQueueException);
            }

            ///Items for testing
            Item e1 = new Item(1, "a");
            Item e2 = new Item(2, "b");
            Item e3 = new Item(3, "c");
            Item e4 = new Item(5, "a");
            Item e5 = new Item(5, "d");

            //one max
            Q.Add(e1); Q.Add(e2); Q.Add(e3); Q.Add(e4);
            Item m1 = Q.GetMax();
            Assert.AreEqual(m1, e4);
            // more max
            Q.Add(e5);
            Item m2 = Q.GetMax();
            Assert.AreEqual(m2, e4);

        }

        [TestMethod]
        public void TestRemoveMax()
        {

            PriQueue Q = new PriQueue();
            try
            {
                Q.RemoveMax();
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is PriQueue.EmptyPriQueueException);
            }


            Item e1 = new Item(1, "a");
            Item e2 = new Item(2, "b");
            Item e3 = new Item(3, "c");
            Item e4 = new Item(5, "a");
            Item e5 = new Item(5, "d");

            //one max
            Q.Add(e1); Q.Add(e2); Q.Add(e3); Q.Add(e4);
            Item m1 = Q.RemoveMax();
            Assert.AreEqual(m1, e4);
            Assert.AreEqual(3, Q.GetLength());
            // more max
            Q.Add(e4);
            Q.Add(e5);
            Item m2 = Q.RemoveMax();
            Assert.AreEqual(m2, e4);
            Assert.AreEqual(4, Q.GetLength());

        }
    }
}