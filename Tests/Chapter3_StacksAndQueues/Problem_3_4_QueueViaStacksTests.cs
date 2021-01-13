namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MyQueue = CrackingTheCodingInterview.Tests.Chapter3_StacksAndQueues.Problem_3_4_QueueViaStacks;

  [TestClass]
  public class Problem_3_4_QueueViaStacksTests
  {
    [TestMethod]
    public void EnqueueTest()
    {
      var queue = new MyQueue();
      queue.Enqueue(5);
    }

    [TestMethod]
    public void DequeueExceptionTest()
    {
      var queue = new MyQueue();
      Action act = () => queue.Dequeue();
      act.Should().Throw<InvalidOperationException>();
    }

    [TestMethod]
    public void DequeueTest()
    {
      var queue = new MyQueue();
      queue.Enqueue(5);
      queue.Enqueue(15);
      queue.Dequeue().Should().Be(5);
      queue.Dequeue().Should().Be(15);
    }

    [TestMethod]
    public void ManyOperationsTest()
    {
      var queue = new MyQueue();
      queue.Enqueue(5);
      queue.Enqueue(10);
      queue.Enqueue(15);
      queue.Enqueue(20);
      queue.Dequeue().Should().Be(5);
      queue.Enqueue(25);
      queue.Enqueue(30);
      queue.Enqueue(35);
      queue.Dequeue().Should().Be(10);
      queue.Dequeue().Should().Be(15);
      queue.Dequeue().Should().Be(20);
      queue.Dequeue().Should().Be(25);
      queue.Dequeue().Should().Be(30);
      queue.Dequeue().Should().Be(35);
    }
  }
}
