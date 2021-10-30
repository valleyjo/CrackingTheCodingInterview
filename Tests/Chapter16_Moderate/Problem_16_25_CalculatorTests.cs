namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter16_Moderate.Problem_16_26_Calculator;

  [TestClass]
  public class Chapter_16_26_CalculatorTests
  {
    [TestMethod]
    public void OneOpTest()
    {
      Solution.Execute("5*3").Should().Be(15.0d);
    }

    [TestMethod]
    public void TwoOpTest()
    {
      Solution.Execute("5*3+4").Should().Be(19.0d);
    }

    [TestMethod]
    public void SameOpTest()
    {
      Solution.Execute("5+3+1+7+4").Should().Be(20.0d);
    }

    [TestMethod]
    public void DescendingPriorityTest()
    {
      Solution.Execute("5-2+4/5*2").Should().Be(2.6d);
    }

    [TestMethod]
    public void AscendingPriorityTest()
    {
      Solution.Execute("2*5/4+2-5").Should().Be(-0.5d);
    }

    [TestMethod]
    public void MultiDigitNumberTest()
    {
      Solution.Execute("2*215").Should().Be(430d);
    }

    [TestMethod]
    public void DecimalDigitTest()
    {
      Solution.Execute("2.05*215").Should().BeApproximately(440.75d, 0.1d);
    }
  }
}
