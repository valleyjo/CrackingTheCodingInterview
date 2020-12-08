namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem = Problem_1_8_ZeroMatrix;

    [TestClass()]
    public class Problem_1_8_ZeroMatrixTests
    {
        [TestMethod()]
        public void OneZeroTest()
        {
            var matrix = new int[,]
            {
                { 1, 0, 1, 1, },
                { 1, 1, 1, 1, },
                { 1, 1, 1, 1, },
            };

            var zeroedMatrix = new int[,]
            {
                { 0, 0, 0, 0, },
                { 1, 0, 1, 1, },
                { 1, 0, 1, 1, },
            };


            Problem.Execute(matrix);
            matrix.Should().BeEquivalentTo(zeroedMatrix);
        }

        [TestMethod()]
        public void TwoZeroTest()
        {
            var matrix = new int[,]
            {
                { 1, 0, 1, 1, },
                { 1, 1, 0, 1, },
                { 1, 1, 1, 1, },
            };

            var zeroedMatrix = new int[,]
            {
                { 0, 0, 0, 0, },
                { 0, 0, 0, 0, },
                { 1, 0, 0, 1, },
            };

            Problem.Execute(matrix);
            matrix.Should().BeEquivalentTo(zeroedMatrix);
        }
    }
}
