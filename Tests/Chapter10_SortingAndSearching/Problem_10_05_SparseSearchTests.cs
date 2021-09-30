namespace CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
  using Solution = CrackingTheCodingInterview.Problems.Chapter10_SortingAndSearching.Problem_10_05_SparseSearch;

  [TestClass]
  public class Problem_10_05_SparseSearchTests
  {
    [TestInitialize]
    public void Initialize() => Solution.Logger = (msg) => Logger.LogMessage(msg);

    [TestMethod]
    public void NullTest() => Solution.Execute(null, "Freddy").Should().Be(-1);

    [TestMethod]
    public void EmptyTest() => Solution.Execute(new List<string>(), "Freddy").Should().Be(-1);

    [TestMethod]
    public void FoundAtFirstIndexTest()
    {
      var input = new List<string>()
      {
        "cats",
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        "fluffy",
        string.Empty,
        string.Empty,
        string.Empty,
        "freddy",
        "smudgie",
      };
      Solution.Execute(input, "cats").Should().Be(0);
    }

    [TestMethod]
    public void EmptyListTest()
    {
      var input = new List<string>()
      {
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
      };
      Solution.Execute(input, "freddy").Should().Be(-1);
    }

    [TestMethod]
    public void FoundAtLastIndexTest()
    {
      var input = new List<string>()
      {
        string.Empty,
        string.Empty,
        "cats",
        string.Empty,
        string.Empty,
        string.Empty,
        "fluffy",
        string.Empty,
        string.Empty,
        string.Empty,
        "freddy",
        "smudgie",
      };
      Solution.Execute(input, "smudgie").Should().Be(11);
    }

    [TestMethod]
    public void FewIterationsTest()
    {
      var input = new List<string>()
      {
        string.Empty,
        string.Empty,
        "cats",
        string.Empty,
        string.Empty,
        string.Empty,
        "fluffy",
        string.Empty,
        string.Empty,
        string.Empty,
        "freddy",
        "smudgie",
      };
      Solution.Execute(input, "cats").Should().Be(2);
    }
  }
}
