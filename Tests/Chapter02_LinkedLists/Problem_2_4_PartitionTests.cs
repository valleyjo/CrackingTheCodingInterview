namespace CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter02_LinkedLists.Problem_2_4_Partition;

  [TestClass]
  public class Problem_2_4_PartitionTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action act = () => Problem.Execute(null, 0);
      act.Should().NotThrow();
    }

    [TestMethod]
    public void PartitionTest()
    {
      var list = AListNode<int>.FromArray(new int[] { 5, 1, 2, });
      AListNode<int> partitionedList = Problem.Execute(list, 5);
      partitionedList.ToString().Should().Be("(1) -> (2) -> (5)");
    }
  }
}
