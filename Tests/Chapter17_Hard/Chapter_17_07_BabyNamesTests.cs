namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_07_BabyNames;

  [TestClass]
  public class Chapter_17_07_BabyNamesTests
  {
    [TestMethod]
    public void BasicTest()
    {
      var namePairs = new List<string>() { "Jon:John", "John:Johnny", "Chris:Kris", "Chris:Christopher" };
      var nameCounts = new List<Problem_17_07_BabyNames.NameFrequency>()
      {
        new Solution.NameFrequency("John", 15),
        new Solution.NameFrequency("Jon", 12),
        new Solution.NameFrequency("Chris", 13),
        new Solution.NameFrequency("Kris", 4),
        new Solution.NameFrequency("Christopher", 19),
      };

      var solution = new List<Solution.NameFrequency>()
      {
        new Solution.NameFrequency("Jon", 27),
        new Solution.NameFrequency("Chris", 36),
      };

      Solution.Execute(nameCounts, namePairs).Should().BeEquivalentTo(solution);
    }
  }
}
