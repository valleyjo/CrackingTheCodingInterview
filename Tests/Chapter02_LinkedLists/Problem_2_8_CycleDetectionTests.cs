namespace CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Tests
{
  using CrackingTheCodingInterview.Problems.DataStructures;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter2_LinkedLists.Problem_2_8_CycleDetection;

  [TestClass]
  public class Problem_2_8_CycleDetectionTests
  {
    [TestMethod]
    public void NullTest() => Problem.Execute(null).Should().BeNull();

    [TestMethod]
    public void NoCycleTwoNodeText() => Problem.Execute(AListNode<int>.FromArray(new int[] { 0, 1, })).Should().BeNull();

    [TestMethod]
    public void NoCycleTest() => Problem.Execute(AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, })).Should().BeNull();

    [TestMethod]
    public void TwoNodeCycleTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, });
      head.Next.Next = head;
      Problem.Execute(head).Should().BeSameAs(head);
    }

    [TestMethod]
    public void CycleTest()
    {
      var head = AListNode<int>.FromArray(new int[] { 0, 1, 2, 3, 4, });

      // get '4'
      var tail = head.Next.Next.Next.Next;

      // connect '4' to '2'
      tail.Next = head.Next.Next;

      Problem.Execute(head).Should().BeSameAs(head.Next.Next);
    }
  }
}
