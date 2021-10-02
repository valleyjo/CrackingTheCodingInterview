namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
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
    public void EmptyTest() => Solution.Execute(System.Array.Empty<string>()).Should().BeEquivalentTo(System.Array.Empty<string>());

    [TestMethod]
    public void MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.Execute(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }

    [TestMethod]
    public void Sorting_NullATest() => Solution.ExecuteWithSorting(null).Should().BeNull();

    [TestMethod]
    public void Sorting_EmptyTest() => Solution.ExecuteWithSorting(System.Array.Empty<string>()).Should().BeEquivalentTo(System.Array.Empty<string>());

    [TestMethod]
    public void Sorting_MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.ExecuteWithSorting(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }

    [TestMethod]
    public void SortingWithMap_NullATest() => Solution.ExecuteMapWithSorting(null).Should().BeNull();

    [TestMethod]
    public void SortingWithMap_EmptyTest() => Solution.ExecuteMapWithSorting(System.Array.Empty<string>()).Should().BeEquivalentTo(System.Array.Empty<string>());

    [TestMethod]
    public void SortingWithMap_MultupleValuesTests()
    {
      string[] input = new string[] { "cat", "bat", "tac", };
      Solution.ExecuteMapWithSorting(input).Should().BeEquivalentTo(new string[] { "cat", "tac", "bat" });
    }
  }
}
