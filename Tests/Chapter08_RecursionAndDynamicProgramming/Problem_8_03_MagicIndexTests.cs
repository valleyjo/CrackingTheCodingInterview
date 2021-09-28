namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_03_MagicIndex;

  [TestClass]
  public class Problem_8_03_MagicIndexTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().Be(-1);

    [TestMethod]
    public void EmptyTest() => Solution.Execute(Array.Empty<int>()).Should().Be(-1);

    [TestMethod]
    public void DoesNotExistTest() => Solution.Execute(new int[] { -1, 0, 1, 4, 5, 6, }).Should().Be(-1);

    [TestMethod]
    public void ExistsInRightTest() => Solution.Execute(new int[] { -1, 0, 1, 2, 3, 5, 10, 12, 13 }).Should().Be(5);

    [TestMethod]
    public void ExistsInLeftTest() => Solution.Execute(new int[] { -1, 0, 2, 4, 5, 8, 10, 12, 13 }).Should().Be(2);

    [TestMethod]
    public void ExistsAtStartTest() => Solution.Execute(new int[] { 0, 2, 4, 5, 8, 10, 12, 13 }).Should().Be(0);

    [TestMethod]
    public void ExistsAtEndTest() => Solution.Execute(new int[] { -1, 0, 1, 2, 3, 4, 5, 7 }).Should().Be(7);
  }
}
