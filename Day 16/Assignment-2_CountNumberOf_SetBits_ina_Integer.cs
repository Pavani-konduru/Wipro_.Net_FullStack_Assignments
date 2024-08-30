using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int setBitCount = CountSetBits(number);
            Console.WriteLine($"The number of set bits in {number} is {setBitCount}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static int CountSetBits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += (n & 1); 
            n >>= 1;          
        }
        return count;
    }
}