using System;

class Program
{
    static void Main()
    {
        int[] array = { 7, 3, 5, 5, 9, 7, 11, 13, 13, 11, 17, 19 };

        Console.WriteLine("Original array:");
        PrintArray(array);

        (int num1, int num2) = FindTwoUniqueNumbers(array);

        Console.WriteLine($"The two unique numbers are: {num1} and {num2}");
    }

    static (int, int) FindTwoUniqueNumbers(int[] array)
    {
        int xorAll = 0;
        foreach (int num in array)
        {
            xorAll ^= num;
        }

        int setBit = xorAll & -xorAll; 

        int num1 = 0, num2 = 0;
        foreach (int num in array)
        {
            if ((num & setBit) == 0)
            {
                num1 ^= num; 
            }
            else
            {
                num2 ^= num; 
            }
        }

        return (num1, num2);
    }

    static void PrintArray(int[] array)
    {
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}