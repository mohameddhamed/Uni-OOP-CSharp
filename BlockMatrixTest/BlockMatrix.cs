using BlockMatrixClass;

namespace BlockMatrixTest
{
    [TestClass]
    public class TestPrQueue
    {
        [TestMethod]
        public void MultiplyBlockMatrices()
        {
            BlockMatrix bm1 = new BlockMatrix(2, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            BlockMatrix bm2 = new BlockMatrix(2, 3, new List<int> { 55, 0, 66, 77, 10, 11, 12, 13, 14, 15, 16, 17, 18 });
            BlockMatrix bmR = BlockMatrix.Multiply(bm1, bm2);
            BlockMatrix bmTest = new BlockMatrix(2, 3, new List<int> { 2057, 1694, 4719, 3388, 84, 90, 96, 201, 216, 231, 318, 342, 366 });

            Assert.AreEqual(bmTest.ToString(), bmR.ToString());
        }
        [TestMethod]
        public void AddBlockMatrices()
        {
            BlockMatrix bm1 = new BlockMatrix(2, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            BlockMatrix bm2 = new BlockMatrix(2, 3, new List<int> { 55, 0, 66, 77, 10, 11, 12, 13, 14, 15, 16, 17, 18 });
            BlockMatrix bmR = BlockMatrix.Add(bm1, bm2);
            BlockMatrix bmTest = new BlockMatrix(2, 3, new List<int> { 66, 22, 99, 121, 11, 13, 15, 17, 19, 21, 23, 25, 27 });

            Assert.AreEqual(bmTest.ToString(), bmR.ToString());

            // Adding to a block matrix full of 0s
            BlockMatrix bm0 = new BlockMatrix(2, 3);
            BlockMatrix bmR0 = BlockMatrix.Add(bm0, bm1);

            Assert.AreEqual(bmR0.ToString(), bm1.ToString());
        }
        [TestMethod]
        public void DifferentDimensions()
        {
            BlockMatrix matrix1 = new BlockMatrix(2, 2, new List<int> { 1, 2, 3, 4, 1, 2, 3, 4 });
            BlockMatrix matrix2 = new BlockMatrix(3, 3, new List<int> { 5, 6, 7, 8, 9, 10, 11, 12, 13, 5, 6, 7, 8, 9, 10, 11, 12, 13 });

            try
            {
                BlockMatrix.Add(matrix1, matrix2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is BlockMatrix.NotEqualBlockMatrixDimensionsException);
            }
        }
        [TestMethod]
        public void DifferentDistribution()
        {
            BlockMatrix bm1 = new BlockMatrix(2, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            BlockMatrix bm2 = new BlockMatrix(3, 2, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            try
            {
                BlockMatrix.Add(bm1, bm2);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is BlockMatrix.NotEqualBlockDistributionException);
            }
        }
        [TestMethod]
        public void InvalidSize()
        {
            try
            {
                BlockMatrix bm1 = new BlockMatrix(2, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8 });
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is BlockMatrix.NotValidBlockSizeException);
            }
            try
            {
                BlockMatrix bm2 = new BlockMatrix(3, 3, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is BlockMatrix.NotValidBlockSizeException);
            }
            try
            {
                BlockMatrix bm3 = new BlockMatrix(0, 0, new List<int> { 11, 22, 33, 44, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is BlockMatrix.NotValidBlockSizeException);
            }
        }
    }
}