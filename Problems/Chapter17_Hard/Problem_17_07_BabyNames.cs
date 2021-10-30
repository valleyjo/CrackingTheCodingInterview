namespace CrackingTheCodingInterview.Problems.Chapter17_Hard
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public static class Problem_17_07_BabyNames
  {
    /*
    dictionary for counts -> or object?
    dictionary for name pairs
    build graph:
    if name1 exists in the mapping, add name2 to that list
    if name2 exists in the mapping, add name1 to that list
    Do a BFS (or DFS) on each node, mark it as visited, add the counts to the total.
     */
    public static List<NameFrequency> Execute(List<NameFrequency> names, List<string> namePairs)
    {
      if (names == null || names.Count == 0 || namePairs == null || namePairs.Count == 0)
      {
        return new List<NameFrequency>();
      }

      Dictionary<string, int> nameCounts = GetNameCounts(names);
      Dictionary<string, List<string>> nameMap = GetNameMap(namePairs);

      return SumNameFrequencies(nameCounts, nameMap);
    }

    private static List<NameFrequency> SumNameFrequencies(Dictionary<string, int> nameCounts, Dictionary<string, List<string>> nameMap)
    {
      var results = new List<NameFrequency>();
      var visited = new HashSet<string>();

      foreach (KeyValuePair<string, List<string>> kvp in nameMap)
      {
        int sum = SumCountsForName(kvp.Key, nameCounts, nameMap, visited);
        if (sum > 0)
        {
          results.Add(new NameFrequency(kvp.Key, sum));
        }
      }

      return results;
    }

    private static int SumCountsForName(
      string name,
      Dictionary<string, int> nameCounts,
      Dictionary<string, List<string>> nameMap,
      HashSet<string> visited)
    {
      int total = 0;

      var queue = new Queue<string>();
      queue.Enqueue(name);

      while (queue.Count > 0)
      {
        string nextName = queue.Dequeue();
        if (visited.Contains(nextName) || !nameCounts.ContainsKey(nextName))
        {
          continue;
        }

        total += nameCounts[nextName];
        visited.Add(nextName);
        foreach (string relatedName in nameMap[nextName])
        {
          queue.Enqueue(relatedName);
        }
      }

      return total;
    }

    private static Dictionary<string, List<string>> GetNameMap(List<string> namePairs)
    {
      var result = new Dictionary<string, List<string>>();
      foreach (string namePair in namePairs)
      {
        if (!string.IsNullOrEmpty(namePair))
        {
          string[] parts = namePair.Split(":");
          if (parts.Length == 2)
          {
            if (!result.ContainsKey(parts[0]))
            {
              result[parts[0]] = new List<string>();
            }

            if (!result.ContainsKey(parts[1]))
            {
              result[parts[1]] = new List<string>();
            }

            result[parts[0]].Add(parts[1]);
            result[parts[1]].Add(parts[0]);
          }

          // TODO: log failure
        }

        // TODO: log failure
      }

      return result;
    }

    private static Dictionary<string, int> GetNameCounts(List<NameFrequency> names)
    {
      var result = new Dictionary<string, int>();
      foreach (NameFrequency name in names)
      {
        result.Add(name.Name, name.Count);
      }

      return result;
    }

    public struct NameFrequency
    {
      public NameFrequency(string name, int count)
      {
        this.Name = name;
        this.Count = count;
      }

      public int Count { get; set; }

      public string Name { get; set; }
    }
  }
}
