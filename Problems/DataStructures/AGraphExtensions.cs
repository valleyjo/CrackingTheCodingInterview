namespace CrackingTheCodingInterview.Problems.DataStructures.Extensions
{
  using System;
  using System.Collections.Generic;

  // TODO: Move to extensions folder if more than one extension class is added
  public static class AGraphExtensions
  {
    public static List<int> ShortestPath(this AGraph graph, int source, int dest)
    {
      var results = new List<int>();
      if (!graph.ContainsNode(source) || !graph.ContainsNode(dest))
      {
        return results;
      }

      var queue = new Queue<int>();
      var visited = new HashSet<int>();
      var reachedKeyViaValue = new Dictionary<int, int>();
      queue.Enqueue(source);
      bool found = false;
      while (queue.Count > 0)
      {
        int currentNode = queue.Dequeue();
        if (currentNode == dest)
        {
          found = true;
          break;
        }

        if (visited.Contains(currentNode))
        {
          continue;
        }

        visited.Add(currentNode);
        foreach (int connectedNode in graph[currentNode])
        {
          // record the first time we visit the node
          if (!reachedKeyViaValue.ContainsKey(connectedNode))
          {
            reachedKeyViaValue[connectedNode] = currentNode;
          }

          queue.Enqueue(connectedNode);
        }
      }

      if (found)
      {
        // include start and end in the path
        int cur = dest;
        while (cur != source)
        {
          results.Add(cur);
          cur = reachedKeyViaValue[cur];
        }

        results.Add(cur);
      }

      return results;
    }

    public static bool BiDirectionalSearch(this AGraph graph, int source, int dest)
    {
      if (!graph.ContainsNode(source) || !graph.ContainsNode(dest))
      {
        return false;
      }

      var startQueue = new Queue<int>();
      var startVisited = new HashSet<int>();
      startQueue.Enqueue(source);

      var endQueue = new Queue<int>();
      var endVisited = new HashSet<int>();
      endQueue.Enqueue(dest);

      while (startQueue.Count > 0 || endQueue.Count > 0)
      {
        if (startQueue.Count > 0)
        {
          if (TraverseOne(graph, startQueue, startVisited, endVisited))
          {
            return true;
          }
        }

        if (endQueue.Count > 0)
        {
          if (TraverseOne(graph, endQueue, endVisited, startVisited))
          {
            return true;
          }
        }
      }

      return false;
    }

    private static bool TraverseOne(AGraph graph, Queue<int> queue, HashSet<int> visited, HashSet<int> otherVisited)
    {
      int currentNode = queue.Dequeue();
      if (visited.Contains(currentNode))
      {
        return false;
      }

      if (otherVisited.Contains(currentNode))
      {
        return true;
      }

      visited.Add(currentNode);
      foreach (int connectedNode in graph[currentNode])
      {
        queue.Enqueue(connectedNode);
      }

      return false;
    }
  }
}
