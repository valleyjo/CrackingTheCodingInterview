namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass()]
    public class Problem_1_4_PalindromePermutationTests
    {
        [TestMethod()]
        public void NullOrEmptyTest() => Problem_1_4_PalindromePermutation.Execute("").Should().BeFalse();

        [TestMethod()]
        public void CapsTest() => Problem_1_4_PalindromePermutation.Execute("Anna").Should().BeFalse();

        [TestMethod()]
        public void EvenCountsTest() => Problem_1_4_PalindromePermutation.Execute("anna").Should().BeTrue();

        [TestMethod()]
        public void OddCountsTest() => Problem_1_4_PalindromePermutation.Execute("anbna").Should().BeTrue();

        [TestMethod()]
        public void OutOfOrderTest() => Problem_1_4_PalindromePermutation.Execute("nnaba").Should().BeTrue();

        [TestMethod()]
        public void MissingPairsTest() => Problem_1_4_PalindromePermutation.Execute("tannab").Should().BeFalse();
    }
}
