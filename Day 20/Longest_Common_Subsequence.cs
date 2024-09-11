using System;

class Program
{
    static void Main()
    {
        string A = "aabcdefghij";
        string B = "ecdgi";

        int length = LongestCommonSubsequence(A, B, out string lcs);

        Console.WriteLine("Length of the LCS: " + length);

        Console.WriteLine("Longest Common Subsequence: " + lcs);
    }

    static int LongestCommonSubsequence(string A, string B, out string lcs)
    {
        int m = A.Length;
        int n = B.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (A[i - 1] == B[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        lcs = "";
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            if (A[x - 1] == B[y - 1])
            {
                lcs = A[x - 1] + lcs;
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }

        return dp[m, n];
    }
}
