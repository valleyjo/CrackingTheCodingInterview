namespace CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests.Problem_4_01_RouteBetweenNodes;

  [TestClass]
  public class Problem_4_01_RouteBetweenNodesTests
  {
    [TestMethod]
    public void NullGraphTest() => Solution.Execute(null, 0, 0).Should().BeFalse();

    [TestMethod]
    public void EmptyGraphTest() => Solution.Execute(new AGraph(), 0, 0).Should().BeFalse();

    [TestMethod]
    public void MissingNodeTest()
    {
      var graph = new AGraph();
      graph.AddEdge(1, 2);
      graph.AddEdge(2, 3);
      graph.AddEdge(3, 4);

      Solution.Execute(graph, 1, 10).Should().BeFalse();
    }

    [TestMethod]
    public void BasicRouteTest()
    {
      var graph = new AGraph();
      graph.AddEdge(1, 2);
      graph.AddEdge(2, 3);
      graph.AddEdge(3, 4);

      graph.AddEdge(2, 5);
      graph.AddEdge(2, 10);
      graph.AddEdge(3, -15);

      Solution.Execute(graph, 1, 4).Should().BeTrue();
      Solution.Execute(graph, 4, 1).Should().BeTrue();
    }

    [TestMethod]
    public void RouteWithCycleTest()
    {
      var graph = new AGraph();
      graph.AddEdge(1, 2);
      graph.AddEdge(2, 3);
      graph.AddEdge(2, 5);
      graph.AddEdge(2, 10);
      graph.AddEdge(3, 1); // cycle
      graph.AddEdge(3, 4);

      Solution.Execute(graph, 1, 4).Should().BeTrue();
      Solution.Execute(graph, 4, 1).Should().BeTrue();
    }

    [TestMethod]
    public void NoRouteTest()
    {
      var graph = new AGraph();
      graph.AddEdge(1, 2);
      graph.AddEdge(2, 3);
      graph.AddEdge(2, 5);
      graph.AddEdge(8, 10);
      graph.AddEdge(10, 9); // cycle
      graph.AddEdge(3, 4);

      Solution.Execute(graph, 1, 10).Should().BeFalse();
      Solution.Execute(graph, 10, 1).Should().BeFalse();
    }
  }
}
