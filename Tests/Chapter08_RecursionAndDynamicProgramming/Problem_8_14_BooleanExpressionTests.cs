namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_14_BooleanExpression;

  [TestClass]
  public class Problem_8_14_BooleanExpressionTests
  {
    [TestMethod]
    public void NullTest()
    {
      Action a = () => Solution.Execute(null, false);
      a.Should().Throw<ArgumentException>().WithMessage("*input*");
    }

    [TestMethod]
    public void EmptyTest()
    {
      Action a = () => Solution.Execute(string.Empty, false);
      a.Should().Throw<ArgumentException>().WithMessage("*input*");
    }

    [TestMethod]
    public void BaseCaseOneTest()
    {
      Solution.Execute("1", false).Should().Be(0);
      Solution.Execute("1", true).Should().Be(1);
    }

    [TestMethod]
    public void BaseCaseTwoTest()
    {
      Solution.Execute("0", false).Should().Be(1);
      Solution.Execute("0", true).Should().Be(0);
    }

    [TestMethod]
    public void OneExpressionTest()
    {
      Solution.Execute("0|1", true).Should().Be(1);
      Solution.Execute("0^1", true).Should().Be(1);
      Solution.Execute("0&1", true).Should().Be(0);
    }

    [TestMethod]
    public void ComplexExpressionTest()
    {
      Solution.Execute("1^0|0|1", false).Should().Be(2);
      Solution.Execute("0&0&0&1^1|0", true).Should().Be(10);
    }

    [TestMethod]
    public void MemoVersionTest()
    {
      // TODO: implement memo version of problem 8.14
      false.Should().BeTrue();
    }
  }
}
