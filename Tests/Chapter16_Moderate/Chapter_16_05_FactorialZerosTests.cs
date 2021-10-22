namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_05_FactorialZeros;

  [TestClass]
  public class Chapter_16_05_FactorialZerosTests
  {
    [TestMethod]
    public void BasicTest()
    {
      Solution.Execute(20).Should().Be(4);
    }
  }
}
