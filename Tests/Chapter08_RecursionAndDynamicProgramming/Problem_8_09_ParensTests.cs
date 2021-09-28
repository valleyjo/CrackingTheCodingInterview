namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_09_Parens;

  [TestClass]
  public class Problem_8_09_ParensTests
  {
    [TestMethod]
    public void EmptyTest() => Solution.Execute(0).Should().BeEquivalentTo(new List<string>() { string.Empty });

    [TestMethod]
    public void OnePairTest() => Solution.Execute(1).Should().BeEquivalentTo(new List<string>() { "()" });

    [TestMethod]
    public void TwoPairsTest() => Solution.Execute(2).Should().BeEquivalentTo(new List<string>() { "(())", "()()", });

    [TestMethod]
    public void ThreePairsTest() => Solution.Execute(3).Should().BeEquivalentTo(new List<string>() { "()()()", "(())()", "((()))", "()(())", "(()())", });
  }
}
