namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Chapter_17_01_AddWithoutPlus;

  [TestClass]
  public class Chapter_17_01_AddWithoutPlusTests
  {
    [TestMethod]
    public void AddTest()
    {
      Solution.Execute(5, 3).Should().Be(8);
    }

    [TestMethod]
    public void NegativeResultTest()
    {
      Solution.Execute(-5, 3).Should().Be(-2);
    }

    [TestMethod]
    public void BothNegativeTest()
    {
      Solution.Execute(-5, -3).Should().Be(-8);
    }
  }
}
