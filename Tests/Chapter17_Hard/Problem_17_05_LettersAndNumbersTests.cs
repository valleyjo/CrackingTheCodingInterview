namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_05_LettersAndNumbers;

  [TestClass]
  public class Problem_17_05_LettersAndNumbersTests
  {
    [TestMethod]
    public void BasicTest()
    {
      Solution.Execute(new char[] { 'a', '1', '1', 'a', '1', }).Should().Be(4);
    }

    [TestMethod]
    public void AllLettersTest()
    {
      Solution.Execute(new char[] { 'a', 'a', 'a', 'a', 'a', }).Should().Be(0);
    }

    [TestMethod]
    public void AllNumbersTest()
    {
      Solution.Execute(new char[] { '1', '1', '1', '1', '1', }).Should().Be(0);
    }
  }
}
