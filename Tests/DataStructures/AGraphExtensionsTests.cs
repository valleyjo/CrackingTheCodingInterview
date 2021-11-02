namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using CrackingTheCodingInterview.Problems.DataStructures.Extensions;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class AGraphExtensionsTests
  {
    [TestMethod]
    public void ShortestPath_DestNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 10);
      g.ShortestPath(5, 6).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void ShortestPath_SourceNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 10);
      g.ShortestPath(6, 5).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void ShortestPath_SourceDestEqualTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.ShortestPath(5, 5).Should().BeEquivalentTo(new List<int>() { 5 });
    }

    [TestMethod]
    public void ShortestPath_PathExistsTest()
    {
      AGraph g = InitializeGraph();
      g.ShortestPath(6, -1).Should().BeEquivalentTo(new List<int>() { -1, 1, 2, 6, });
    }

    [TestMethod]
    public void ShortestPath_PathDoesNotExistsTest()
    {
      AGraph g = InitializeGraph(connected: false);
      g.ShortestPath(6, -1).Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void BiDirectionalSearch_SourceDoesNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.BiDirectionalSearch(10, 6).Should().BeFalse();
    }

    [TestMethod]
    public void BiDirectionalSearch_DestDoesNotExistTest()
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.BiDirectionalSearch(5, 10).Should().BeFalse();
    }

    [TestMethod]
    public void BiDirectionalSearch_BothExistNoPathTest()
    {
      AGraph g = InitializeGraph(connected: false);
      g.BiDirectionalSearch(-1, 10).Should().BeFalse();
    }

    [TestMethod]
    public void BiDirectionalSearch_BothExistPathValidTest()
    {
      AGraph g = InitializeGraph();
      g.BiDirectionalSearch(-1, 10).Should().BeTrue();
    }

    private static AGraph InitializeGraph(bool connected = true)
    {
      var g = new AGraph();
      g.AddEdge(5, 6);
      g.AddEdge(6, 7);
      g.AddEdge(6, 8);
      g.AddEdge(8, 10);
      g.AddEdge(10, 7);

      if (connected)
      {
        g.AddEdge(6, 2);
        g.AddEdge(3, 8);
      }

      g.AddEdge(1, 2);
      g.AddEdge(1, 3);
      g.AddEdge(2, 3);
      g.AddEdge(3, 4);
      g.AddEdge(-1, 1);

      return g;
    }
  }
}
