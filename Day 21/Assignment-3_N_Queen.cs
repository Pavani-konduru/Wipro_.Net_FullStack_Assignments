using System;
public class NQueens
{
    public static void Main()
    {
        int N = 4;
        int[,] board = new int[N, N];

        Console.WriteLine("Solving N-Queens for N = " + N);
        SolveNQueens(board, 0, N);
    }

    private static bool SolveNQueens(int[,] board, int row, int N)
    {
        if (row >= N)
        {
            PrintBoard(board, N);
            return true;
        }

        bool solutionFound = false;
        for (int col = 0; col < N; col++)
        {
            if (IsSafe(board, row, col, N))
            {
                board[row, col] = row + 1; 
                solutionFound = SolveNQueens(board, row + 1, N) || solutionFound;
                board[row, col] = 0;
            }
        }
        return solutionFound;
    }

    private static bool IsSafe(int[,] board, int row, int col, int N)
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i, col] > 0)
                return false;
        }

        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] > 0)
                return false;
        }

        for (int i = row, j = col; i >= 0 && j < N; i--, j++)
        {
            if (board[i, j] > 0)
                return false;
        }

        return true;
    }
    private static void PrintBoard(int[,] board, int N)
    {
        Console.WriteLine("Board Configuration:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i, j] > 0)
                {
                    Console.Write(" Q" + board[i, j] + " ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("Queen Positions:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i, j] > 0)
                {
                    Console.WriteLine("Queen Q" + board[i, j] + " is at position (" + (i + 1) + ", " + (j + 1) + ")");
                }
            }
        }
        Console.WriteLine();
    }
}
