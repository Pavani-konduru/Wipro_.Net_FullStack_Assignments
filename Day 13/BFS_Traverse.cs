using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }  
    public void AddNode(int node)
    {
        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList[node] = new List<int>();
        }
    }
    
    public void AddEdge(int node1, int node2)
    {
        if (!adjacencyList.ContainsKey(node1))
            AddNode(node1);
        if (!adjacencyList.ContainsKey(node2))
            AddNode(node2);

        adjacencyList[node1].Add(node2);
        adjacencyList[node2].Add(node1);

    }
   
    public void BFS(int startNode)
    {
        if (!adjacencyList.ContainsKey(startNode))
        {
            Console.WriteLine("Node not found in the graph.");
            return;
        }
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
       
        visited.Add(startNode);
        queue.Enqueue(startNode);

        Console.WriteLine("BFS traversal starting from node " + startNode + ":");

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            Console.WriteLine(currentNode + " ");
   
            foreach (int neighbor in adjacencyList[currentNode])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddEdge(6, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);
        graph.AddEdge(3, 7);


        graph.BFS(1);
    }
}