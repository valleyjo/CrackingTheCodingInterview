namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Problem_2_6_Palindrome;

  [TestClass]
  public class Problem_2_6_PalindromeTests
  {
    [TestMethod]
    public void NullTest() => Problem.Execute(null).Should().BeFalse();

    [TestMethod]
    public void SingleValueTest() => Problem.Execute(new AListNode<int>(1)).Should().BeFalse();

    [TestMethod]
    public void OddPalindromeTest() =>
      Problem.Execute(AListNode<int>.FromArray(new int[] { 1, 2, 3, 2, 1, })).Should().BeTrue();

    [TestMethod]
    public void OddNotPalindromeTest() =>
      Problem.Execute(AListNode<int>.FromArray(new int[] { 1, 2, 3, 6, 1, })).Should().BeFalse();

    [TestMethod]
    public void EvenPalindromeTest() =>
      Problem.Execute(AListNode<int>.FromArray(new int[] { 1, 2, 2, 1, })).Should().BeTrue();

    [TestMethod]
    public void EvenNotPalindromeTest() =>
      Problem.Execute(AListNode<int>.FromArray(new int[] { 1, 2, 3, 1, })).Should().BeFalse();
  }
}
