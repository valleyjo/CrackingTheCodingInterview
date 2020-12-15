namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem = Problem_1_7_RotateMatrix;

    [TestClass]
    public class Problem_1_7_RotateMatrixTests
    {
        [TestMethod]
        public void SizeThreeArrayTest()
        {
            var data = new int[][]
            {
                new int[] { 1, 2, 3, },
                new int[] { 4, 5, 6, },
                new int[] { 7, 8, 9, },
            };

            var rotated = new int[][]
            {
                new int[] { 7, 4, 1, },
                new int[] { 8, 5, 2, },
                new int[] { 9, 6, 3, },
            };

            Problem.Execute(data);

            // data.Should().ContainInOrder(rotated);
        }

        [TestMethod]
        public void SizeOneArray()
        {
            var data = new int[][]
            {
                new int[] { 0, },
            };

            var rotated = new int[][]
            {
                new int[] { 0, },
            };

            Problem.Execute(data);

            // data.Should().ContainInOrder(rotated);
        }
    }
}
