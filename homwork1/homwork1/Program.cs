using System;
using System.Diagnostics;
namespace homwork1
{
    class Program
    {
        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }
        public static void print(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write(i.ToString() + "  ");
            }
        }

        static public void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            while (left <= eol)
                temp[pos++] = numbers[left++];
            while (mid <= right)
                temp[pos++] = numbers[mid++];
            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void SortMerge(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(numbers, left, mid);
                SortMerge(numbers, (mid + 1), right);
                MainMerge(numbers, left, (mid + 1), right);
            }
        }
        static void Main(string[] args)
        {
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Random num = new Random();
            int[] arr = new int[30];
            int[] arr2 = new int[30];
            int flag = 1;
            while (flag == 1)
            {
                for (int i = 0; i < 10; i++)
                    arr[i] = num.Next(0, 100);
                arr2 = arr;
                Console.WriteLine("your array is:");
                print(arr);
                Console.WriteLine("\n*****************************");
                Console.WriteLine("\nsorted array with insertion is:");
                sw1.Start();
                print(InsertionSort(arr));
                sw1.Stop();
                Console.WriteLine("\n*****************************");
                Console.WriteLine("\nMergeSort By Recursive Method");
                sw2.Start();
                SortMerge(arr2, 0, 9);
                sw2.Stop();
                print(arr2);
                Console.WriteLine("\n*****************************");
                Console.WriteLine("insertion sort time is:" + sw1.Elapsed.TotalMilliseconds / 1000);
                Console.WriteLine("merge sort time is:" + sw2.Elapsed.TotalMilliseconds / 1000);
                Console.WriteLine("\n*****************************");
                Console.WriteLine("enter 1 to continue else enter 0");
                flag = int.Parse(Console.ReadLine());
            }
        }
    }
}
