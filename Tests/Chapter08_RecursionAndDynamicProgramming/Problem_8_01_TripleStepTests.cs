namespace CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Solution = CrackingTheCodingInterview.Problems.Chapter08_RecursionAndDynamicProgramming.Problem_8_01_TripleStep;

  [TestClass]
  public class Problem_8_01_TripleStepTests
  {
    [TestMethod]
    public void ZeroTest() => Solution.Execute(0).Should().Be(1);

    [TestMethod]
    public void OneTest() => Solution.Execute(1).Should().Be(1);

    [TestMethod]
    public void TwoTest() => Solution.Execute(2).Should().Be(2);

    [TestMethod]
    public void ThreeTest() => Solution.Execute(3).Should().Be(4);

    [TestMethod]
    public void FourTest() => Solution.Execute(4).Should().Be(7);

    [TestMethod]
    public void Memo_ZeroTest() => Solution.ExecuteMemo(0).Should().Be(1);

    [TestMethod]
    public void Memo_OneTest() => Solution.ExecuteMemo(1).Should().Be(1);

    [TestMethod]
    public void Memo_TwoTest() => Solution.ExecuteMemo(2).Should().Be(2);

    [TestMethod]
    public void Memo_ThreeTest() => Solution.ExecuteMemo(3).Should().Be(4);

    [TestMethod]
    public void Memo_FourTest() => Solution.ExecuteMemo(4).Should().Be(7);
  }
}
