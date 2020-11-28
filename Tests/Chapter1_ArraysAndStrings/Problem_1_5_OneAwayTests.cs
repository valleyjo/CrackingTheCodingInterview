namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem = Problem_1_5_OneAway;

    [TestClass()]
    public class Problem_1_5_OneAwayTests
    {
        [TestMethod()]
        public void NullOrEmptyTest() => Problem.Execute(null, string.Empty).Should().BeFalse();

        [TestMethod()]
        public void OneInsertAtEndTest() => Problem.Execute("freddy", "freddya").Should().BeTrue();

        [TestMethod()]
        public void OneInsertAtStartTest() => Problem.Execute("afreddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneInsertAtMiddleTest() => Problem.Execute("freaddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtEndTest() => Problem.Execute("freddy", "fredd").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtStartTest() => Problem.Execute("reddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtMiddleTest() => Problem.Execute("fredy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void ZeroEditsTest() => Problem.Execute("Freddy", "Freddy").Should().BeTrue();

        [TestMethod()]
        public void TwoEditsAway() => Problem.Execute("Freddy", "Fred").Should().BeFalse();
    }
}
