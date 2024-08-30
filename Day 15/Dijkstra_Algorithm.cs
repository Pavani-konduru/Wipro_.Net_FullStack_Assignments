using System;
using System.Collections.Generic;
using System.Linq;

public class Edge
{
    public int Destination { get; }
    public int Weight { get; }

    public Edge(int destination, int weight)
    {
        Destination = destination;
        Weight = weight;
    }
}

public class Graph
{
    private readonly Dictionary<int, List<Edge>> _adjacencyList;

    public Graph(int numVertices)
    {
        _adjacencyList = new Dictionary<int, List<Edge>>();
        for (int i = 0; i < numVertices; i++)
        {
            _adjacencyList[i] = new List<Edge>();
        }
    }

    public void AddEdge(int source, int destination, int weight)
    {
        _adjacencyList[source].Add(new Edge(destination, weight));
        _adjacencyList[destination].Add(new Edge(source, weight));
    }

    public void Dijkstra(int start)
    {
        int numVertices = _adjacencyList.Count;
        int[] distances = Enumerable.Repeat(int.MaxValue, numVertices).ToArray();
        bool[] visited = new bool[numVertices];
        distances[start] = 0;

        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
        priorityQueue.Enqueue(start, 0);

        while (priorityQueue.Count > 0)
        {
            int current = priorityQueue.Dequeue();
            if (visited[current]) continue;

            visited[current] = true;

            foreach (var edge in _adjacencyList[current])
            {
                if (visited[edge.Destination]) continue;

                int newDist = distances[current] + edge.Weight;
                if (newDist < distances[edge.Destination])
                {
                    distances[edge.Destination] = newDist;
                    priorityQueue.Enqueue(edge.Destination, newDist);
                }
            }
        }
        Console.WriteLine("------Dijkstra's Algorithm-------");
        Console.WriteLine("Vertex Distances from Source:");
        for (int i = 0; i < numVertices; i++)
        {
            Console.WriteLine($"Vertex {i}: {(distances[i] == int.MaxValue ? "Infinity" : distances[i].ToString())}");
        }
    }
}

public class Dijkstra_Algorithm
{
    public static void Main()
    {
        Graph graph = new Graph(5);
        graph.AddEdge(0, 1, 10);
        graph.AddEdge(0, 2, 3);
        graph.AddEdge(1, 2, 1);
        graph.AddEdge(1, 3, 2);
        graph.AddEdge(2, 1, 4);
        graph.AddEdge(2, 3, 8);
        graph.AddEdge(2, 4, 2);
        graph.AddEdge(3, 4, 7);
        graph.AddEdge(4, 3, 9);

        int source = 0; 
        graph.Dijkstra(source);
    }
}