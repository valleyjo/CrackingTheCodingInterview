namespace CrackingTheCodingInterview.Problems.Chapter1_ArraysAndStrings.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;

    [TestClass]
    public class Problem_1_1_IsUniqueTests
    {
        [TestMethod]
        public void IsUniqueNullTest() => Problem_1_1_IsUnique.IsUnique(null).Should().BeFalse();

        [TestMethod]
        public void IsUniqueEmptyTest() => Problem_1_1_IsUnique.IsUnique(string.Empty).Should().BeFalse();

        [TestMethod]
        public void IsUniqueTrueTest() => Problem_1_1_IsUnique.IsUnique("Fred").Should().BeTrue();

        [TestMethod]
        public void IsUniqueCapsTest() => Problem_1_1_IsUnique.IsUnique("Ffed").Should().BeTrue();

        [TestMethod]
        public void IsUniqueFalseTest() => Problem_1_1_IsUnique.IsUnique("Anna").Should().BeFalse();

        [TestMethod]
        public void IsUniqueNoAllocNullTest() => Problem_1_1_IsUnique.IsUniqueNoAlloc(null).Should().BeFalse();

        [TestMethod]
        public void IsUniqueNoAllocEmptyTest() => Problem_1_1_IsUnique.IsUniqueNoAlloc(string.Empty).Should().BeFalse();

        [TestMethod]
        public void IsUniqueNoAllocTrueTest() => Problem_1_1_IsUnique.IsUniqueNoAlloc("Fred").Should().BeTrue();

        [TestMethod]
        public void IsUniqueNoAllocCapsTest() => Problem_1_1_IsUnique.IsUniqueNoAlloc("Ffed").Should().BeTrue();

        [TestMethod]
        public void IsUniqueNoAllocFalseTest() => Problem_1_1_IsUnique.IsUniqueNoAlloc("Anna").Should().BeFalse();
    }
}
