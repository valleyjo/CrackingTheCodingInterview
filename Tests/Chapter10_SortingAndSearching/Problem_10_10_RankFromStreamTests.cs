namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_10_RankFromStream;

  [TestClass]
  public class Problem_10_10_RankFromStreamTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      var sln = new Solution();
      sln.GetRank(400).Should().Be(-1);
    }

    [TestMethod]
    public void NotFoundTest()
    {
      var sln = new Solution();
      sln.Track(10);
      sln.Track(5);
      sln.Track(15);
      sln.Track(2);
      sln.GetRank(7).Should().Be(-1);
    }

    [TestMethod]
    public void RootTest()
    {
      var sln = new Solution();
      sln.Track(10);
      sln.Track(5);
      sln.Track(15);
      sln.Track(2);
      sln.GetRank(10).Should().Be(2);
    }

    [TestMethod]
    public void SmallestTest()
    {
      var sln = new Solution();
      sln.Track(10);
      sln.Track(5);
      sln.Track(15);
      sln.Track(2);
      sln.GetRank(2).Should().Be(0);
    }

    [TestMethod]
    public void BiggestTest()
    {
      var sln = new Solution();
      sln.Track(10);
      sln.Track(5);
      sln.Track(15);
      sln.Track(2);
      sln.GetRank(15).Should().Be(3);
    }

    [TestMethod]
    public void DuplicatesTest()
    {
      var sln = new Solution();
      sln.Track(10);
      sln.Track(5);
      sln.Track(5);
      sln.Track(15);
      sln.Track(2);
      sln.GetRank(5).Should().Be(2);
    }

    [TestMethod]
    public void WorstCasePerformanceAscendingTest()
    {
      var sln = new Solution();
      sln.Track(1);
      sln.Track(2);
      sln.Track(3);
      sln.Track(4);
      sln.Track(5);
      sln.GetRank(1).Should().Be(0);
      sln.GetRank(5).Should().Be(4);
    }

    [TestMethod]
    public void WorstCasePerformanceDescendingTest()
    {
      var sln = new Solution();
      sln.Track(5);
      sln.Track(4);
      sln.Track(3);
      sln.Track(2);
      sln.Track(1);
      sln.GetRank(1).Should().Be(0);
      sln.GetRank(5).Should().Be(4);
    }
  }
}
