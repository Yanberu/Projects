using System;
using System.IO;
using System.Text;

namespace Project_6

{
    class Program
    {

        const string PATH_TO_FILE = "Notebook.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Menu();
        }
        static void Menu()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                Console.WriteLine("Введите 1 - чтобы вывести данные на экран");
                Console.WriteLine("Введите 2 - чтобы заполнить данные и добавить новую запись в конце файла");
                Console.WriteLine("Введите 0 - чтобы завершить программу");
                consoleKeyInfo = Console.ReadKey();
                Console.WriteLine();

                switch (consoleKeyInfo.KeyChar)
                {
                    case '0':
                        break;
                    case '1':
                        DataPrint();
                        break;
                    case '2':
                        DataInput();
                        break;
                    default:
                        Console.WriteLine("Неизвестный пункт меню");
                        break;
                }
            }
            while (consoleKeyInfo.Key != ConsoleKey.D0);
        }
        
        static void DataPrint()
        {
            if (!File.Exists(PATH_TO_FILE))
            {
                Console.WriteLine("Файл не существует");
                return;
            }
            using (StreamReader list2 = new StreamReader(PATH_TO_FILE, Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"Id",5}{"Дата и время",20}{"Ф.И.О",15} {"Возраст",15} {"Рост",15} {"Дата Рождения",15} {"Место",20}");
                while ((line = list2.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],5}{data[1],20} {data[2],14} {data[3],15} {data[4],15} {data[5],15} {data[6],20}");
                }
            }
        }
        static void DataInput()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int id = 1;
            if (!File.Exists(PATH_TO_FILE))
            {
                File.Create(PATH_TO_FILE).Close();
                Console.WriteLine("Файл успешно создан");
            }
            else
            {
                id = File.ReadAllLines(PATH_TO_FILE).Length + 1;
            }
            Console.WriteLine($"Id {id}: Дата и время добавления записи: { DateTime.Now.ToString() }");
            stringBuilder.Append($"{id++}#");
            stringBuilder.Append($"{DateTime.Now.ToString()}#");
            Console.WriteLine("\nВведите Ф.И.О: ");
            stringBuilder.Append($"{ Console.ReadLine()}#");
            Console.WriteLine("Введите возраст: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите рост: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите дату рождения: ");
            stringBuilder.Append($"{Console.ReadLine()}#");
            Console.WriteLine("Введите место рождения: ");
            stringBuilder.Append($"{Console.ReadLine()}");
            using (StreamWriter list = new StreamWriter("Notebook.txt", true, Encoding.Unicode))
            {
                list.WriteLine(stringBuilder.ToString());
            }
        }
    }
}
