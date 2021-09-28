namespace CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests
{
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_01_RouteBetweenNodes
  {
    public static bool Execute(AGraph graph, int source, int dest)
    {
      if (graph == null || graph.Empty)
      {
        return false;
      }

      var queue = new Queue<int>();
      queue.Enqueue(source);
      var visited = new HashSet<int>() { source };

      while (queue.Count > 0)
      {
        int current = queue.Dequeue();
        if (current == dest)
        {
          return true;
        }

        foreach (int node in graph[current])
        {
          if (!visited.Contains(node))
          {
            visited.Add(node);
            queue.Enqueue(node);
          }
        }
      }

      return false;
    }
  }
}
