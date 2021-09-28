namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using StackOfStacks = CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Problem_3_3_StackOfStacks;

  [TestClass]
  public class Problem_3_3_StackOfStacksTests
  {
    [TestMethod]
    public void InvalidCtorTest()
    {
      Action act = () => new StackOfStacks(-1);
      act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [TestMethod]
    public void PushTest()
    {
      var stack = new StackOfStacks(1);
      stack.Push(15);
      stack.Push(20);
      stack.Peak().Should().Be(20);
    }

    [TestMethod]
    public void PopTest()
    {
      var stack = new StackOfStacks(1);
      stack.Push(15);
      stack.Push(20);
      stack.Pop().Should().Be(20);
      stack.Pop().Should().Be(15);
    }

    [TestMethod]
    public void PopEmptyTest()
    {
      var stack = new StackOfStacks(1);
      stack.Push(15);
      stack.Push(20);
      stack.Pop().Should().Be(20);
      stack.Pop().Should().Be(15);
      Action act = () => stack.Pop();
      act.Should().Throw<InvalidOperationException>();
    }

    [TestMethod]
    public void PopAtTest()
    {
      var stack = new StackOfStacks(1);
      stack.Push(15);
      stack.Push(20);
      stack.PopAt(0).Should().Be(15);
      stack.Pop().Should().Be(20);
    }

    [TestMethod]
    public void PopAtExceptionTest()
    {
      var stack = new StackOfStacks(1);
      Action act = () => stack.PopAt(-1);
      act.Should().Throw<ArgumentOutOfRangeException>();
      act = () => stack.PopAt(1);
      act.Should().Throw<ArgumentOutOfRangeException>();
    }
  }
}
