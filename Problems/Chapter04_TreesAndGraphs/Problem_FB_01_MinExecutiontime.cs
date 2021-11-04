namespace CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_FB_01_MinExecutionTime
  {
    /*
requirements:
return build order
if no build order, return empty list

assumptions:
build order may or may not exist
should handle cycles
have an adjacency list graph to work with
distinct item IDs

method signiture:
public static List<int> DependencyOrder(Graph graph, int start)

Test cases:
cycle
no cycle
single element order
forest for input
happy path

BFS -> O(V+E) time O(V+E) space
DFS -> same
Pick BFS -> easier to extend if needed

steps:
1) filter graph for only connected nodes O(V + E)
2) topological sort to get the cost, exclude non-connected nodes
 */
    public static List<int> MinDependencyOrder(this AGraph graph, int start)
    {
      var results = new List<int>();
      if (!graph.ContainsNode(start))
      {
        return results;
      }

      HashSet<int> connectedNodes = FindConnectedNodes(graph, start);

      var queue = new Queue<int>();
      SeedQueue(graph, connectedNodes, queue);

      while (queue.Count > 0)
      {
        int node = queue.Dequeue();
        results.Add(node);
        foreach (int nextNode in graph)
        {
          if (graph[nextNode].Contains(nextNode))
          {
            graph[nextNode].Remove(nextNode);
          }
        }

        SeedQueue(graph, connectedNodes, queue);
      }

      if (results.Count != connectedNodes.Count)
      {
        // cycle
        return new List<int>();
      }

      return results;
    }

    private static void SeedQueue(AGraph graph, HashSet<int> connectedNodes, Queue<int> queue)
    {
      foreach (int node in graph)
      {
        if (graph[node].Count == 0 && connectedNodes.Contains(node))
        {
          queue.Enqueue(node);
        }
      }
    }

    // assume graph contains start
    private static HashSet<int> FindConnectedNodes(AGraph graph, int start)
    {
      var visited = new HashSet<int>();
      var queue = new Queue<int>();
      queue.Enqueue(start);

      while (queue.Count > 0)
      {
        int node = queue.Dequeue();
        if (visited.Contains(node))
        {
          continue;
        }

        visited.Add(node);
        foreach (int connectedNodes in graph[node])
        {
          queue.Enqueue(connectedNodes);
        }
      }

      return visited;
    }
  }
}
