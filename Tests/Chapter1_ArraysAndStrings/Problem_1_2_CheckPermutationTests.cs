namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Problem_1_2_CheckPermutation;

  [TestClass]
  public class Problem_1_2_CheckPermutationTests
  {
    [TestMethod]
    public void CheckPermutationNullTest() => Problem.Execute(null, null).Should().BeFalse();

    [TestMethod]
    public void CheckPermutationEmptyTest() => Problem.Execute(string.Empty, string.Empty).Should().BeFalse();

    [TestMethod]
    public void CheckPermutationTrueTest() => Problem.Execute("anna", "anna").Should().BeTrue();

    [TestMethod]
    public void CheckPermutationFalseTest() => Problem.Execute("Anna", "anna").Should().BeFalse();

    [TestMethod]
    public void CheckPermutationDifferentLengths() => Problem.Execute("Freddy", "Fredy").Should().BeFalse();
  }
}
