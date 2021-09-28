namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Problem_1_1_IsUnique;

  [TestClass]
  public class Problem_1_1_IsUniqueTests
  {
    [TestMethod]
    public void IsUniqueNullTest() => Problem.IsUnique(null).Should().BeFalse();

    [TestMethod]
    public void IsUniqueEmptyTest() => Problem.IsUnique(string.Empty).Should().BeFalse();

    [TestMethod]
    public void IsUniqueTrueTest() => Problem.IsUnique("Fred").Should().BeTrue();

    [TestMethod]
    public void IsUniqueCapsTest() => Problem.IsUnique("Ffed").Should().BeTrue();

    [TestMethod]
    public void IsUniqueFalseTest() => Problem.IsUnique("Anna").Should().BeFalse();

    [TestMethod]
    public void IsUniqueNoAllocNullTest() => Problem.IsUniqueNoAlloc(null).Should().BeFalse();

    [TestMethod]
    public void IsUniqueNoAllocEmptyTest() => Problem.IsUniqueNoAlloc(string.Empty).Should().BeFalse();

    [TestMethod]
    public void IsUniqueNoAllocTrueTest() => Problem.IsUniqueNoAlloc("Fred").Should().BeTrue();

    [TestMethod]
    public void IsUniqueNoAllocCapsTest() => Problem.IsUniqueNoAlloc("Ffed").Should().BeTrue();

    [TestMethod]
    public void IsUniqueNoAllocFalseTest() => Problem.IsUniqueNoAlloc("Anna").Should().BeFalse();
  }
}
