using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_11.models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Получение данных клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        public ObservableCollection<Client> GetClients();
        /// <summary>
        /// Изменение данных клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        /// <param name="field">Изменяемое свойство</param>
        /// <param name="value">Новое значение</param>
        /// <param name="_clients">Список клиентов</param>
        /// <returns>Результат выполнения true - если успешно</returns>
        public bool UpdateClient(Client client, string field, object value, ObservableCollection<Client> _clients);
        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="client">Удаляемый клиент</param>
        public void RemoveClient(Client client);
        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="Pantronymic">Отчество</param>
        /// <param name="Phone">Телефон</param>
        /// <param name="Passport">Паспортные данные</param>
        public void AddClient(string Surname, string Name, string Pantronymic, string Phone, string Passport);
    }
}
