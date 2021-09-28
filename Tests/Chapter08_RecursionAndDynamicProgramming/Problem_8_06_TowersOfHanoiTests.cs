namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_06_TowersOfHanoi;

  [TestClass]
  public class Problem_8_06_TowersOfHanoiTests
  {
    [TestMethod]
    public void ZeroTest() => Solution.Execute(0).Should().BeEquivalentTo(new Stack<int>());

    [TestMethod]
    public void OneTest() => Solution.Execute(1).Should().BeEquivalentTo(new List<int>() { 1 });

    [TestMethod]
    public void TwoTest() => Solution.Execute(2).Should().BeEquivalentTo(new List<int>() { 1, 2, });

    [TestMethod]
    public void ThreeTest() => Solution.Execute(3).Should().BeEquivalentTo(new List<int>() { 1, 2, 3, });

    [TestMethod]
    public void FourTest() => Solution.Execute(4).Should().BeEquivalentTo(new List<int>() { 1, 2, 3, 4, });
  }
}
