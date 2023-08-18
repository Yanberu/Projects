using Project_19.Interfaces;
using Project_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_19.Mocks
{
    public class MockPersonCollection : IPersonCollection
    {
        public IEnumerable<Person> Persons
        {
            get
            {
                return new List<Person>
                {
                    new Person{ID = 0, FirstName = "Иван", LastName = "Березиков", Age = 20, Mail = "ivan.biarezikau@gmail.com", Telephone = "+375291942946", Adress ="222167, Минская область, город Жодино, ул. Гагарина, 43", Description = "(Очень интересное описание)", ImgPhoto = "", Male = true},
                    new Person{ID = 1, FirstName = "Евгений", LastName = "Тушинский", Age = 18, Mail = "evgeniy123@gmail.com", Telephone = "+375291947832", Adress ="222167, Минская область, город Жодино, ул. Цветочная, 50", Description = "(Очень интересное описание)", ImgPhoto = "", Male = true},
                    new Person{ID = 2, FirstName = "Максим", LastName = "Кротович", Age = 21, Mail = "vonuchiy23@gmail.com", Telephone = "+375297896532", Adress ="222167, Минская область, город Жодино, ул. Гагарина, 26", Description = "(Очень интересное описание)", ImgPhoto = "", Male = true},
                    new Person{ID = 3, FirstName = "Алина", LastName = "Петрова", Age = 32, Mail = "alina2586@gmail.com", Telephone = "+375453697812", Adress ="222865, Минская область, город Минск, пр. Держинского, 78", Description = "(Очень интересное описание)", ImgPhoto = "", Male = false},
                    new Person{ID = 4, FirstName = "Константин", LastName = "Пшенко", Age = 50, Mail = "marine.harihson@gmail.com", Telephone = "+375987417913", Adress ="227615, Минская область, город Минск, ул. Гикало, 13", Description = "(Очень интересное описание)", ImgPhoto = "", Male = true}
                };
            }
        }
    }
}
