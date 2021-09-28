namespace CrackingTheCodingInterview.Problems.Chapter03_StacksAndQueues
{
  using System;
  using System.Collections.Generic;

  /// <summary>
  /// Use an enum for AnimalType but this could easily be a class
  /// </summary>
  public enum AnimalType
  {
    Cat = 0,
    Dog = 1,
  }

  public class Problem_3_6_AnimalShelter
  {
    private readonly LinkedList<AnimalType> cats;
    private readonly LinkedList<AnimalType> dogs;
    private readonly LinkedList<AnimalType> oldestAnimal;

    public Problem_3_6_AnimalShelter()
    {
      this.cats = new LinkedList<AnimalType>();
      this.dogs = new LinkedList<AnimalType>();
      this.oldestAnimal = new LinkedList<AnimalType>();
    }

    public void Enqueue(AnimalType incomingAnimal)
    {
      switch (incomingAnimal)
      {
        case AnimalType.Cat:
          this.cats.AddLast(incomingAnimal);
          break;
        case AnimalType.Dog:
          this.dogs.AddLast(incomingAnimal);
          break;
      }

      // Add a copy into the oldest animal queue
      this.oldestAnimal.AddLast(incomingAnimal);
    }

    public AnimalType DequeueOldest()
    {
      if (this.oldestAnimal.Count == 0)
      {
        throw new InvalidOperationException("No animals available");
      }

      AnimalType oldest = this.oldestAnimal.First.Value;
      this.oldestAnimal.RemoveFirst();
      switch (oldest)
      {
        case AnimalType.Cat:
          this.cats.RemoveFirst();
          break;
        case AnimalType.Dog:
        default:
          this.dogs.RemoveFirst();
          break;
      }

      return oldest;
    }

    public AnimalType DequeueDog() => this.GetOrThrow(AnimalType.Dog);

    public AnimalType DequeueCat() => this.GetOrThrow(AnimalType.Cat);

    private AnimalType GetOrThrow(AnimalType requestedAnimalType)
    {
      LinkedList<AnimalType> queue;

      switch (requestedAnimalType)
      {
        case AnimalType.Cat:
          queue = this.cats;
          break;
        case AnimalType.Dog:
        default:
          queue = this.dogs;
          break;
      }

      if (queue.Count > 0)
      {
        AnimalType animal = queue.First.Value;
        queue.RemoveFirst();
        return animal;
      }
      else
      {
        throw new InvalidOperationException($"No animals available of type '{requestedAnimalType}'");
      }
    }
  }
}
