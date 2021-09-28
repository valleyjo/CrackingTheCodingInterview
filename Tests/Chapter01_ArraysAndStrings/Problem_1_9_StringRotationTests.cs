namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Problem_1_9_StringRotation;

  [TestClass]
  public class Problem_1_9_StringRotationTests
  {
    [TestMethod]
    public void IsRotationTest() => Problem.IsRotation("keyboard", "ardkeybo").Should().BeTrue();

    [TestMethod]
    public void IsNotRotationTest() => Problem.IsRotation("keyboard", "keyboards").Should().BeFalse();
  }
}
