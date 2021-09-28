namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Problem_3_5_SortStack;

  [TestClass]
  public class Problem_3_5_SortStackTests
  {
    [TestMethod]
    public void BasicSortTest()
    {
      var stack = new Stack<int>();
      stack.Push(1);
      stack.Push(5);
      stack.Push(-15);
      stack.Push(3);
      stack.Push(15);

      Problem.Execute(stack);
      stack.Pop().Should().Be(-15);
      stack.Pop().Should().Be(1);
      stack.Pop().Should().Be(3);
      stack.Pop().Should().Be(5);
      stack.Pop().Should().Be(15);
    }

    [TestMethod]
    public void OneElementTest()
    {
      var expected = new Stack<int>();
      expected.Push(1);
      var stack = new Stack<int>();
      stack.Push(1);
      Problem.Execute(stack);
      stack.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void NullTest()
    {
      Action act = () => Problem.Execute(null);
      act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void EmptyTest()
    {
      var empty = new Stack<int>();
      Problem.Execute(empty);
      empty.Should().BeEquivalentTo(new Stack<int>());
    }
  }
}
