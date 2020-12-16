namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using CrackingTheCodingInterview.Problems.Chapter2_LinkedLists;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = Chapter2_LinkedLists.Problem_2_2_ReturnKthToLast;

  [TestClass]
  public class Problem_2_2_ReturnKthToLastTests
  {
    [TestMethod]
    public void NullText()
    {
      Action act = () => Problem.Execute(null, -1);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void NegativeParamTest()
    {
      Action act = () => Problem.Execute(new AListNode<int>(), -1);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void KIsZeroTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, });
      Problem.Execute(head, 0).Should().Be(3);
    }

    [TestMethod]
    public void KIsLargerThanListLengthTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Action act = () => Problem.Execute(head, 10);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void KthToLastTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Problem.Execute(head, 3).Should().Be(4);
    }

    [TestMethod]
    public void KIsListLength()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5, 6, });
      Problem.Execute(head, 7).Should().Be(0);
    }
  }
}
