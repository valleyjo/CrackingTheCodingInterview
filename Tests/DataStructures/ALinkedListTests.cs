namespace CrackingTheCodingInterview.Tests.DataStructures
{
    using CrackingTheCodingInterview.Problems.DataStructures;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class ALinkedListTests
    {
        [TestMethod()]
        public void ToStringSingleNodeTest()
        {
            var head = new AListNode<int>();
            head.Data = 5;
            head.ToString().Should().Be("(5)");
        }

        [TestMethod()]
        public void ToStringManyNodeTest()
        {
            var head = new AListNode<int>();
            head.Data = 5;

            var nextNode = new AListNode<int>();
            head.Next = nextNode;
            nextNode.Data = 4;

            var nextNextNode = new AListNode<int>();
            nextNextNode.Data = 3;
            nextNode.Next = nextNextNode;

            head.ToString().Should().Be("(5) -> (4) -> (3)");
        }

        [TestMethod()]
        public void FromArrayTest()
        {
            var actual = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, });

            var expected = new AListNode<int>();
            expected.Data = 0;

            var nextNode = new AListNode<int>();
            expected.Next = nextNode;
            nextNode.Data = 1;

            var nextNextNode = new AListNode<int>();
            nextNextNode.Data = 2;
            nextNode.Next = nextNextNode;

            var nextNextNextNode = new AListNode<int>();
            nextNextNextNode.Data = 3;
            nextNextNode.Next = nextNextNextNode;

            actual.ToString().Should().Be(expected.ToString());
        }
    }
}
