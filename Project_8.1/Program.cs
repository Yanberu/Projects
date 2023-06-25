using System;
using System.Collections.Generic;
using System.Text;

namespace Project_8._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<int> list = Create();

            Print(list);
            int from;
            int to;
            Console.WriteLine("Введите больше какого числа удалять элемент\n");
            from = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите меньше какого числа удалять элемент\n");
            to = Convert.ToInt32(Console.ReadLine());
            DeleteFromTo(list, from, to);
            Console.WriteLine("\n");

            Print(list);

        }
        static void Print(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine("\n");
        }

        static void DeleteFromTo(List<int> list, int from, int to)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i] > from) && (list[i] < to))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
        static List<int> Create()
        {
            List<int> list = new List<int>();

            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(r.Next(0, 100));
            }
            return list;
        }
    }
}
