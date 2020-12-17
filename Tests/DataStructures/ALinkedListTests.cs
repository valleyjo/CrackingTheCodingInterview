namespace CrackingTheCodingInterview.Tests.DataStructures
{
    using CrackingTheCodingInterview.Problems.DataStructures;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ALinkedListTests
    {
        [TestMethod]
        public void ToStringSingleNodeTest()
        {
            var head = new AListNode<int>(5);
            head.ToString().Should().Be("(5)");
        }

        [TestMethod]
        public void ToStringManyNodeTest()
        {
            var head = new AListNode<int>(5);

            var nextNode = new AListNode<int>(4);
            head.Next = nextNode;

            var nextNextNode = new AListNode<int>(3);
            nextNode.Next = nextNextNode;

            head.ToString().Should().Be("(5) -> (4) -> (3)");
        }

        [TestMethod]
        public void FromArrayTest()
        {
            var actual = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, });

            var expected = new AListNode<int>(0);

            var nextNode = new AListNode<int>(1);
            expected.Next = nextNode;

            var nextNextNode = new AListNode<int>(2);
            nextNode.Next = nextNextNode;

            var nextNextNextNode = new AListNode<int>(3);
            nextNextNode.Next = nextNextNextNode;

            actual.ToString().Should().Be(expected.ToString());
        }
    }
}
