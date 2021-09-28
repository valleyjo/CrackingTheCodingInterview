namespace CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings.Tests
{
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Problem = CrackingTheCodingInterview.Problems.Chapter01_ArraysAndStrings.Problem_1_3_Urlify;

  [TestClass]
  public class Problem_1_3_UrlifyTests
  {
    [TestMethod]
    public void ConvertAndAddCapacityTest()
    {
      const string Input = "Mr John Smith";
      char[] output = new char[] { 'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', default, default, default, default };
      Problem.ConvertAndAddCapacity(Input).Should().ContainInOrder(output);
    }

    [TestMethod]
    public void NullOrEmptyTest() => Problem_1_3_Urlify.Execute(null, 0).Should().Be(string.Empty);

    [TestMethod]
    public void NormalCaseTest()
    {
      const string Input = "Mr John Smith";
      Problem.Execute(
          Problem.ConvertAndAddCapacity(Input), Input.Length).Should().Be("Mr%20John%20Smith");
    }

    [TestMethod]
    public void ExtraSpacesTest()
    {
      const string Input = "Mr   John Smith";
      Problem.Execute(
        Problem.ConvertAndAddCapacity(Input), Input.Length).Should().Be("Mr%20%20%20John%20Smith");
    }

    [TestMethod]
    public void AllSpacesTest()
    {
      const string Input = "    ";
      Problem.Execute(Problem.ConvertAndAddCapacity(Input), Input.Length).Should().Be("%20%20%20%20");
    }
  }
}
