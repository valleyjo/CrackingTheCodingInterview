namespace CrackingTheCodingInterview.Tests.DataStructures
{
  using System;
  using System.Collections.Generic;
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class AHeapTests
  {
    [TestMethod]
    public void InsertOneTest()
    {
      var heap = new AHeap();
      heap.Insert(5);
      heap.Peek().Should().Be(5);
      heap.Count.Should().Be(1);
    }

    [TestMethod]
    public void RemoveOneTest()
    {
      var heap = new AHeap();
      heap.Insert(5);
      heap.Remove();
      heap.Count.Should().Be(0);
    }

    [TestMethod]
    public void Min_InsertTest()
    {
      var heap = new AHeap();
      heap.Insert(5);
      heap.Peek().Should().Be(5);
      heap.Count.Should().Be(1);

      heap.Insert(-1);
      heap.Peek().Should().Be(-1);
      heap.Count.Should().Be(2);

      heap.Insert(6);
      heap.Peek().Should().Be(-1);
      heap.Count.Should().Be(3);
    }

    [TestMethod]
    public void Min_InsertDescendingTest()
    {
      var heap = new AHeap();
      InsertAndVerify(heap, 4, 4, 1);
      InsertAndVerify(heap, 3, 3, 2);
      InsertAndVerify(heap, 2, 2, 3);
      InsertAndVerify(heap, 1, 1, 4);
      InsertAndVerify(heap, 0, 0, 5);
    }

    [TestMethod]
    public void Min_HeapSortTest()
    {
      int[] values = new int[] { 8, 9, 5, 2, 4, 1, 6, 3, 0, 7, };
      var heap = new AHeap();
      foreach (int v in values)
      {
        heap.Insert(v);
      }

      for (
        int expectedValue = 0, expectedCountBeforeRemove = values.Length;
        expectedValue < values.Length;
        expectedValue++, expectedCountBeforeRemove--)
      {
        RemoveAndVerify(heap, expectedValue, expectedCountBeforeRemove);
      }

      heap.Count.Should().Be(0);
    }

    [TestMethod]
    public void Max_InsertTest()
    {
      var heap = new AHeap(false);
      heap.Insert(5);
      heap.Peek().Should().Be(5);
      heap.Count.Should().Be(1);

      heap.Insert(-1);
      heap.Peek().Should().Be(5);
      heap.Count.Should().Be(2);

      heap.Insert(6);
      heap.Peek().Should().Be(6);
      heap.Count.Should().Be(3);
    }

    [TestMethod]
    public void Max_InsertAscendingTest()
    {
      var heap = new AHeap(false);
      InsertAndVerify(heap, 0, 0, 1);
      InsertAndVerify(heap, 1, 1, 2);
      InsertAndVerify(heap, 2, 2, 3);
      InsertAndVerify(heap, 3, 3, 4);
      InsertAndVerify(heap, 4, 4, 5);
    }

    [TestMethod]
    public void Max_HeapSortTest()
    {
      int[] values = new int[] { 8, 9, 5, 2, 4, 1, 6, 3, 0, 7, };
      var heap = new AHeap(false);
      foreach (int v in values)
      {
        heap.Insert(v);
      }

      for (
        int expectedValue = 9, expectedCountBeforeRemove = values.Length;
        expectedValue >= 0;
        expectedValue--, expectedCountBeforeRemove--)
      {
        RemoveAndVerify(heap, expectedValue, expectedCountBeforeRemove);
      }

      heap.Count.Should().Be(0);
    }

    private static void InsertAndVerify(AHeap heap, int value, int expectedPeekValueAfterInsert, int expectedCountAfterInsert)
    {
      heap.Count.Should().Be(expectedCountAfterInsert - 1);
      heap.Insert(value);
      heap.Peek().Should().Be(expectedPeekValueAfterInsert);
      heap.Count.Should().Be(expectedCountAfterInsert);
    }

    private static void RemoveAndVerify(AHeap heap, int expectedPeekValue, int expectedCountBeforeRemove)
    {
      heap.Peek().Should().Be(expectedPeekValue);
      heap.Count.Should().Be(expectedCountBeforeRemove);
      heap.Remove();
      heap.Count.Should().Be(expectedCountBeforeRemove - 1);
    }
  }
}
