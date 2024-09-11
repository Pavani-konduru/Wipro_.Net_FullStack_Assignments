using System;
using System.Collections.Generic;

public class SubsetSum
{
    public static void Main()
    {
        int[] weights = { 5, 10, 12, 13, 14, 15, 18 };
        int targetSum = 30;

        List<List<int>> results = new List<List<int>>();
        FindSubsets(weights, targetSum, new List<int>(), 0, results);
        Console.WriteLine();

        Console.WriteLine("All subsets that sum up to " + targetSum + ":");
        foreach (var subset in results)
        {
            Console.WriteLine(string.Join(", ", subset));
        }
    }

    private static void FindSubsets(int[] weights, int targetSum, List<int> currentSubset, int start, List<List<int>> results)
    {
        if (targetSum == 0)
        {
            results.Add(new List<int>(currentSubset));
            return;
        }

        for (int i = start; i < weights.Length; i++)
        {
            if (weights[i] <= targetSum)
            {
                currentSubset.Add(weights[i]);
                FindSubsets(weights, targetSum - weights[i], currentSubset, i + 1, results);
                currentSubset.RemoveAt(currentSubset.Count - 1); 
            }
        }
    }
}
