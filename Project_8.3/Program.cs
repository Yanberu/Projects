using System;
using System.Collections.Generic;
using System.Text;

namespace Project_8._3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выберите действие:\n" +
                "1. Записать число\n" +
                "2. Посммотреть коллекцию\n" +
                "3. Закрыть программу");

            Console.Write("Номер операции: ");
            int operationNumber = int.Parse(Console.ReadLine());
            var phone = new Dictionary<int, string>();
            while (operationNumber != 3)
            {
                switch (operationNumber)
                {
                    case 1:
                        Console.WriteLine("Введите искомое число в коллекции:");
                        int h = Convert.ToInt32(Console.ReadLine());

                        if (set1.Contains(h) == true)
                        {
                            Console.WriteLine($"\n\nЭлемент '{h}' Присутствует в set1: {set1.Contains(h)}");
                        }
                        else
                        {
                            Console.WriteLine("Такого числа в коллекции нет");
                            set1.Add(h);
                            Console.WriteLine("Число добавлено в коллекцию ✓");
                        }

                        break;
                    case 2:
                        Print(set1);
                        break;
                    default:
                        if (operationNumber > 3)
                        {
                            Console.WriteLine("Неверная операция. Повторите попытку...");
                        }
                        break;
                }

                Console.Write("Номер операции: ");
                operationNumber = int.Parse(Console.ReadLine());
            }

            static void Print(HashSet<int> set1)
            {
                Console.WriteLine("hashset: ");
                foreach (var e in set1) { Console.Write($"{e} "); }
                Console.WriteLine("\n");

            }
        }
    }
}
