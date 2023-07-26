using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_15
{
    internal class Program
    {

        static object o = new object();

        async static Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Программа выводит цифры '1, 2, 3' в трёх разных соответствующих потоках. Первый поток выводит красную '1', второй - зелёную '2', третий - жёлтую '3'.\n");
            Console.Write("Нажмите любую клавишу для продолжения...\n");
            Console.ReadKey();
            PrintThread();
            Console.Write("Нажмите любую клавишу для продолжения...\n");
            Console.ReadKey();
            PrintTask();
            Console.Write("Нажмите любую клавишу для продолжения...\n");
            Console.ReadKey();
            await PrintAsync();
            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод с помощью async/await
        /// </summary>
        /// <returns></returns>
        static async Task PrintAsync()
        {
            Console_Color(0);
            Console.WriteLine("\nВывод с помощью async: начало...");
            Task task1 = Task.Factory.StartNew(Print1);
            Task task2 = Task.Factory.StartNew(Print2);
            Task task3 = Task.Factory.StartNew(Print3);
            await task1;
            await task2;
            await task3;
            Console_Color(0);
            Console.WriteLine("Вывод с помощью async: конец...\n");
        }

        /// <summary>
        /// Вывод с помощью класса Task
        /// </summary>
        static void PrintTask()
        {
            Console_Color(0);
            Console.WriteLine("\nВывод с помощью Task: начало...");
            Task t1 = new Task(Print1);
            Task t2 = new Task(Print2);
            Task t3 = new Task(Print3);
            t1.Start();
            t2.Start();
            t3.Start();
            Task.WaitAll(t1, t2, t3);
            t1.Dispose();
            t2.Dispose();
            t3.Dispose();
            Console_Color(0);
            Console.WriteLine("Вывод с помощью Task: конец...\n");
        }

        /// <summary>
        /// Вывод с помощью класса Thread
        /// </summary>
        static void PrintThread()
        {
            Console_Color(0);
            Console.WriteLine("\nВывод с помощью Thread: начало...");
            Thread thread1 = new Thread(Print1);
            Thread thread2 = new Thread(Print2);
            Thread thread3 = new Thread(Print3);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread3.Join();
            Console_Color(0);
            Console.WriteLine("Вывод с помощью Thread: конец...\n");
        }

        /// <summary>
        /// Для делегатов. Не знаю, можно ли обойтись без этого?
        /// </summary>
        static void Print1() { Print(1); }
        static void Print2() { Print(2); }
        static void Print3() { Print(3); }

        /// <summary>
        /// Печатает заданную цифру от 1 до 3 соответствующим цветом
        /// </summary>
        /// <param name="i">Цифра от 1 до 3</param>
        static void Print(int i)
        {
            lock (o)
            {
                Console_Color(i);
                Console.WriteLine($"Print {i} запущен в потоке {Thread.CurrentThread.ManagedThreadId}...");
            }
            for (int j = 0; j < 100; j++)
            {
                lock (o)
                {
                    Console_Color(i);
                    Console.Write(i);
                }
                Thread.Sleep(10 * i);
            }
            lock (o)
            {
                Console_Color(i);
                Console.WriteLine($"\nPrint {i} завершён в потоке {Thread.CurrentThread.ManagedThreadId}...");
            }
        }

        /// <summary>
        /// Задаёт цвет текста консоли
        /// </summary>
        /// <param name="i">0 - серый, 1 - красный, 2 - зелёный, 3 - синий</param>
        static void Console_Color(int i)
        {
            switch (i)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }

    }
}

