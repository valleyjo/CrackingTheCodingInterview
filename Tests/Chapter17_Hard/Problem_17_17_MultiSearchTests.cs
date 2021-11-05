namespace CrackingTheCodingInterview.Problems.Chapter17_Hard.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter17_Hard.Problem_17_17_MultiSearch;

  [TestClass]
  public class Problem_17_17_MultiSearchTests
  {
    [TestMethod]
    public void NullTest()
    {
      Solution.Execute(null, null).Should().BeEquivalentTo(new List<Solution.Match>());
    }

    [TestMethod]
    public void EmptyTest()
    {
      Solution.Execute(string.Empty, Array.Empty<string>()).Should().BeEquivalentTo(new List<Solution.Match>());
    }

    [TestMethod]
    public void NoMatchesTest()
    {
      Solution.Execute("freddy", new string[] { "z", "ba", "del", });
    }

    [TestMethod]
    public void MultipleMatchesTest()
    {
      var expected = new List<Solution.Match>()
      {
        new Solution.Match(0, 4, "miss"),
        new Solution.Match(1, 4, "iss"),
        new Solution.Match(4, 6, "iss"),
        new Solution.Match(9, 10, "pp"),
        new Solution.Match(1, 1, "i"),
        new Solution.Match(1, 1, "i"),
        new Solution.Match(5, 5, "i"),
        new Solution.Match(7, 7, "i"),
        new Solution.Match(10, 10, "i"),
      };

      Solution.Execute("mississippi", new string[] { "miss", "iss", "pp", "i", });
    }
  }
}
