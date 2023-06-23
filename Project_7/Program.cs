using Project_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Введите путь: ");
            string path = Console.ReadLine();

            Repository repository = new Repository(path);

            Console.WriteLine("Выберите действие:\n" +
                "1. Создать файл\n" +
                "2. Добавить запись\n" +
                "3. Удалить запись\n" +
                "4. Просмотреть все записи\n" +
                "5. Получить одну запись по Id\n" +
                "6. Отфильтровать записи по двум датам\n" +
                "7. Выйти из программы");

            Console.Write("Номер операции: ");
            int operationNumber = int.Parse(Console.ReadLine());

            while (operationNumber != 7)
            {
                switch (operationNumber)
                {
                    case 1:
                        repository.CreateFile();
                        Console.WriteLine("Файл успешно создан ✓");
                        break;
                    case 2:
                        Worker worker = new Worker();
                        repository.AddWorker(worker);
                        Console.WriteLine("Запись добавлена ✓");
                        break;
                    case 3:
                        Console.Write("Введите id сотрудника: ");
                        repository.DeleteWorker(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Запись успешно удалена ✓");
                        break;
                    case 4:
                        repository.GetAllWorkers();
                        break;
                    case 5:
                        Console.Write("Введите id сотрудника для поиска: ");
                        repository.GetWorkerById(int.Parse(Console.ReadLine()));
                        break;
                    case 6:
                        Console.Write("От какой даты фильтровать: ");
                        DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("До какой даты фильтровать: ");
                        DateTime dateTo = Convert.ToDateTime(Console.ReadLine());
                        repository.GetWorkersBetweenTwoDates(dateFrom, dateTo);
                        break;
                    
                    default:
                        if (operationNumber > 7)
                        {
                            Console.WriteLine("Неверная операция. Повторите попытку...");
                        }
                        break;
                }

                Console.Write("Номер операции: ");
                operationNumber = int.Parse(Console.ReadLine());

            }

        }
    }
}