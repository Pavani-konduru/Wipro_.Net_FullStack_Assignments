using System;

class Swap_Bits
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            Console.Write("Enter the position of the first bit: ");
            if (int.TryParse(Console.ReadLine(), out int pos1) &&
                pos1 >= 0 && pos1 < 32)
            {
                Console.Write("Enter the position of the second bit: ");
                if (int.TryParse(Console.ReadLine(), out int pos2) &&
                    pos2 >= 0 && pos2 < 32) 
                {
                    int swappedNumber = SwapBits(number, pos1, pos2);
                    Console.WriteLine($"The number after swapping bits at positions {pos1} and {pos2} is {swappedNumber}.");
                }
                else
                {
                    Console.WriteLine("Invalid position for the second bit.");
                }
            }
            else
            {
                Console.WriteLine("Invalid position for the first bit.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static int SwapBits(int n, int pos1, int pos2)
    {
        
        bool bit1 = (n & (1 << pos1)) != 0;
        bool bit2 = (n & (1 << pos2)) != 0;
        if (bit1 != bit2)
        {
        
            n ^= (1 << pos1); 
            n ^= (1 << pos2);
        }
        return n;
    }
}