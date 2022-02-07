using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab22_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива - ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(0, 100);
            }
            Task task1 = new Task(() => Sum(array));
            Action<Task, object> actionTask = new Action<Task, object>(Max);
            Task task2 = task1.ContinueWith(actionTask, array);
            task1.Start();
            task2.Wait();
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }

        static void Sum(int[] massiv)
        {
            int sum = 0;
            foreach (int s in massiv)
            {
                sum += s;
            }
            Console.WriteLine("Сумма всех числе массива = {0}", sum);
        }

        static void Max(Task task, object m)
        {
            int[] massiv = (int[])m;
            int max = 0;
            foreach (int s in massiv)
            {
                if (max < s)
                {
                    max = s;
                }
            }
            Console.WriteLine("Максимальое число в массиве = {0}", max);
        }
    }
}