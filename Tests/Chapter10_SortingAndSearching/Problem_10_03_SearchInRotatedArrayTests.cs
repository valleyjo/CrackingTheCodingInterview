namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_03_SearchInRotatedArray;

  [TestClass]
  public class Problem_10_03_SearchInRotatedArrayTests
  {
    [TestMethod]
    public void NullTest() => Solution.Execute(null, 0).Should().Be(-1);

    [TestMethod]
    public void EmptyTest() => Solution.Execute(System.Array.Empty<int>(), 0).Should().Be(-1);

    [TestMethod]
    public void FoundAtFirstIndexTest()
    {
      int[] input = new int[] { 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, };
      Solution.Execute(input, 9).Should().Be(0);
    }

    [TestMethod]
    public void FoundAtLastIndexTest()
    {
      int[] input = new int[] { 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, };
      Solution.Execute(input, 3).Should().Be(9);
    }

    [TestMethod]
    public void NotFoundTest()
    {
      int[] input = new int[] { 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, };
      Solution.Execute(input, 11).Should().Be(-1);
    }

    [TestMethod]
    public void NotFoundDuplicatesTest()
    {
      int[] input = new int[] { 9, 10, 1, 2, 3, 4, 5, 5, 5, 5, };
      Solution.Execute(input, 6).Should().Be(-1);
    }

    [TestMethod]
    public void FoundDuplicatesTest()
    {
      int[] input = new int[] { 9, 10, 1, 2, 3, 4, 5, 6, 6, 8, };
      Solution.Execute(input, 6).Should().Be(7);
    }
  }
}
