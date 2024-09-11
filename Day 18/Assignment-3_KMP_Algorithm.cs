using System;

public class KMPAlgorithm
{
    public static void Main(string[] args)
    {
        string text = "aabcabcadbeabc";
        string pattern = "abc";
        KMPSearch(text, pattern);
    }

    private static void KMPSearch(string text, string pattern)
    {
        int m = pattern.Length;
        int n = text.Length;

        int[] lps = ComputeLPSArray(pattern);

        int i = 0; 
        int j = 0;
        Console.WriteLine("Text: " + text);
        Console.WriteLine("Pattern: " + pattern);
        Console.WriteLine();
        while (i < n)
        {
            if (pattern[j] == text[i])
            {
                i++;
                j++;
            }

            if (j == m)
            {
               //onsole.WriteLine($"Pattern found at index: {i - j}");
                Console.WriteLine($"Pattern 'abc' found at index: {i - j}");

                j = lps[j - 1];
            }
            else if (i < n && pattern[j] != text[i])
            {
                if (j != 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("The pattern abc was found at total of 3 times in aabcabcabdeabc using KMP_Algorithm");

    }

    private static int[] ComputeLPSArray(string pattern)
    {
        int m = pattern.Length;
        int[] lps = new int[m];
        int length = 0; 
        int i = 1;

        lps[0] = 0; 

        while (i < m)
        {
            if (pattern[i] == pattern[length])
            {
                length++;
                lps[i] = length;
                i++;
            }
            else
            {
                if (length != 0)
                {
                    length = lps[length - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
        }
        return lps;
    }
}
