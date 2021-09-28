namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using System;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Problem_2_4_Partition;

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
      var partitionedList = Problem.Execute(list, 5);
      partitionedList.ToString().Should().Be("(1) -> (2) -> (5)");
    }
  }
}
