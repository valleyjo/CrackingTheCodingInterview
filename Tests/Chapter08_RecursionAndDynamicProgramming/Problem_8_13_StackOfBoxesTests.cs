namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_13_StackOfBoxes;

  // TODO: standalone tests for Box.IsSmallerThan(Box other)
  [TestClass]
  public class Problem_8_13_StackOfBoxesTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action a = () => Solution.Execute(null);
      a.Should().Throw<ArgumentNullException>().WithMessage("*boxes*");
    }

    [TestMethod]
    public void EmptyTest() => Solution.Execute(new List<Box>()).Should().Be(0);

    [TestMethod]
    public void OneBoxTest()
    {
      var boxes = new List<Box>()
      {
        new Box(1, 1, 1),
      };

      Solution.Execute(boxes).Should().Be(1);
    }

    [TestMethod]
    public void NoStackingTest()
    {
      var boxes = new List<Box>()
      {
        new Box(2, 2, 1),
        new Box(2, 1, 2),
        new Box(5, 7, 1),
      };

      Solution.Execute(boxes).Should().Be(7);
    }

    [TestMethod]
    public void StackingTest()
    {
      var boxes = new List<Box>()
      {
        new Box(1, 1, 1),  // [X]
        new Box(2, 3, 2),  // [X]
        new Box(4, 7, 4),  // [ ]
        new Box(3, 8, 4),  // [X]
        new Box(4, 10, 6), // [X]
      };

      Solution.Execute(boxes).Should().Be(22);
    }

    [TestMethod]
    public void MemoVersionTest()
    {
      // TODO: implement memo version of problem 8.13
      false.Should().BeTrue();
    }
  }
}
