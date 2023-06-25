using System;
using System.Text;
using System.Xml.Linq;

namespace Project_8._4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выберите действие:\n" +
                "1. Ввести данные\n" +
                "2. Закрыть программу");

            Console.Write("Номер операции: ");
            int operationNumber = int.Parse(Console.ReadLine());
            
            while (operationNumber != 2)
            {
                switch (operationNumber)
                {
                    case 1:
                        Console.WriteLine("Введите ФИО:");
                        string fio = Console.ReadLine();
                        Console.WriteLine("Введите название улицы:");
                        string street = Console.ReadLine();
                        Console.WriteLine("Введите номер дома:");
                        string streetNumber = Console.ReadLine();
                        Console.WriteLine("Введите номер квартиры:");
                        string flatNumber = Console.ReadLine();
                        Console.WriteLine("Введите мобильный телефон:");
                        string mobilePhone = Console.ReadLine();
                        Console.WriteLine("Введите домашний телефон:");
                        string flatPhone = Console.ReadLine();


                        XElement PERSON = new XElement("Person");
                        XElement ADDRESS = new XElement("Address");
                        XElement STREET = new XElement("Street");
                        XElement HOUSENUMBER = new XElement("HouseNumber");
                        XElement FLATNUMBER = new XElement("FlatNumber");
                        XElement PHONES = new XElement("Phones");
                        XElement MOBILEPHONE = new XElement("MobilePhone");
                        XElement FLATPHONE = new XElement("FlatPhone");

                        

                        STREET.Add(street);
                        HOUSENUMBER.Add(streetNumber);
                        FLATNUMBER.Add(flatNumber);
                        ADDRESS.Add(STREET);
                        ADDRESS.Add(HOUSENUMBER);
                        ADDRESS.Add(FLATNUMBER);

                        

                        MOBILEPHONE.Add(mobilePhone);
                        FLATPHONE.Add(flatPhone);
                        PHONES.Add(MOBILEPHONE);
                        PHONES.Add(FLATPHONE);

                        XAttribute xAttributeName = new XAttribute("name", fio);




                        PERSON.Add(ADDRESS, xAttributeName);
                        PERSON.Add(PHONES);

                        PERSON.Save("Person.xml");
                        break;

                    case 2:
                        if (operationNumber == 2)
                        {
                            Console.WriteLine("Выход.");
                        }
                        break;

                    default:
                        if (operationNumber > 2)
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
