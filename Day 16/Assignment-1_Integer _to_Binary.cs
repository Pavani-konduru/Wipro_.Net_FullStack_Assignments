using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            string binaryRepresentation = IntToBinary(number);
            Console.WriteLine($"The binary representation of {number} is {binaryRepresentation}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static string IntToBinary(int n)
    {
        return Convert.ToString(n, 2);
    }
}