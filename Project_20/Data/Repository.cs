using LoremNET;
using Project_20.Models;
using System;
using System.Collections.Generic;

namespace Project_20.Data
{
    public static class Repository
    {

        /// <summary>
        /// Возвращает контакт с сгенерированными данными
        /// </summary>
        /// <returns>Заполненный экземпляр класса Contact</returns>
        public static Contact GetContact()
        {
            Random random = new Random();
            return new Contact()
            {
                FirstName = GetRandomFirstName(random),
                LastName = GetRandomLastName(random),
                FatherName = GetRandomFatherName(random),
                Telephone = $"+375{random.Next(900000000, 999999999)}",
                Adress = $"{random.Next(222160, 222180)}, г.Барановичи, ул.Гагарина, д.{random.Next(100)}, кв.{random.Next(100)}.",
                Mail = $"{Lorem.Words(1, false)}.{Lorem.Words(1, false)}@gmail.com",
                Description = "(Напишите описание)"
            };
        }
        public static IEnumerable<Contact> GetContacts()
        {
            Random random = new();
            List<Contact> contacts = new();
            for (int i = 0; i < random.Next(3, 11); i++)
            {
                contacts.Add(GetContact());
            }
            return contacts;
        }
        private static string GetRandomLastName(Random random)
        {
            switch (random.Next(1, 5))
            {
                case 1: return "Иванов";
                case 2: return "Петров";
                case 3: return "Кукин";
                case 4: return "Селезнёв";
                default: return "Дашкевич";
            }
        }
        private static string GetRandomFatherName(Random random)
        {
            switch (random.Next(1, 5))
            {
                case 1: return "Иванович";
                case 2: return "Петрович";
                case 3: return "Максимович";
                case 4: return "Игоревич";
                default: return "Денисович";
            }
        }
        private static string GetRandomFirstName(Random random)
        {
            switch (random.Next(1, 5))
            {
                case 1: return "Иван";
                case 2: return "Пётр";
                case 3: return "Игорь";
                case 4: return "Дмитрий";
                default: return "Олег";
            }
        }
    }
}
