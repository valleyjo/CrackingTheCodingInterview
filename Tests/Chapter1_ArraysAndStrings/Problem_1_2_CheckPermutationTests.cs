using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems.Chapter1_ArraysAndStrings.Tests
{
    [TestClass()]
    public class Problem_1_2_CheckPermutationTests
    {
        [TestMethod()]
        public void CheckPermutationNullTest() => Problem_1_2_CheckPermutation.Execute(null, null).Should().BeFalse();

        [TestMethod()]
        public void CheckPermutationEmptyTest() => Problem_1_2_CheckPermutation.Execute(string.Empty, string.Empty).Should().BeFalse();

        [TestMethod()]
        public void CheckPermutationTrueTest() => Problem_1_2_CheckPermutation.Execute("anna", "anna").Should().BeTrue();

        [TestMethod()]
        public void CheckPermutationFalseTest() => Problem_1_2_CheckPermutation.Execute("Anna", "anna").Should().BeFalse();

        [TestMethod()]
        public void CheckPermutationDifferentLengths() => Problem_1_2_CheckPermutation.Execute("Freddy", "Fredy").Should().BeFalse();
    }
}
