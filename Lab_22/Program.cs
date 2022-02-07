using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            
            Task<int[]> task1= new Task<int[]> 
        }
        static int[] GetArray(int n)
        {
            int[] array = new int [n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;            
        }

        static int[] SortArray (int[] array)
        {
            for (int i = 0; i < array.Count()-1; i++)
            {
                for (int j = i+1; j < array.Count(); j++)
                {
                    if (array[i] > array[j])
                    {
                        int t = array[i];
                        array[i] = array[j];
                        array[j] = t;
                    }
                }
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                Console.Write(array[i]);
            }
        }

    }

}
