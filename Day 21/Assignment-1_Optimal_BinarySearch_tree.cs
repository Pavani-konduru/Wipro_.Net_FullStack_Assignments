using System;
class OptimalBST
{
    static void Main()
    {
        int[] keys = { 10, 20, 30, 40 };
        int[] frequencies = { 4, 2, 6, 3 };
        Console.WriteLine("Keys: " + string.Join(", ", keys));
        Console.WriteLine("Frequencies: " + string.Join(", ", frequencies));

        Console.WriteLine();
        int n = keys.Length;

        var result = OptimalBinarySearchTree(keys, frequencies, n);
        
        Console.WriteLine($"Cost of the Optimal Binary search tree: {result}");
    }

    static int OptimalBinarySearchTree(int[] keys, int[] frequencies, int n)
    {
        int[,] cost = new int[n, n];
        int[,] root = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            cost[i, i] = frequencies[i];
            root[i, i] = i;
        }

        for (int len = 2; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                cost[i, j] = int.MaxValue;
                int sum = 0;
                for (int k = i; k <= j; k++)
                {
                    sum += frequencies[k];
                }

                for (int r = i; r <= j; r++)
                {
                    int c = ((r > i) ? cost[i, r - 1] : 0) +
                            ((r < j) ? cost[r + 1, j] : 0) +
                            sum;

                    if (c < cost[i, j])
                    {
                        cost[i, j] = c;
                        root[i, j] = r;
                    }
                }
            }
        }
        return cost[0, n - 1];
    }
}
