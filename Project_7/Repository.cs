using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Project_7;

namespace Project_7
{
    internal class Repository
    {
        public Worker[] workers;
        private string path;
        uint index;
        string[] titles;

        
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[5];
            this.workers = new Worker[2];
        }

        
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length + 1);
            }
        }

        
        public void CreateFile()
        {
            using StreamWriter sw = new StreamWriter($@"{this.path}.txt");
        }

        
        public Worker[] GetAllWorkers()
        {
            Worker[] workers = new Worker[this.workers.Length];
            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                Console.WriteLine($"{"Id",5}{"Дата и время",20}{"Ф.И.О",15} {"Возраст",15} {"Рост",15} {"Дата Рождения",15} {"Место",20}");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length - 1; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        Console.WriteLine($"{workers[i].Id,5}{workers[i].RecordDate,20} {workers[i].FullName,14} {workers[i].Age,15} {workers[i].Height,15} {workers[i].BirthDate,15} {workers[i].BirthPlace,20}");
                        
                    }
                }
            }
            return workers;
        }

        
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = new Worker[this.workers.Length];

            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length - 1; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        if (workers[i].Id == id)
                        {
                            index = i;
                            Console.WriteLine($"{workers[i].Id,5}{workers[i].RecordDate,20} {workers[i].FullName,14} {workers[i].Age,15} {workers[i].Height,15} {workers[i].BirthDate,15} {workers[i].BirthPlace,20}");
                        }
                    }
                }
            }
            return workers[index];
        }

        
        public void DeleteWorker(int id)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                int Countup = 1;
                while (!sr.EndOfStream)
                {
                    if (Countup != id)
                    {
                        using (StringWriter sw = new StringWriter(sb))
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    else
                    {
                        sr.ReadLine();
                    }
                    Countup++;
                }
            }
            using (StreamWriter sw = new StreamWriter($@"{this.path}.txt"))
            {
                sw.Write(sb.ToString());
            }

        }

        
        

        public void AddWorker(Worker worker)
        {
            int id = 1;
            if (!File.Exists($@"{this.path}.txt"))
            {
                File.Create($@"{this.path}.txt").Close();
                Console.WriteLine("Файл успешно создан ✓");
            }
            else  
            {
                id = File.ReadAllLines($@"{this.path}.txt").Length + 1;
                
            }

            this.Resize(index >= this.workers.Length);
            this.workers[index] = worker;
            worker.Id = Convert.ToUInt32(id);
            worker.RecordDate = DateTime.Now;
            Console.Write("Введите Ф.И.О: ");
            worker.FullName = Console.ReadLine();
            Console.Write("Введите возраст: ");
            worker.Age = uint.Parse(Console.ReadLine());
            Console.Write("Введите дату рождения(dd.MM.yyyy): ");
            worker.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите рост: ");
            worker.Height = uint.Parse(Console.ReadLine());
            Console.Write("Введите место рождения: ");
            worker.BirthPlace = Console.ReadLine();

            string record = $"{worker.Id}#{worker.RecordDate}#{worker.FullName}#{worker.Age}#" +
                               $"{worker.BirthDate.ToString("dd.MM.yyyy")}" +
                               $"#{worker.Height}#{worker.BirthPlace}";

            StreamWriter sw = new StreamWriter($@"{this.path}.txt", true);
            using (sw)
            {
                sw.WriteLine(record);
            }

            this.index++;
        }

        
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = new Worker[this.workers.Length];

            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 0; i < workers.Length - 1; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];

                        if (workers[i].RecordDate >= dateFrom && workers[i].RecordDate <= dateTo)
                        {
                            
                            Console.WriteLine($"{workers[i].Id,5}{workers[i].RecordDate,20} {workers[i].FullName,14} {workers[i].Age,15} {workers[i].Height,15} {workers[i].BirthDate,15} {workers[i].BirthPlace,20}");
                        }
                    }
                }
                return workers;
            }
        }

        
        public void SplitRecord()
        {
            Worker[] workers = new Worker[this.workers.Length];

            using (StreamReader sr = new StreamReader($@"{this.path}.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split('#');
                    for (int i = 1; i < workers.Length - 1; i++)
                    {
                        workers[i].Id = uint.Parse(record[0]);
                        workers[i].RecordDate = DateTime.Parse(record[1]);
                        workers[i].FullName = record[2];
                        workers[i].Age = uint.Parse(record[3]);
                        workers[i].BirthDate = DateTime.Parse(record[4]);
                        workers[i].Height = uint.Parse(record[5]);
                        workers[i].BirthPlace = record[6];
                    }
                }
            }
        }
    }
}