namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using System;
  using System.Collections.Generic;
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
    public void ContainsNodeFalseTest() => new AGraph().ContainsNode(5).Should().BeFalse();

    [TestMethod]
    public void ContainsNodeTrueTest()
    {
      var g = new AGraph();
      g.AddNode(5);
      g[5].Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void AddNodeTest()
    {
      var g = new AGraph();
      g.AddNode(5);
      g[5].Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void AddNodeAlreadyExistsTest()
    {
      var g = new AGraph();
      g.AddNode(5);
      g[5].Should().BeEquivalentTo(new List<int>());
      g.AddNode(5);
      g[5].Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void RemoveNodeTest()
    {
      var g = new AGraph();
      g.AddNode(5);
      g[5].Should().BeEquivalentTo(new List<int>());
      g.RemoveNode(5);
      Func<List<int>> act = () => g[5];
      act.Should().Throw<KeyNotFoundException>();
    }

    [TestMethod]
    public void AddEdgeBidirectionalTest()
    {
      var g = new AGraph();
      g.AddEdge(-15, 3);
      g[-15].Should().BeEquivalentTo(new List<int>() { 3 });
      g[3].Should().BeEquivalentTo(new List<int>() { -15 });
    }

    [TestMethod]
    public void AddEdgeDirectionalTest()
    {
      var g = new AGraph(GraphType.Directional);
      g.AddEdge(-15, 3);
      g[-15].Should().BeEquivalentTo(new List<int>() { 3 });
      Func<List<int>> func = () => g[3];
      func.Should().Throw<KeyNotFoundException>();
    }

    [TestMethod]
    public void RemoveEdgeBidirectionalTest()
    {
      var g = new AGraph();
      g.AddEdge(-15, 3);
      g.RemoveEdge(-15, 3);
      g[-15].Should().BeEquivalentTo(new List<int>());
      g[3].Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void RemoveEdgeDirectionalTest()
    {
      var g = new AGraph(GraphType.Directional);
      g.AddEdge(-15, 3);
      g.RemoveEdge(-15, 3);
      g[-15].Should().BeEquivalentTo(new List<int>());
    }

    [TestMethod]
    public void IndexAccessorMissingTest()
    {
      var g = new AGraph();
      Func<List<int>> act = () => g[15];
      act.Should().Throw<KeyNotFoundException>();
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
