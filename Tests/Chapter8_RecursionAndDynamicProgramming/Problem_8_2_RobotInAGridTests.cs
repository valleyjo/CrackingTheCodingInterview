namespace CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter8_RecursionAndDynamicProgramming.Problem_8_2_RobotInAGrid;

  [TestClass]
  public class Problem_8_2_RobotInAGridTests
  {
    private const bool T = true;
    private const bool F = false;

    [TestMethod]
    public void BlockedPathTest() => Solution.Execute(new bool[5, 5]).Should().BeFalse();

    [TestMethod]
    public void ValidPathTest()
    {
      bool[,] grid =
        {
          { T, T, T, F },
          { T, T, T, F },
          { T, F, T, T },
          { F, T, T, T },
        };

      Solution.Execute(grid).Should().BeTrue();
    }
  }
}
