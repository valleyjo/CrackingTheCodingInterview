namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  public class AGraph
  {
    private readonly Dictionary<int, List<int>> graph = new ();

    public bool Empty
    {
      get { return this.graph.Count == 0; }
    }

    public IEnumerable<int> this[int value]
    {
      get
      {
        if (this.graph.TryGetValue(value, out List<int> nodes))
        {
          return nodes;
        }
        else
        {
          return Enumerable.Empty<int>();
        }
      }
    }

    public void AddEdge(int source, int dest)
    {
      this.AddOrInitialize(source, dest);
      this.AddOrInitialize(dest, source);
    }

    public override string ToString()
    {
      var sb = new StringBuilder();
      foreach (KeyValuePair<int, List<int>> kvp in this.graph)
      {
        // prevent appending a trailing newline
        if (sb.Length > 0)
        {
          sb.Append(Environment.NewLine);
        }

        sb.Append(kvp.Key);
        sb.Append(" : [");
        sb.Append(string.Join(", ", kvp.Value));
        sb.Append("]");
      }

      return sb.ToString();
    }

    private void AddOrInitialize(int source, int dest)
    {
      if (this.graph.TryGetValue(source, out List<int> sourceList))
      {
        sourceList.Add(dest);
      }
      else
      {
        this.graph[source] = new List<int> { dest };
      }
    }
  }
}
