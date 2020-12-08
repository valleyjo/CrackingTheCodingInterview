namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
    using CrackingTheCodingInterview.Problems.DataStructures;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem = Problem_2_1_RemoveDups;

    [TestClass()]
    public class Problem_2_1_RemoveDupsTests
    {
        [TestMethod()]
        public void DupInMiddleTest()
        {
            var original = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, 4, });
            Problem.Execute(original);
            original.ToString().Should().Be("(0) -> (1) -> (2) -> (3) -> (4)");
        }

        [TestMethod()]
        public void DupInEndTest()
        {
            var original = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, });
            Problem.Execute(original);
            original.ToString().Should().Be("(0) -> (1) -> (2) -> (3)");
        }

        [TestMethod]
        public void AllDupsTest()
        {
            var original = AListNode<int>.FromArray(new int[] { 1, 1, 1, 1, 1, });
            Problem.Execute(original);
            original.ToString().Should().Be("(1)");
        }

        [TestMethod]
        public void DupAtStartTest()
        {
            var original = AListNode<int>.FromArray(new int[] { 0, 0, 1, });
            Problem.Execute(original);
            original.ToString().Should().Be("(0) -> (1)");
        }
    }
}
