namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_05_FactorialZeros;

  [TestClass]
  public class Problem_16_05_FactorialZerosTests
  {
    [TestMethod]
    public void BasicTest()
    {
      Solution.Execute(20).Should().Be(4);
    }
  }
}
