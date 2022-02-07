using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab22._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Func<object, int[]> func1 = new Func<object, int[]>(GetArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);
            task1.Start();

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(Summ);
            Task<int> task2 = task1.ContinueWith<int>(func2);

            Func<Task<int[]>, int> func3 = new Func<Task<int[]>, int>(Max);
            Task<int> task3 = task1.ContinueWith<int>(func3);

            Console.WriteLine("");
            Console.WriteLine(task2.Result);
            Console.WriteLine("");
            Console.WriteLine(task3.Result);
            Console.WriteLine("");

            Action<Task<int[]>> action = new Action<Task<int[]>>(PrintArray);
            Task task4 = task1.ContinueWith(action);

            Console.ReadKey();
        }
        static int[] GetArray(object a)
        {
            int n = (int)a;
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 1; i < n; i++)
            {
                array[i] = random.Next(0, 100);
            }
            return array;
        }
        static int Summ(Task<int[]> task)
        {
            int[] array = task.Result;
            int Summ = 0;
            for (int i = 0; i < array.Length; i++)
            {
                Summ += array[i];
            }
            return Summ;
        }
        static int Max(Task<int[]> task)
        {
            int[] array = task.Result;
            int Maximum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > Maximum)
                {
                    Maximum = array[i];
                }
            }
            return Maximum;
        }
        static void PrintArray(Task<int[]> task)
        {
            int[] array = task.Result;
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{array[i] }");
            }
        }
    }
}