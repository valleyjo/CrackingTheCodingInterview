namespace CrackingTheCodingInterview.Problems.Special
{
  using System;
  using System.Collections.Generic;

  public class Problem_g_01_TicketToRide
  {
    public enum Color
    {
      Pink,
      White,
      Blue,
      Yellow,
      Orange,
      Black,
      Red,
      Green,
      Wild,
    }

    public enum City
    {
      LosAngeles,
      SanFrancisco,
      Portland,
      Seattle,
      Vancouver,
      Calgary,
      Helena,
      SaltLakeCity,
      LasVegas, /* etc */
    }

    public interface IConnectionScorer
    {
      public int Score(Connection connection);
    }

    public class Connection
    {
      // The two cities being connected. They can be in any order.
      public City City1 { get; }

      public City City2 { get; }

      // The cost of purchasing this connection, as the count of
      // cards and the color. A wild color for the COST means a
      // count of any ONE regular color can be used.
      public int Count { get; }

      public Color Color { get; }

      // Constructors, etc left to the imagination
    }

    public class DestinationTicket
    {
      // The two endpoints can be in any order.
      public City City1 { get; }

      public City City2 { get; }

      public int ExtraPoints { get; }
    }

    public class Board
    {
      // All connections on the board
      public Connection[] AllConnections { get; }

      // All connections that haven’t been purchased yet
      public Connection[] AvailableConnections { get; }

      // In the full game, more might go here like the draw decks.
    }

    public class Player
    {
      // The player’s hand -- the color cards they have.
      public Color[] Hand { get; }

      public DestinationTicket[] Tickets { get; }

      public Connection[] OwnedConnections { get; }

      public IConnectionScorer[] ConnectionScorers { get; }

      public Connection RankPurchaseableConnections(Connection[] availableConnections)
      {
        /*
        Step 1: Find component routes from connection destination cards. This ensures I am only looking at connections
        I actually need.
        Step 2: Filter purchaseable routes
        Step 3: Evualate each connection against the set of rules, and add in the result.
        Step 4: Add connection score to a max heap
        Step 5: take the top connection as the route to buy

        Step N: calculate a "score" for each route, score is each component element prioritized
          by a fixed base 10 magnitude. Some scores have adjustments to increase or decrease the
          value within that magnitude. This allows sorting within a given evaluation criteria.
        Sorting is simple, just use a max heap.

        Priotirization:

        Category 1: Most points
        1) most frequent track -> highest points per card
        2) longest track -> most points per track

        Category 2: Scaracity, try to get routes that are easy to get by others
        3) grey track
        4) short track
        5) low count of city connections
        track for highest point value route
        */

        /*
        public class LengthConnectionScorer : IConnectionScorer
        {
          private const int Priority = 4;

          public int Score(Connection connection)
          {
            return Math.Pow(10,Priority) * count;
          }
        }
        */

        /*
        List<Connections> neededConnections = new List<Connection>();
        foreach (Destination dest in this.Destinations)
        {
          // Assume connection graph is already built
          // When a connection is initted inthe graph, it's owner is null / empty
          // when a connection is purchased it's marked as owned by a user
          // As the graph searches for the shortest part, it is allowed to take a path
          // that is uninitialized or owned by the user initiating the search. If the path
          // is unowned, it is added to the needed path list
          List<Connection> tmp = connectionGraph.FindShortestPath(dest.Start, dest.End, this.UserId);
          neededConenctions.AddRange(tmp);
        }

        neededConnections = this.FilterPurchaseableConnections(neededConnections);
        */

        // new method FindBestConnection
        int maxScore = 0;
        Connection bestConnection = null;
        foreach (Connection connection in availableConnections)
        {
          int score = 0;
          foreach (IConnectionScorer scorer in this.ConnectionScorers)
          {
            score += scorer.Score(connection);
          }

          if (score > maxScore)
          {
            maxScore = score;
            bestConnection = connection;
          }
        }

        return bestConnection;
      }

      public List<Connection> FilterPurchaseableRoutes(Connection[] availableConnections)
      {
        var results = new List<Connection>();
        Dictionary<Color, int> colorCounts = this.GetHandCounts();

        foreach (Connection connection in availableConnections)
        {
          int colorCount = colorCounts[connection.Color];
          int wildCount = colorCounts[Color.Wild];

          // wild routes can be purchased with any color
          if (connection.Color == Color.Wild)
          {
            foreach (KeyValuePair<Color, int> kvp in colorCounts)
            {
              if (connection.Count <= kvp.Value + wildCount)
              {
                results.Add(connection);
              }
            }
          }
          else if (connection.Count <= colorCount || connection.Count <= colorCount + wildCount)
          {
            results.Add(connection);
          }
        }

        return results;
      }

      private Dictionary<Color, int> GetHandCounts()
      {
        var result = new Dictionary<Color, int>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
        {
          result[color] = 0;
        }

        foreach (Color color in this.Hand)
        {
          result[color]++;
        }

        return result;
      }

      // In the full game, more might go here like total points.
    }
  }
}
