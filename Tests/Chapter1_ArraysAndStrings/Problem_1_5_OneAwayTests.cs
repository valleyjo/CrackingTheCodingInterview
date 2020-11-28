namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class Problem_1_5_OneAwayTests
    {
        [TestMethod()]
        public void NullOrEmptyTest() => Problem_1_5_OneAway.Execute(null, string.Empty).Should().BeFalse();

        [TestMethod()]
        public void OneInsertAtEndTest() => Problem_1_5_OneAway.Execute("freddy", "freddya").Should().BeTrue();

        [TestMethod()]
        public void OneInsertAtStartTest() => Problem_1_5_OneAway.Execute("afreddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneInsertAtMiddleTest() => Problem_1_5_OneAway.Execute("freaddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtEndTest() => Problem_1_5_OneAway.Execute("freddy", "fredd").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtStartTest() => Problem_1_5_OneAway.Execute("reddy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void OneRemoveAtMiddleTest() => Problem_1_5_OneAway.Execute("fredy", "freddy").Should().BeTrue();

        [TestMethod()]
        public void ZeroEditsTest() => Problem_1_5_OneAway.Execute("Freddy", "Freddy").Should().BeTrue();

        [TestMethod()]
        public void TwoEditsAway() => Problem_1_5_OneAway.Execute("Freddy", "Fred").Should().BeFalse();
    }
}
