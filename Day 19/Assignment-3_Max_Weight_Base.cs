using System;
using System.Linq;
using System.Collections.Generic;

class Max_Weight_Base{
   public class Item
    {
        public char Name { get; set; }
        public int Profit { get; set; }
        public int Weight { get; set; }
    }

    public class SelectedItem
    {
        public char Name { get; set; }
        public double Profit { get; set; }
        public double Weight { get; set; }
        public double Fraction { get; set; }
    }

    static void Main()
    {
        char[] objects = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int[] profits = { 6, 10, 8, 4, 12, 14, 2 };
        int[] weights = { 1, 2, 4, 2, 6, 7, 1 };
        int maxWeight = 16;

        Console.WriteLine("Given data:");
        Console.WriteLine($"Objects: {string.Join(", ", objects)}");
        Console.WriteLine($"Profits: {string.Join(", ", profits)}");
        Console.WriteLine($"Weights: {string.Join(", ", weights)}");
        Console.WriteLine();

        var result = Knapsack(weights, profits, maxWeight, objects);

        Console.WriteLine($"Maximum profit: {result.maxProfit:F2}");
        Console.WriteLine("Selected items:");

        foreach (var item in result.selectedItems)
        {
            if (item.Fraction < 1)
            {
                Console.WriteLine($"Object {item.Name}: Profit = {item.Profit * item.Fraction:F2}, Weight = {item.Weight * item.Fraction:F2}, Fraction = {item.Fraction:F2}");
            }
            else
            {
                Console.WriteLine($"Object {item.Name}: Profit = {item.Profit:F2}, Weight = {item.Weight:F2}, Fraction = {item.Fraction:F2}");
            }
            
        }
        Console.WriteLine();
        Console.WriteLine("Maximum Profit Found by using Base Approach");
    }
    public static (double maxProfit, List<SelectedItem> selectedItems) Knapsack(int[] weights, int[] profits, int maxWeight, char[] objects)
    {
        int n = weights.Length;
        var dp = new double[n + 1, maxWeight + 1];
        var selectedItems = new List<SelectedItem>();
        for (int i = 1; i <= n; i++)
        {
            for (int w = 1; w <= maxWeight; w++)
            {
                if (weights[i - 1] <= w)
                {
                    dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + profits[i - 1]);
                }
                else
                {
                    dp[i, w] = dp[i - 1, w];
                }
            }
        }
        int remainingWeight = maxWeight;
        for (int i = n; i > 0; i--)
        {
            if (dp[i, remainingWeight] != dp[i - 1, remainingWeight])
            {
                selectedItems.Add(new SelectedItem
                {
                    Name = objects[i - 1],
                    Profit = profits[i - 1],
                    Weight = weights[i - 1],
                    Fraction = 1 
                });

                remainingWeight -= weights[i - 1];
            }
        }

        if (remainingWeight > 0)
        {
            for (int i = 0; i < n; i++)
            {
                if (weights[i] <= remainingWeight)
                {
                    continue;
                }

                double fraction = (double)remainingWeight / weights[i];
                selectedItems.Add(new SelectedItem
                {
                    Name = objects[i],
                    Profit = profits[i],
                    Weight = weights[i],
                    Fraction = fraction
                });

                break; 
            }
        }

        double totalProfit = selectedItems.Sum(item => item.Profit * item.Fraction);
        return (totalProfit, selectedItems);
    }
}
