namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using System.Collections.Generic;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_12_EightQueens;

  [TestClass]
  public class Problem_8_12_EightQueensTests
  {
    [TestMethod]
    public void SizeOneTest() => Solution.Execute(1).Should().BeEquivalentTo(new List<List<Coordinate>>() { new List<Coordinate>() { new Coordinate(0, 0) } });

    [TestMethod]
    public void SizeFiveTest() => Solution.Execute(5).Should().HaveCount(10);

    [TestMethod]
    public void SizeSixTest() => Solution.Execute(6).Should().HaveCount(4);

    [TestMethod]
    public void SizeSevenTest() => Solution.Execute(7).Should().HaveCount(40);

    [TestMethod]
    public void SizeEightTest() => Solution.Execute(8).Should().HaveCount(92);

    /* Slow but passing tests
    [TestMethod]
    public void SizeNineTest() => Solution.Execute(9).Should().HaveCount(352);

    [TestMethod]
    public void SizeTenTest() => Solution.Execute(10).Should().HaveCount(724);

    [TestMethod]
    public void SizeElevenTest() => Solution.Execute(11).Should().HaveCount(2680);
    */
  }
}
