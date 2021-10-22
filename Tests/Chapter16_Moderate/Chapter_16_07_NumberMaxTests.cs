namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Chapter_16_07_NumberMax;

  [TestClass]
  public class Chapter_16_07_NumberMaxTests
  {
    [TestMethod]
    public void PositiveTest() => Solution.Execute(5, 7).Should().Be(7);

    [TestMethod]
    public void ZeroTest() => Solution.Execute(0, 0).Should().Be(0);

    [TestMethod]
    public void NegativeTest() => Solution.Execute(-5, -7).Should().Be(05);
  }
}
