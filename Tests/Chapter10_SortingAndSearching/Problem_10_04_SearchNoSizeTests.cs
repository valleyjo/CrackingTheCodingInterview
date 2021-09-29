namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_04_SortedSearchNoSize;

  [TestClass]
  public class Problem_10_04_SearchNoSizeTests
  {
    [TestInitialize]
    public void Initialize() => Solution.Logger = (msg) => Logger.LogMessage(msg);

    [TestMethod]
    public void NullTest() => Solution.Execute(15, default).Should().Be(-1);

    [TestMethod]
    public void EmptyTest() => Solution.Execute(15, new Listy(new int[0])).Should().Be(-1);

    [TestMethod]
    public void FoundAtFirstIndexTest()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, };
      Solution.Execute(1, new Listy(input)).Should().Be(0);
    }

    [TestMethod]
    public void FoundAtLastIndexTest()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      Solution.Execute(10, new Listy(input)).Should().Be(9);
    }

    [TestMethod]
    public void FarOffTheListEndTest()
    {
      int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
      Solution.Execute(10, new Listy(input)).Should().Be(9);
    }
  }
}
