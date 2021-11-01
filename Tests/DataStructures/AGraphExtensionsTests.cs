namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using CrackingTheCodingInterview.Problems.DataStructures.Extensions;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class AGraphExtensionsTests
  {
    [TestMethod]
    public void SourceDoesNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.BiDirectionalSearch(10, 6).Should().BeFalse();
    }

    [TestMethod]
    public void DestDoesNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.BiDirectionalSearch(5, 10).Should().BeFalse();
    }

    [TestMethod]
    public void BothExistNoPathTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.AddEdge(6, 7);
      g.AddEdge(6, 8);
      g.AddEdge(8, 10);
      g.AddEdge(10, 7);

      g.AddEdge(1, 2);
      g.AddEdge(1, 3);
      g.AddEdge(2, 3);
      g.AddEdge(3, 4);
      g.AddEdge(-1, 1);

      g.BiDirectionalSearch(-1, 10).Should().BeFalse();
    }

    [TestMethod]
    public void BothExistPathValidTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.AddEdge(6, 7);
      g.AddEdge(6, 8);
      g.AddEdge(8, 10);
      g.AddEdge(10, 7);

      g.AddEdge(6, 2);
      g.AddEdge(3, 8);

      g.AddEdge(1, 2);
      g.AddEdge(1, 3);
      g.AddEdge(2, 3);
      g.AddEdge(3, 4);
      g.AddEdge(-1, 1);

      g.BiDirectionalSearch(-1, 10).Should().BeTrue();
    }
  }
}
