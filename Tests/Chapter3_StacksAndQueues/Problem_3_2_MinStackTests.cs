namespace CrackingTheCodingInterview.Problems.Chapter3_StacksAndQueues.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using MinStack = Problem_3_2_MinStack;

  [TestClass]
  public class Problem_3_2_MinStackTests
  {
    [TestMethod]
    public void PushTest()
    {
      var stack = new MinStack();
      stack.Push(4);
      stack.Pop().Should().Be(4);
    }

    [TestMethod]
    public void PopTest()
    {
    }

    [TestMethod]
    public void IsEmptyTest()
    {
    }

    [TestMethod]
    public void GetMinTest()
    {
    }
  }
}
