namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Problem_2_2_ReturnKthToLast;

  [TestClass]
  public class Problem_2_2_ReturnKthToLastTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action act = () => Problem.ExecuteZeroBased(null, -1);
      act.Should().Throw<ArgumentException>();

      Action actOneBased = () => Problem.ExecuteOneBased(null, -1);
      actOneBased.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void NegativeParamTest()
    {
      Action actZero = () => Problem.ExecuteZeroBased(new AListNode<int>(), -1);
      actZero.Should().Throw<ArgumentException>();

      Action actOne = () => Problem.ExecuteOneBased(new AListNode<int>(), 0);
      actOne.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void ZeroBased_KIsLastTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, });
      Problem.ExecuteZeroBased(head, 0).Should().Be(3);
    }

    [TestMethod]
    public void OneBased_KIsLastTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, });
      Problem.ExecuteOneBased(head, 1).Should().Be(3);
    }

    [TestMethod]
    public void KIsLargerThanListLengthTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Action act = () => Problem.ExecuteZeroBased(head, 10);
      act.Should().Throw<ArgumentException>();
      Action actOne = () => Problem.ExecuteOneBased(head, 10);
      actOne.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void ZeroBased_KthToLastTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, });
      Problem.ExecuteZeroBased(head, 3).Should().Be(2);
    }

    [TestMethod]
    public void OneBased_KthToLastTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Problem.ExecuteOneBased(head, 3).Should().Be(4);
    }

    [TestMethod]
    public void ZeroBased_KIsListLength()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Problem.ExecuteZeroBased(head, 6).Should().Be(0);
    }

    [TestMethod]
    public void OneBased_KIsListLength()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Problem.ExecuteOneBased(head, 7).Should().Be(0);
    }
  }
}
