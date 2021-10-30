namespace CrackingTheCodingInterview.Problems.Chapter16_Moderate
{
  using System;
  using System.Collections.Generic;

  // TODO: Add tests
  // TODO: Finish
  public static class Problem_16_12_XmlEncoding
  {
    public static string Execute(string input, Element element)
    {
      return string.Empty;
    }

    public class Element
    {
      public List<Attribute> Attributes { get; }
    }

    public record Attribute
    {
      public string Name { get; }

      public string Value { get; }
    }
  }
}
