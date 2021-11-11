namespace CrackingTheCodingInterview.Problems.Special
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_FB_01_MinExecutionTime
  {
    /*
requirements:
return cost to execute the chain of operations
if no build order, return -1

assumptions:
execution order may or may not exist
should handle cycles
have an adjacency list graph to work with
distinct item IDs

method signiture:
public static int DependencyOrder(Graph graph, int start, Dictionary<int, int> cost)

Test cases:
cycle
no cycle
single element order
forest for input
happy path

BFS -> O(V+E) time O(V+E) space
DFS -> same
Pick DFS -> We only care about the starting node, BFS we will have to look at all nodes

steps:
1) filter graph for only connected nodes O(V + E)
2) topological sort to get the cost, exclude non-connected nodes
 */
    // TODO: use Object for dependency and make graph generic
    public static int MinDependencyOrder_DFS(AGraph graph, int start, Dictionary<int, int> cost)
    {
      if (!graph.ContainsNode(start))
      {
        return -1;
      }

      // Use an object for the key with status built in?
      var finishedMap = new Dictionary<int, bool>();
      return MinDependencyOrder_DFS(finishedMap, graph, start, cost);
    }

    public static List<int> MinDependencyOrder(AGraph graph, int start)
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
        foreach (int nextNode in graph[node])
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

    private static int MinDependencyOrder_DFS(
      Dictionary<int, bool> finishedMap,
      AGraph graph,
      int start,
      Dictionary<int, int> cost)
    {
      if (finishedMap.ContainsKey(start) && !finishedMap[start])
      {
        return -1;
      }

      int total = cost[start];
      finishedMap[start] = false;
      foreach (int connectedNode in graph[start])
      {
        int subTotal = MinDependencyOrder_DFS(finishedMap, graph, connectedNode, cost);
        if (subTotal == -1)
        {
          return -1;
        }

        total += subTotal;
      }

      return total;
    }
  }
}
