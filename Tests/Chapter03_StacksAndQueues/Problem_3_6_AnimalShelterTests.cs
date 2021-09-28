namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Tests
{
  using System;
  using FluentAssertions;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using AnimalShelter = CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues.Problem_3_6_AnimalShelter;

  [TestClass]
  public class Problem_3_6_AnimalShelterTests
  {
    [TestMethod]
    public void DequeueOldestTest()
    {
      var shelter = new AnimalShelter();
      shelter.Enqueue(AnimalType.Cat);
      shelter.Enqueue(AnimalType.Dog);
      shelter.DequeueOldest().Should().Be(AnimalType.Cat);
      shelter.DequeueOldest().Should().Be(AnimalType.Dog);
    }

    [TestMethod]
    public void DequeueEmptyTest()
    {
      var shelter = new AnimalShelter();
      Action act = () => shelter.DequeueOldest();
      act.Should().Throw<InvalidOperationException>().WithMessage("No animals available");
    }

    [TestMethod]
    public void DequeueCatTest()
    {
      var shelter = new AnimalShelter();
      shelter.Enqueue(AnimalType.Cat);
      shelter.DequeueCat().Should().Be(AnimalType.Cat);
    }

    [TestMethod]
    public void DequeueEmptyCatTest()
    {
      var shelter = new AnimalShelter();
      Action act = () => shelter.DequeueCat();
      act.Should().Throw<InvalidOperationException>().WithMessage("No animals available of type 'Cat'");
    }

    [TestMethod]
    public void DequeueDogTest()
    {
      var shelter = new AnimalShelter();
      shelter.Enqueue(AnimalType.Dog);
      shelter.DequeueDog().Should().Be(AnimalType.Dog);
    }

    [TestMethod]
    public void DequeueEmptyDogTest()
    {
      var shelter = new AnimalShelter();
      Action act = () => shelter.DequeueDog();
      act.Should().Throw<InvalidOperationException>().WithMessage("No animals available of type 'Dog'");
    }
  }
}
