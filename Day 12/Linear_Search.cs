using System;
namespace Searching
{
    public class LinearSearch
    {
        static int linearSearch(int[] arr, int element)
        {
            for(int i =0; i < arr.Length; i++)
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
            int element = 40;
            Console.WriteLine("Enter the Element to Found: ");
            int target =int.Parse( Console.ReadLine());
            int index = linearSearch(arrInts, element);
            if (index != -1)
            {
                Console.WriteLine("Element 40 is Found at index : " +  index + " Using Linear Search ");
            }
            else
            {
                Console.WriteLine("Element Not Found.");
            }
        }
    }


}