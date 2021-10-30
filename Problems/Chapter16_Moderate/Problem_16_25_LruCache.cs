namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;
  using System.Threading;

  public class Problem_16_25_LruCache
  {
    private readonly int size;
    private readonly Dictionary<int, DoublyLinkedListNode> map;
    private DoublyLinkedListNode head;
    private DoublyLinkedListNode tail;

    public Problem_16_25_LruCache(int size)
    {
      if (size <= 0)
      {
        throw new ArgumentOutOfRangeException();
      }

      this.size = size;
      this.map = new Dictionary<int, DoublyLinkedListNode>();
    }

    public void Add(int key, int value)
    {
      var newHeadNode = new DoublyLinkedListNode()
      {
        Data = value,
        Next = this.head,
        Key = key,
      };

      if (this.head == null)
      {
        this.head = newHeadNode;
        this.tail = newHeadNode;
      }
      else
      {
        this.head.Prev = newHeadNode;
        this.head = newHeadNode;
      }

      if (this.map.Count == this.size)
      {
        this.map.Remove(this.tail.Key);
        this.tail = this.tail.Prev;
        this.tail.Next = null;
      }

      // Overwrite the key data if it already exists
      this.map[key] = newHeadNode;
    }

    public int Get(int key)
    {
      if (this.map.TryGetValue(key, out DoublyLinkedListNode node))
      {
        node.Disconnect();
        this.head.Prev = node;
        this.head = node;
        return node.Data;
      }

      throw new KeyNotFoundException();
    }

    // TODO: refactor into testable public class for DoublyLinkedList
    private class DoublyLinkedListNode
    {
      public int Data { get; set; }

      public int Key { get; set; }

      public DoublyLinkedListNode Prev { get; set; }

      public DoublyLinkedListNode Next { get; set; }

      public void Disconnect()
      {
        if (this.Prev != null)
        {
          this.Prev.Next = this.Next;
        }

        if (this.Next != null)
        {
          this.Next.Prev = this.Prev;
        }

        this.Next = null;
        this.Prev = null;
      }
    }
  }
}
