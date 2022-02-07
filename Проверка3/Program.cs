using System;
using System.Threading.Tasks;
using System.IO;

namespace Lab22
{
    class Program
    {
        static int[] arrInt;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива:");
            int len = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            arrInt = new int[len];
            Random rnd = new Random();

            for (int i = 0; i < len; i++)
            {
                arrInt[i] = rnd.Next(-100, 100);
                Console.Write(string.Format("{0,4}", arrInt[i]));
            }

            Console.WriteLine();

            Action delMaxValue = new Action(MaxValue);
            Task taskMaxValue = new Task(delMaxValue);

            Action<Task> delSum = new Action<Task>(SumElem);
            Task taskSum = taskMaxValue.ContinueWith(delSum);

            taskMaxValue.Start();

            Console.ReadKey();


        }

        public static void MaxValue()
        {
            int maxValue = 0;
            if (arrInt != null)
            {
                maxValue = arrInt[0];
                foreach (int val in arrInt)
                {
                    if (val > maxValue)
                    {
                        maxValue = val;
                    }
                }
                Console.WriteLine("Максимальный элемент {0}", maxValue);
            }
            else
            {
                Console.WriteLine("Массив пуст");
            }

        }
        public static void SumElem(Task task)
        {
            int sum = 0;
            if (arrInt != null)
            {
                foreach (int val in arrInt)
                {
                    sum += val;
                }
                Console.WriteLine("Сумма элементов {0}", sum);
            }
            else
            {
                Console.WriteLine("Массив пуст");
            }

        }
    }


}