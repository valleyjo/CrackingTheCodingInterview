namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
    using System;
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
            var originalOne = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, 4, });
            var originalTwo = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, 4, });
            Problem.ExecuteWithoutSpace(originalOne);
            Problem.ExecuteWithSpace(originalTwo);
            originalOne.ToString().Should().Be("(0) -> (1) -> (2) -> (3) -> (4)");
            originalTwo.ToString().Should().Be("(0) -> (1) -> (2) -> (3) -> (4)");
        }

        [TestMethod()]
        public void DupInEndTest()
        {
            var originalOne = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, });
            var originalTwo = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 3, });
            Problem.ExecuteWithSpace(originalOne);
            Problem.ExecuteWithoutSpace(originalTwo);
            originalOne.ToString().Should().Be("(0) -> (1) -> (2) -> (3)");
            originalTwo.ToString().Should().Be("(0) -> (1) -> (2) -> (3)");
        }

        [TestMethod]
        public void AllDupsTest()
        {
            var originalOne = AListNode<int>.FromArray(new int[] { 1, 1, 1, 1, 1, });
            var originalTwo = AListNode<int>.FromArray(new int[] { 1, 1, 1, 1, 1, });
            Problem.ExecuteWithSpace(originalOne);
            Problem.ExecuteWithoutSpace(originalTwo);
            originalOne.ToString().Should().Be("(1)");
            originalTwo.ToString().Should().Be("(1)");
        }

        [TestMethod]
        public void DupAtStartTest()
        {
            var originalOne = AListNode<int>.FromArray(new int[] { 0, 0, 1, });
            var originalTwo = AListNode<int>.FromArray(new int[] { 0, 0, 1, });
            Problem.ExecuteWithSpace(originalOne);
            Problem.ExecuteWithoutSpace(originalTwo);
            originalOne.ToString().Should().Be("(0) -> (1)");
            originalTwo.ToString().Should().Be("(0) -> (1)");
        }

        [TestMethod]
        public void NullTest()
        {
            Action actOne = () => Problem.ExecuteWithSpace(null);
            actOne.Should().NotThrow<NullReferenceException>();
            Action actTwo = () => Problem.ExecuteWithoutSpace(null);
            actTwo.Should().NotThrow<NullReferenceException>();
        }
    }
}
