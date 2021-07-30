namespace CrackingTheCodingInterview.Problems.DataStructures
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Text;

  public enum GraphType
  {
    Bidirectional = 0,
    Directional = 1,
  }

  // TODO: Interface for IGraph and seperate implementation for directional and bidirectional?
  // TODO: Be consistent about exceptions / returning empty
  public class AGraph : IEnumerable<int>
  {
    private readonly Dictionary<int, List<int>> graph;
    private readonly GraphType type;

    public AGraph(GraphType type = GraphType.Bidirectional)
    {
      this.graph = new Dictionary<int, List<int>>();
      this.type = type;
    }

    public bool Empty
    {
      get { return this.graph.Count == 0; }
    }

    public List<int> this[int value] => this.graph[value];

    public void AddNode(int node)
    {
      if (!this.ContainsNode(node))
      {
        this.graph.Add(node, new List<int>());
      }
    }

    public bool ContainsNode(int node) => this.graph.ContainsKey(node);

    public void AddEdge(int source, int dest)
    {
      this.AddOrInitialize(source, dest);
      if (this.type == GraphType.Bidirectional)
      {
        this.AddOrInitialize(dest, source);
      }
    }

    public void RemoveNode(int node) => this.graph.Remove(node);

    public void RemoveEdge(int source, int dest)
    {
      this.graph[source].Remove(dest);
      if (this.type == GraphType.Bidirectional)
      {
        this.graph[dest].Remove(source);
      }
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
        sb.Append(']');
      }

      return sb.ToString();
    }

    public IEnumerator<int> GetEnumerator()
    {
      foreach (int key in this.graph.Keys)
      {
        yield return key;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

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
