using System;

public class RabinKarp
{
    private const int Base = 256; 
    private const int Prime = 101; 

    public static void Main(string[] args)
    {
        string text = "aabcabcadbeabc";
        string pattern = "abc";

        RabinKarpSearch(text, pattern);
    }

    private static void RabinKarpSearch(string text, string pattern)
    {
        int m = pattern.Length;   

        int n = text.Length;
        int patternHash = ComputeHash(pattern, m);
        int textHash = ComputeHash(text, m);
        int h = ComputeInitialHashMultiplier(m);
        Console.WriteLine("Text: " + text);
        Console.WriteLine("Pattern: " + pattern);

        Console.WriteLine($"Pattern Hash: {patternHash}");
        Console.WriteLine($"Initial Text Hash: {textHash}");

        for (int i = 0; i <= n - m; i++)
        {
            Console.WriteLine($"Text Hash '{text.Substring(i, m)}' Hash: {textHash}");

            if (patternHash == textHash && text.Substring(i, m) == pattern)
            {
                Console.WriteLine($"Pattern found at index {i}");
            }

            if (i < n - m)
            {
                textHash = RollHash(textHash, text[i], text[i + m], h);
            }
        }
        Console.WriteLine();
        Console.WriteLine("The pattern abc was found at total of 3 times in aabcabcabdeabc using RabinKarp ");
    }

    private static int ComputeHash(string str, int length)
    {
        int hash = 0;
        for (int i = 0; i < length; i++)
        {
            hash = (Base * hash + str[i]) % Prime;
        }
        return hash;
    }

    private static int ComputeInitialHashMultiplier(int length)
    {
        int h = 1;
        for (int i = 0; i < length - 1; i++)
        {
            h = (h * Base) % Prime;
        }
        return h;
    }

    private static int RollHash(int oldHash, char oldChar, char newChar, int h)
    {
        int newHash = (Base * (oldHash - oldChar * h) + newChar) % Prime;
        if (newHash < 0) 
        {
            newHash += Prime;
        }
        return newHash;
    }
}
