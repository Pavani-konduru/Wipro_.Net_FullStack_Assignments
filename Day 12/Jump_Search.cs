using System;
namespace Searching
{
    public class Jump_Search
    {
        static int JumpSearch(int[] arr, int element)
        {
            int n = arr.Length; 
            int step = (int)Math.Sqrt(n);
            int prev = 0;

            while (arr[Math.Min(step,n)-1]< element)
            {
                prev = step;
                step += (int)Math.Sqrt(n);
                if (prev >= n)
                    return -1;
            }
            for(int i = prev; i<Math.Min(step,n); i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void Main(string[] args)
        {
            int[] arrInts = { 5, 8, 4, 3, 0, 1, 17, 6, 10, 50, 40, 60, 20 };
            
            Console.WriteLine("Enter the Element to Found: ");
            int target = int.Parse(Console.ReadLine());

            int index = JumpSearch(arrInts, target);

            if(index != -1)
            {
                Console.WriteLine("Element 40 found at index : " + index + " using Jump Search " );
            }
            else
            {
                Console.WriteLine("Element Not Found.");
            }
           

        }
    }
}

