using System;
using System.Collections.Generic;
using System.Text;

namespace Project_8._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выберите действие:\n" +
                "1. Добавить запись\n" +
                "2. Найти запись\n" +
                "3. Закрыть программу");
                
            Console.Write("Номер операции: ");
            int operationNumber = int.Parse(Console.ReadLine());
            var phone = new Dictionary<int, string>();
            while (operationNumber != 3)
            {
                switch (operationNumber)
                {
                    case 1:
                        Create(phone);
                        Console.WriteLine("Запись добавлена ✓");
                        break;
                    case 2:
                        Find(phone);
                        
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
        }
        static Dictionary<int, string> Create(Dictionary<int, string> phone)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Введите телефонный номер:");
            string i = Console.ReadLine();
            while (i != "")
            {
                list.Add(Convert.ToInt32(i));
                i = Console.ReadLine();
            }
            Console.WriteLine("Введите владельца:");
            string name = Console.ReadLine();
            foreach (var e in list)
            {
                if (!phone.ContainsKey(e))
                {
                    phone.Add(e, name);
                }
            }
            return phone;
        }
        static void Find(Dictionary<int, string> phone)
        {
            Console.WriteLine("Введите телефонный номер для поиска:");
            int findPhone = Convert.ToInt32(Console.ReadLine());
            
            string value = "";
            
            if (phone.TryGetValue(findPhone, out value))
            {
                Console.WriteLine($"\n\nТелефонный номер [\"{findPhone}\"] принадлежит {value}");
            }
            else
            {
                Console.WriteLine("Запись не найдена");
            }
        }
    }
}
