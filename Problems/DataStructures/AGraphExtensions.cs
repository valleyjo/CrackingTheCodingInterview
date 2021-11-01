namespace CrackingTheCodingInterview.Problems.DataStructures.Extensions
{
  using System.Collections.Generic;

  // TODO: Move to extensions folder if more than one extension class is added
  public static class AGraphExtensions
  {
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
