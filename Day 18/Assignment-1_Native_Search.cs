using System;

class Native_Search
{
    static void Main()
    {
        string text = "aabcabcabdeabc";
        string pattern = "abc";

        NativeSearch(text, pattern);
       
       

    }


    static void NativeSearch(string text, string pattern)
    {
        int textLength = text.Length;
        int patternLength = pattern.Length;
        Console.WriteLine("Text: " + text);
        Console.WriteLine("Pattern: " + pattern);
        Console.WriteLine();

        if (patternLength == 0 || textLength == 0 || patternLength > textLength)
        {
            Console.WriteLine("Pattern is too long or empty.");
            return;
        }

        for (int i = 0; i <= textLength - patternLength; i++)
        {
            string substring = text.Substring(i, patternLength);

            if (substring == pattern)
            {
               
                Console.WriteLine($"Pattern 'abc' found at index: {i}");

            }
        }
        Console.WriteLine();
        Console.WriteLine("The pattern abc was found at total of 3 times in aabcabcabdeabc using NATIVE search");

    }
}
