namespace CrackingTheCodingInterview.Problems.Chapter04_TreesAndGraphsTests
{
  using System.Collections;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;

  public static class Problem_4_03_ListOfDepths
  {
    public static Dictionary<int, List<ABinaryTreeNode>> BuildDepthDictionary(ABinaryTreeNode root)
    {
      var dict = new Dictionary<int, List<ABinaryTreeNode>>();
      BuildDepthDictionary(0, root, dict);
      return dict;
    }

    public static DepthMap BuildDepthMap(ABinaryTreeNode node)
    {
      var depthMap = new DepthMap();
      BuildDepthMap(0, node, depthMap);
      return depthMap;
    }

    public static DepthMap BuildDepthMapLessMemory(ABinaryTreeNode root)
    {
      var result = new DepthMap();
      if (root == null)
      {
        return result;
      }

      var currentLevelNodes = new Queue<ABinaryTreeNode>();
      var nextLevelNodes = new Queue<ABinaryTreeNode>();
      nextLevelNodes.Enqueue(root);
      int currentLevel = -1;
      while (nextLevelNodes.Count > 0)
      {
        currentLevel++;
        Swap(ref currentLevelNodes, ref nextLevelNodes);

        while (currentLevelNodes.Count > 0)
        {
          ABinaryTreeNode currentNode = currentLevelNodes.Dequeue();
          if (currentNode != null)
          {
            result.AddOrUpdate(currentLevel, currentNode);
            nextLevelNodes.Enqueue(currentNode.Left);
            nextLevelNodes.Enqueue(currentNode.Right);
          }
        }
      }

      return result;
    }

    private static void Swap(ref Queue<ABinaryTreeNode> currentLevelNodes, ref Queue<ABinaryTreeNode> nextLevelNodes)
    {
      Queue<ABinaryTreeNode> emptyQueue = currentLevelNodes;
      currentLevelNodes = nextLevelNodes;
      nextLevelNodes = emptyQueue;
    }

    private static void BuildDepthDictionary(int depth, ABinaryTreeNode root, Dictionary<int, List<ABinaryTreeNode>> dict)
    {
      if (root == null)
      {
        return;
      }

      if (dict.TryGetValue(depth, out List<ABinaryTreeNode> nodes))
      {
        nodes.Add(root);
      }
      else
      {
        dict[depth] = new List<ABinaryTreeNode>() { root };
      }

      BuildDepthDictionary(depth + 1, root.Left, dict);
      BuildDepthDictionary(depth + 1, root.Right, dict);
    }

    private static void BuildDepthMap(int depth, ABinaryTreeNode node, DepthMap map)
    {
      if (node == null)
      {
        return;
      }

      map.AddOrUpdate(depth, node);
      BuildDepthMap(depth + 1, node.Left, map);
      BuildDepthMap(depth + 1, node.Right, map);
    }

    public class DepthMap : IEnumerable<KeyValuePair<int, List<ABinaryTreeNode>>>
    {
      private readonly Dictionary<int, List<ABinaryTreeNode>> depthMap = new();

      public List<ABinaryTreeNode> this[int value]
      {
        get { return this.depthMap[value]; }
      }

      public void AddOrUpdate(int depth, ABinaryTreeNode node)
      {
        if (this.depthMap.TryGetValue(depth, out List<ABinaryTreeNode> nodeList))
        {
          nodeList.Add(node);
        }
        else
        {
          this.depthMap[depth] = new List<ABinaryTreeNode>() { node };
        }
      }

      public IEnumerator<KeyValuePair<int, List<ABinaryTreeNode>>> GetEnumerator() => this.depthMap.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
  }
}
