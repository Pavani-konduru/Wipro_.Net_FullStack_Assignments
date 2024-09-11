using System;

class Max_Profit_Weight
{
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

        var result = Knapsack(weights, profits, maxWeight);
        Console.WriteLine($"Maximum profit: {result.maxProfit}");
        Console.WriteLine("Selected items:");

        foreach (var item in result.selectedItems)
        {
            Console.WriteLine($"Object {item.Object}: Profit = {item.Profit}, Weight = {item.Weight}");
        }
        Console.WriteLine();
        Console.WriteLine("Maximum Profit Found by using Weight as Base Approach");

    }
    public static (int maxProfit, SelectedItem[] selectedItems) Knapsack(int[] weights, int[] profits, int maxWeight)
    {
        int n = weights.Length;
        int[,] dp = new int[n + 1, maxWeight + 1];

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
        var selectedItems = new System.Collections.Generic.List<SelectedItem>();

        for (int i = n; i > 0 && remainingWeight > 0; i--)
        {
            if (dp[i, remainingWeight] != dp[i - 1, remainingWeight])
            {
                selectedItems.Add(new SelectedItem
                {
                    Object = (char)('A' + i - 1),
                    Profit = profits[i - 1],
                    Weight = weights[i - 1]
                });

                remainingWeight -= weights[i - 1];
            }
        }

        return (dp[n, maxWeight], selectedItems.ToArray());
    }
    public class SelectedItem
    {
        public char Object { get; set; }
        public int Profit { get; set; }
        public int Weight { get; set; }
    }
}
