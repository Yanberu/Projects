using Project_11.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Project_11.models
{
    /// <summary>
    /// Родительский класс сотрудников
    /// </summary>
    public class Worker : IWorker
    {
        /// <summary>
        /// Список клиентов
        /// </summary>
        protected ObservableCollection<Client> clients;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clients">Список клиентов</param>
        public Worker(ref ObservableCollection<Client> clients) 
        {
            this.clients = clients;
        }

        public virtual ObservableCollection<Client> GetClients()
        {
            Client.Get(ref clients);
            return clients;
        }

        public virtual bool UpdateClient(Client client, string field, object value, ObservableCollection<Client> _clients)
        {
            return Client.Update(ref clients, client, field, value, _clients, this);
        }

        public virtual void RemoveClient(Client client)
        {
            Client.Remove(ref clients, client);
            MessageBox.Show($"Клиент {client.Name} {client.Surname} удалён успешно");
        }

        public virtual void AddClient(string Surname, string Name, string Pantronymic, string Phone, string Passport)
        {
            if (!string.IsNullOrEmpty(Phone))
            {
                Client.Add(ref clients, new Client(Surname, Name, Pantronymic, Phone, Passport), this);
            }
            else
            {
                MessageBox.Show("Номер телефона является обязательным полем");
            }
        }

        /// <summary>
        /// Сортировка клиентов
        /// </summary>
        public virtual void SortClinets()
        {
            Client.Sort(ref clients);
        }
    }
}
