namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_05_RecursiveMultiply;

  [TestClass]
  public class Problem_8_05_RecursiveMultiplyTests
  {
    [TestMethod]
    public void NormalTest() => Solution.Execute(5, 12).Should().Be(60);

    [TestMethod]
    public void ZeroTest() => Solution.Execute(0, 0).Should().Be(0);

    [TestMethod]
    public void OneTest() => Solution.Execute(1, 1).Should().Be(1);

    [TestMethod]
    public void NormalRecursiveTest() => Solution.ExecuteRecursive(5, 12).Should().Be(60);

    [TestMethod]
    public void ZeroRecursiveTest() => Solution.ExecuteRecursive(0, 0).Should().Be(0);

    [TestMethod]
    public void OneRecursiveTest() => Solution.ExecuteRecursive(1, 1).Should().Be(1);
  }
}
