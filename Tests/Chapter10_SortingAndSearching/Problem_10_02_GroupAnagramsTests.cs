﻿namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_02_GroupAnagrams;

  [TestClass]
  public class Problem_10_02_GroupAnagramsTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().BeNull();

    [TestMethod]
    public void EmptyTest() => Solution.Execute(new string[0]).Should().BeEquivalentTo(new string[0]);

    [TestMethod]
    public void MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.Execute(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }

    [TestMethod]
    public void Sorting_NullATest() => Solution.ExecuteWithSorting(null).Should().BeNull();

    [TestMethod]
    public void Sorting_EmptyTest() => Solution.ExecuteWithSorting(new string[0]).Should().BeEquivalentTo(new string[0]);

    [TestMethod]
    public void Sorting_MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.ExecuteWithSorting(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }

    [TestMethod]
    public void SortingWithMap_NullATest() => Solution.ExecuteMapWithSorting(null).Should().BeNull();

    [TestMethod]
    public void SortingWithMap_EmptyTest() => Solution.ExecuteMapWithSorting(new string[0]).Should().BeEquivalentTo(new string[0]);

    [TestMethod]
    public void SortingWithMap_MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.ExecuteMapWithSorting(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }
  }
}
