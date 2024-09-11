using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public class Item
    {
        public char Name { get; set; }
        public int Profit { get; set; }
        public int Weight { get; set; }
        public double ProfitPerWeight { get; set; }
    }

    static void Main()
    {
        Item[] items = {
            new Item { Name = 'A', Profit = 6, Weight = 1 },
            new Item { Name = 'B', Profit = 10, Weight = 2 },
            new Item { Name = 'C', Profit = 8, Weight = 4 },
            new Item { Name = 'D', Profit = 4, Weight = 2 },
            new Item { Name = 'E', Profit = 12, Weight = 6 },
            new Item { Name = 'F', Profit = 14, Weight = 7 },
            new Item { Name = 'G', Profit = 2, Weight = 1 }
        };

        int maxWeight = 16;

        Console.WriteLine("Given data:");
        Console.WriteLine($"Items: {string.Join(", ", items.Select(item => item.Name))}");
        Console.WriteLine($"Profits: {string.Join(", ", items.Select(item => item.Profit))}");
        Console.WriteLine($"Weights: {string.Join(", ", items.Select(item => item.Weight))}");
        Console.WriteLine();

        foreach (var item in items)
        {
            item.ProfitPerWeight = (double)item.Profit / item.Weight;
        }
        var sortedItems = items.OrderByDescending(item => item.ProfitPerWeight).ToArray();
        double totalProfit = 0;
        int totalWeight = 0;
        List<Item> selectedItems = new List<Item>();

        foreach (var item in sortedItems)
        {
            if (totalWeight + item.Weight <= maxWeight)
            {
                selectedItems.Add(item);
                totalProfit += item.Profit;
                totalWeight += item.Weight;
            }
            else
            {
                int remainingWeight = maxWeight - totalWeight;
                if (remainingWeight > 0)
                {
                    var fractionalItem = new Item
                    {
                        Name = item.Name,
                        Profit = (int)(item.ProfitPerWeight * remainingWeight),
                        Weight = remainingWeight,
                        ProfitPerWeight = item.ProfitPerWeight
                    };

                    selectedItems.Add(fractionalItem);
                    totalProfit += fractionalItem.Profit;
                    totalWeight += fractionalItem.Weight;
                }
                break; 
            }
        }
        Console.WriteLine("Selected items:");
        foreach (var item in selectedItems)
        {
            Console.WriteLine($"Object {item.Name}: Profit = {item.Profit}, Weight = {item.Weight}, Profit/Weight Ratio = {item.ProfitPerWeight:F2}");
        }

        Console.WriteLine($"Total weight of selected items: {totalWeight}");
        Console.WriteLine($"Maximum profit: {totalProfit}");
        Console.WriteLine();
        Console.WriteLine("Maximum Profit found by using P/W Approach");
    }
}
