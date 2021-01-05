namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Problem_2_7_Intersection;

  [TestClass]
  public class Problem_2_7_IntersectionTests
  {
    [TestMethod]
    public void NullTest()
    {
      Problem.Execute(null, null).Should().BeNull();
      Problem.ExecuteSaveSpace(null, null).Should().BeNull();
    }

    [TestMethod]
    public void NoIntersectionTest()
    {
      var one = AListNode<int>.FromArray(new int[] { 0, 1, 2, });
      var two = AListNode<int>.FromArray(new int[] { 0, 1, 2, });
      Problem.Execute(one, two).Should().BeNull();
      Problem.ExecuteSaveSpace(one, two).Should().BeNull();
    }

    [TestMethod]
    public void IntersectionTest()
    {
      var one = AListNode<int>.FromArray(new int[] { 0, 1, 2, });
      var two = AListNode<int>.FromArray(new int[] { 0, 1, });

      two.Next.Next = one.Next;

      Problem.Execute(one, two).Should().BeSameAs(one.Next);
      Problem.ExecuteSaveSpace(one, two).Should().BeSameAs(one.Next);
    }
  }
}
