using System;
using System.Collections.Generic;
using System;
public class Edge : IComparable<Edge>
{
    public int Source { get; }
    public int Destination { get; }
    public int Weight { get; }

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }
    public int CompareTo(Edge other)
    {
        return Weight.CompareTo(other.Weight);
    }
}
public class UnionFind
{
    private readonly int[] _parent;
    private readonly int[] _rank;

    public UnionFind(int size)
    {
        _parent = new int[size];
        _rank = new int[size];
        for (int i = 0; i < size; i++)
        {
            _parent[i] = i;
            _rank[i] = 0;
        }
    }

    public int Find(int u)
    {
        if (_parent[u] != u)
        {
            _parent[u] = Find(_parent[u]); 
        }
        return _parent[u];
    }

    public void Union(int u, int v)
    {
        int rootU = Find(u);
        int rootV = Find(v);

        if (rootU != rootV)
        {
           
            if (_rank[rootU] > _rank[rootV])
            {
                _parent[rootV] = rootU;
            }
            else if (_rank[rootU] < _rank[rootV])
            {
                _parent[rootU] = rootV;
            }
            else
            {
                _parent[rootV] = rootU;
                _rank[rootU]++;
            }
        }
    }
}

public class KruskalMST
{
    public static (List<Edge> mstEdges, int mstCost) FindMST(int numVertices, List<Edge> edges)
    {
        
        edges.Sort();

        var unionFind = new UnionFind(numVertices);
        var mstEdges = new List<Edge>();
        int mstCost = 0;

        foreach (var edge in edges)
        {
            int rootU = unionFind.Find(edge.Source);
            int rootV = unionFind.Find(edge.Destination);

            
            if (rootU != rootV)
            {
                unionFind.Union(rootU, rootV);
                mstEdges.Add(edge);
                mstCost += edge.Weight;
            }
        }

        return (mstEdges, mstCost);
    }
}

public class Program
{
    public static void Main()
    {
       
        int numVertices = 4;
        var edges = new List<Edge>
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 6),
            new Edge(0, 3, 5),
            new Edge(1, 3, 15),
            new Edge(2, 3, 4)
        };

        var (mstEdges, mstCost) = KruskalMST.FindMST(numVertices, edges);

        Console.WriteLine("Edges in the Minimum Spanning Tree:");
        foreach (var edge in mstEdges)
        {
            Console.WriteLine($"({edge.Source}, {edge.Destination}) with weight {edge.Weight}");
        }

        Console.WriteLine($"Total cost of MST: {mstCost}");
    }
}