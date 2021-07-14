namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class AGraphTests
  {
    [TestMethod]
    public void EmptyTest()
    {
      var g = new AGraph();
      g.Empty.Should().BeTrue();
    }

    [TestMethod]
    public void AddEdgeTest()
    {
      var g = new AGraph();
      g.AddEdge(-15, 3);
      g[-15].Should().BeEquivalentTo(new List<int>() { 3 });
      g[3].Should().BeEquivalentTo(new List<int>() { -15 });
    }

    [TestMethod]
    public void IndexAccessorMissingTest()
    {
      var g = new AGraph();
      g[15].Should().BeEquivalentTo(Enumerable.Empty<int>());
    }

    [TestMethod]
    public void ToStringEmptyTest()
    {
      var g = new AGraph();
      g.ToString().Should().BeEquivalentTo(string.Empty);
    }

    [TestMethod]
    public void ToStringTest()
    {
      string expected = "3 : [-15, 4]" + Environment.NewLine + "-15 : [3]" + Environment.NewLine + "4 : [3]";
      var g = new AGraph();
      g.AddEdge(3, -15);
      g.AddEdge(3, 4);
      g.ToString().Should().Be(expected);
    }
  }
}
