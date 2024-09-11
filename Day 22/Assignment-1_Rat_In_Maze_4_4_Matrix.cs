using System;
using System.Collections.Generic;
class Rat_In_Maze_4_4_Matrix
{
    static void Main()
    {
        int[,] maze = {
            {1, 0, 0, 0},
            {1, 1, 0, 1},
            {1, 1, 0, 0},
            {0, 1, 1, 1}
        };
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);

        bool[,] visited = new bool[n, m];
        List<List<(int, int)>> paths = new List<List<(int, int)>>();

        FindPaths(maze, 0, 0, visited, new List<(int, int)>(), paths);

        Console.WriteLine("All possible paths:");
        if (paths.Count == 0)
        {
            Console.WriteLine("No path found");
        }
        else
        {
            int pathIndex = 1;
            foreach (var path in paths)
            {
                Console.WriteLine($"Path {pathIndex}: {string.Join(" -> ", path)}");
                Console.WriteLine("Path visualization:");
                PrintPath(maze, path);
                Console.WriteLine();
                pathIndex++;
            }
        }
    }
    static void FindPaths(int[,] maze, int x, int y, bool[,] visited, List<(int, int)> path, List<List<(int, int)>> paths)
    {
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);

        if (x == n - 1 && y == m - 1)
        {
            path.Add((x, y));
            paths.Add(new List<(int, int)>(path));
            path.RemoveAt(path.Count - 1);
            return;
        }
        if (IsValidMove(maze, x, y, visited))
        {
            visited[x, y] = true;
            path.Add((x, y));

            FindPaths(maze, x, y + 1, visited, path, paths); 
            FindPaths(maze, x + 1, y, visited, path, paths); 
            FindPaths(maze, x, y - 1, visited, path, paths);
            FindPaths(maze, x - 1, y, visited, path, paths); 

            visited[x, y] = false;
            path.RemoveAt(path.Count - 1);
        }
    }
    static bool IsValidMove(int[,] maze, int x, int y, bool[,] visited)
    {
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);

        return x >= 0 && x < n && y >= 0 && y < m && maze[x, y] == 1 && !visited[x, y];
    }
    static void PrintPath(int[,] maze, List<(int, int)> path)
    {
        int n = maze.GetLength(0);
        int m = maze.GetLength(1);

        int[,] output = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                output[i, j] = 0;
            }
        }
        foreach (var (x, y) in path)
        {
            output[x, y] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(output[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}