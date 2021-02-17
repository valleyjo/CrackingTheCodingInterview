namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MultiStack = CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Problem_3_1_ThreeInOne;

  [TestClass]
  public class Problem_3_1_ThreeInOneTests
  {
    [TestMethod]
    public void ExceptionTest()
    {
      Action act = () => new MultiStack((uint.MaxValue / 3) + 1);
      act.Should().Throw<ArgumentException>();

      var validStack = new MultiStack(3);

      act = () => validStack.Push(4, 0);
      act.Should().Throw<ArgumentException>();

      act = () => validStack.Pop(4);
      act.Should().Throw<ArgumentException>();

      act = () => validStack.Peak(4);
      act.Should().Throw<ArgumentException>();

      act = () => validStack.IsEmpty(4);
      act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void PushTest()
    {
      var stack = new MultiStack(5);
      stack.Push(0, -1);
      stack.Pop(0).Should().Be(-1);
    }

    [TestMethod]
    public void IsEmptyTest()
    {
      var stack = new MultiStack(5);
      stack.IsEmpty().Should().BeTrue();
      stack.Push(0, -1);
      stack.IsEmpty().Should().BeFalse();
    }

    [TestMethod]
    public void IsEmptyStackTest()
    {
      var stack = new MultiStack(5);
      stack.IsEmpty(0).Should().BeTrue();
      stack.Push(0, -5);
      stack.IsEmpty(0).Should().BeFalse();
    }

    [TestMethod]
    public void PeakTest()
    {
      var stack = new MultiStack(5);
      stack.Push(2, -10);
      stack.Peak(2).Should().Be(-10);
      stack.IsEmpty(2).Should().BeFalse();
    }

    [TestMethod]
    public void OutOfMemoryTest()
    {
      Action act = () =>
      {
        var stack = new MultiStack(5);
        for (int i = 0; i <= 5; i++)
        {
          stack.Push(2, i);
        }
      };

      act.Should().Throw<OutOfMemoryException>();
    }

    [TestMethod]
    public void IsFullTest()
    {
      var stack = new MultiStack(5);
      stack.IsFull(1).Should().BeFalse();
      for (int i = 0; i < 5; i++)
      {
        stack.Push(1, i);
      }

      stack.IsFull(1).Should().BeTrue();
    }
  }
}
