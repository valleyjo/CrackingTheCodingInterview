namespace CrackingTheCodingInterview.Problems.Special.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Special.Problem_g_04_ScrabbleDecks;

  [TestClass]
  public class Problem_g_04_ScrabbleDeckTests
  {
    [TestMethod]
    public void EnsureNoDuplicatesTest()
    {
      int[] counts = new int[26];

      counts[0] = 2;
      counts[1] = 3;
      counts[3] = 2;
      counts[4] = 4;
      counts[5] = 1;
      List<string> results = Solution.Execute(counts);

      HashSet<string> filteredResults = new();
      foreach (string s in results)
      {
        char[] chars = s.ToCharArray();
        Array.Sort(chars);
        string sorted = new(chars);
        filteredResults.Add(sorted);
      }

      results.Count.Should().Be(filteredResults.Count);
    }
  }
}
