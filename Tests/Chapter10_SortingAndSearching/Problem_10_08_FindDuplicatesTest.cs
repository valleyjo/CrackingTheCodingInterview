namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_08_FindDuplicates;

  [TestClass]
  public class Problem_10_08_FindDuplicatesTest
  {
    [TestInitialize]
    public void Initialize() => Solution.Logger = (msg) => Logger.LogMessage(msg);

    [TestMethod]
    public void NullTest() => Solution.Execute(null).Should().BeEquivalentTo(new List<int>());

    [TestMethod]
    public void EmptyTest() => Solution.Execute(System.Array.Empty<int>()).Should().BeEquivalentTo(new List<int>());

    [TestMethod]
    public void NoDuplicatesTest()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, };
      Solution.Execute(input).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void DuplicatesTest()
    {
      int[] input = new int[] { 1, 2, 5, 1, 5, 6, };
      Solution.Execute(input).Should().BeEquivalentTo(new List<int>() { 1, 5 });
    }

    [TestMethod]
    public void UseMultipleBucketsTest()
    {
      // fully use 6 ulong's and 10 bits from the 7th ulong
      const int size = (5 * (1 << 6)) + 10;

      // make a big array with a loop rather than inline initializing it
      int[] input = new int[size];
      for (int i = 1; i < size; i++)
      {
        // create a duplicate every 50 items
        input[i] = i % 50 == 0 ? i - 1 : i;
      }

      Solution.Execute(input).Should().BeEquivalentTo(new List<int>() { 49, 99, 149, 199, 249, 299, });
    }
  }
}
