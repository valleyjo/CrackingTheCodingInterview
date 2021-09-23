namespace CrackingTheCodingInterview.Problems.Chapter4_TreesAndGraphs
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_07_BuildOrder
  {
    public static List<byte> Execute(List<int> projects, List<Dependency> dependencies)
    {
      if (projects == null || projects.Count == 0 || dependencies == null || dependencies.Count == 0)
      {
        throw new ArgumentException("projects and dependencies cannot be null or empty");
      }

      var result = new List<byte>(projects.Count);
      BuildGraphs(projects, dependencies, out AGraph graph, out AGraph reverseGraph);
      GenerateOrder(result, graph, reverseGraph);

      return result;
    }

    private static void GenerateOrder(List<byte> result, AGraph graph, AGraph reverseGraph)
    {
      while (!graph.Empty)
      {
        var nodesToRemove = new List<byte>();
        foreach (int node in graph)
        {
          // nodes with no outgoing connections should be built next
          if (graph[node].Count == 0)
          {
            nodesToRemove.Add((byte)node);
          }
        }

        if (nodesToRemove.Count == 0)
        {
          throw new ArgumentException("Circular dependency detected");
        }

        foreach (byte node in nodesToRemove)
        {
          // remove the edges for nodes that have been built
          if (reverseGraph.ContainsNode(node))
          {
            foreach (int outgoingConnection in reverseGraph[node])
            {
              graph.RemoveEdge(outgoingConnection, node);
            }
          }

          reverseGraph.RemoveNode(node);
          graph.RemoveNode(node);
        }

        result.AddRange(nodesToRemove);
      }
    }

    // use two graphs to support O910 lookup and removal of a node
    private static void BuildGraphs(List<int> projects, List<Dependency> dependencies, out AGraph graph, out AGraph reverseGraph)
    {
      graph = new AGraph(GraphType.Directional);
      reverseGraph = new AGraph(GraphType.Directional);
      foreach (Dependency item in dependencies)
      {
        graph.AddEdge(item.Source, item.Target);
        reverseGraph.AddEdge(item.Target, item.Source);
      }

      // Add any projects without references to the graph, these can be built right away
      foreach (int project in projects)
      {
        if (!graph.ContainsNode(project))
        {
          graph.AddNode(project);
        }
      }
    }

    public struct Dependency
    {
      public byte Source;
      public byte Target;

      public Dependency(byte source, byte target)
      {
        this.Source = source;
        this.Target = target;
      }
    }
  }
}
