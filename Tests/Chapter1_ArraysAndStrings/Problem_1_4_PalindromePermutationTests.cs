namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem = Problem_1_4_PalindromePermutation;

    [TestClass()]
    public class Problem_1_4_PalindromePermutationTests
    {
        [TestMethod()]
        public void NullOrEmptyTest() => Problem.Execute("").Should().BeFalse();

        [TestMethod()]
        public void CapsTest() => Problem.Execute("Anna").Should().BeFalse();

        [TestMethod()]
        public void EvenCountsTest() => Problem.Execute("anna").Should().BeTrue();

        [TestMethod()]
        public void OddCountsTest() => Problem.Execute("anbna").Should().BeTrue();

        [TestMethod()]
        public void OutOfOrderTest() => Problem.Execute("nnaba").Should().BeTrue();

        [TestMethod()]
        public void MissingPairsTest() => Problem.Execute("tannab").Should().BeFalse();
    }
}
