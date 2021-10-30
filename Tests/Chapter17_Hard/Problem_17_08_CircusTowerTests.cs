namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_08_CircusTower;

  [TestClass]
  public class Problem_17_08_CircusTowerTests
  {
    [TestMethod]
    public void BasicTest()
    {
      var people = new Solution.Person[]
      {
        new Solution.Person(65, 100),
        new Solution.Person(70, 150),
        new Solution.Person(56, 90),
        new Solution.Person(75, 190),
        new Solution.Person(60, 95),
        new Solution.Person(68, 110),
      };

      Solution.Execute(people).Should().Be(6);
    }
  }
}
