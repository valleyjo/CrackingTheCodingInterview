namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MinStack = CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Problem_3_2_MinStack;

  [TestClass]
  public class Problem_3_2_MinStackTests
  {
    [TestMethod]
    public void PushTest()
    {
      var stack = new MinStack();
      stack.Push(4);
      stack.Pop().Should().Be(4);
    }

    [TestMethod]
    public void PopExceptionTest()
    {
      var stack = new MinStack();
      Action act = () => stack.Pop();
      act.Should().Throw<InvalidOperationException>();
    }

    [TestMethod]
    public void PopTest()
    {
      var stack = new MinStack();
      stack.Push(4);
      stack.Pop().Should().Be(4);
    }

    [TestMethod]
    public void IsEmptyTest()
    {
      var stack = new MinStack();
      stack.IsEmpty().Should().BeTrue();
      stack.Push(4);
      stack.IsEmpty().Should().BeFalse();
      stack.Pop().Should().Be(4);
      stack.IsEmpty().Should().BeTrue();
    }

    [TestMethod]
    public void GetMinExceptionTest()
    {
      var stack = new MinStack();
      Action act = () => stack.GetMin();
      act.Should().Throw<InvalidOperationException>();
    }

    [TestMethod]
    public void GetMinTest()
    {
      var stack = new MinStack();
      stack.Push(3);
      stack.Push(2);
      stack.Push(1);

      stack.GetMin().Should().Be(1);
      stack.Pop().Should().Be(1);

      stack.GetMin().Should().Be(2);
      stack.Pop().Should().Be(2);

      stack.GetMin().Should().Be(3);
      stack.Pop().Should().Be(3);
    }
  }
}
