namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Problem_2_3_DeleteMiddleNode;

  [TestClass]
  public class Problem_2_3_DeleteMiddleNodeTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action act = () => Problem.Execute(null);
      act.Should().NotThrow();
    }

    [TestMethod]
    public void EndTest()
    {
      var list = AListNode<int>.FromArray(new int[] { 0 });
      Action act = () => Problem.Execute(list);
      act.Should().NotThrow();
    }

    [TestMethod]
    public void RemoveMiddleTest()
    {
      var list = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, 5 });
      AListNode<int> middle = list.Next;
      Problem.Execute(middle);
      list.ToString().Should().Be("(0) -> (2) -> (3) -> (4) -> (5)");
    }

    [TestMethod]
    public void RemoveSecondToLastTest()
    {
      var list = AListNode<int>.FromArray(new int[] { 0, 1, });
      Problem.Execute(list);
      list.ToString().Should().Be("(1)");
    }
  }
}
