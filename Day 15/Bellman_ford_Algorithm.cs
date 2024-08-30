using System;
using System.Collections.Generic;

public class Edge
{ public int Source { get; }
    public int Destination { get; }
    public int Weight { get; }

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }
}
public class BellmanFord
{
    public static void FindShortestPaths(List<Edge> edges, int numVertices, int source)
    {
        int[] distances = new int[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            distances[i] = int.MaxValue;
        }
        distances[source] = 0;
        for (int i = 0; i < numVertices - 1; i++)
        {
            foreach (var edge in edges)
            {
                if (distances[edge.Source] != int.MaxValue &&
                    distances[edge.Source] + edge.Weight < distances[edge.Destination])
                {
                    distances[edge.Destination] = distances[edge.Source] + edge.Weight;
                }
            }
        }
        foreach (var edge in edges)
        {
            if (distances[edge.Source] != int.MaxValue &&
                distances[edge.Source] + edge.Weight < distances[edge.Destination])
            {
                Console.WriteLine("Graph contains a negative weight cycle");
                return;
            }
        }
        Console.WriteLine("---Bellman Ford Algorithm---");
        Console.WriteLine("Vertex Distances from Source:");
        for (int i = 0; i < numVertices; i++)
        {
            Console.WriteLine($"Vertex {i}: {(distances[i] == int.MaxValue ? "Infinity" : distances[i].ToString())}");
        }
    }
}
public class Program
{
    public static void Main()
    { 
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 3),
            new Edge(1, 2, 1),
            new Edge(1, 3, 2),
            new Edge(2, 1, 4),
            new Edge(2, 3, 8),
            new Edge(2, 4, 2),
            new Edge(3, 4, 7),
            new Edge(4, 3, 9)
        };

        int numVertices = 5;
        int source = 0; 

        BellmanFord.FindShortestPaths(edges, numVertices, source);
    }
}