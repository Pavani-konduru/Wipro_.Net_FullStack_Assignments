using System;
using System.Collections;
using System.Collections.Generic;

public class Graph
{
    private readonly Dictionary<int, List<(int, int)>> _adjacencyList = new();

    public void AddEdge(int from, int to, int weight)
    {
        if (!_adjacencyList.ContainsKey(from))
            _adjacencyList[from] = new List<(int, int)>();
        if (!_adjacencyList.ContainsKey(to))
            _adjacencyList[to] = new List<(int, int)>();

        _adjacencyList[from].Add((to, weight));
        _adjacencyList[to].Add((from, weight)); 
    }

    public Dictionary<int, int> Dijkstra(int start)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new SortedSet<(int distance, int node)>();
        var visited = new HashSet<int>();

        foreach (var node in _adjacencyList.Keys)
        {
            distances[node] = int.MaxValue;
        }
        distances[start] = 0;

        priorityQueue.Add((0, start));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentNode) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            if (visited.Contains(currentNode))
                continue;

            visited.Add(currentNode);

            foreach (var (neighbor, weight) in _adjacencyList[currentNode])
            {
                if (visited.Contains(neighbor))
                    continue;

                var newDistance = currentDistance + weight;
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    priorityQueue.Add((newDistance, neighbor));
                }
            }
        }
        return distances;
   }   
}
public class Shortest_Path
{
    public static void Main()
    {
        var graph = new Graph();
       
        graph.AddEdge(1, 2, 7);
        graph.AddEdge(1, 3, 9);
        graph.AddEdge(1, 6, 11);
        graph.AddEdge(2, 3, 10);
        graph.AddEdge(2, 4, 15);
        graph.AddEdge(3, 4, 11);
        graph.AddEdge(3, 6, 2);
        graph.AddEdge(4, 5, 6);
        graph.AddEdge(5, 6, 9);      
        var distances = graph.Dijkstra(1);

        foreach (var distance in distances)
        {
            Console.WriteLine("------------");
            Console.WriteLine("Distance from start node: ");

            Console.WriteLine($"Distance from 1 to {distance.Key} is {distance.Value}");
        }
    }
}