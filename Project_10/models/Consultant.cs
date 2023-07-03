
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_10.models
{
    /// <summary>
    /// Консультант
    /// </summary>
    public class Consultant : Worker
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clients">Список клиентов</param>
        public Consultant(ref ObservableCollection<Client> clients) : base(ref clients)
        {
        }

        public override ObservableCollection<Client> GetClients()
        {
            Client.Get(ref clients);
            return Client.HidePassport(clients);
        }

        public override bool UpdateClient(Client client, string field, object value, ObservableCollection<Client> _clients)
        {
            if (new List<string>() { "Surname", "Name", "Patronymic", "Passport" }.IndexOf(field) == -1)
            {
                return Client.Update(ref clients, client, field, value, _clients, this);
            }
            else
            {
                MessageBox.Show("У вас недостаточно прав для изменения этого поля");
                return false;
            }
        }

        public override void RemoveClient(Client client)
        {
            MessageBox.Show("У вас недостаточно прав для удаления");
        }

        public override void AddClient(string Surname, string Name, string Pantronymic, string Phone, string Passport)
        {
            MessageBox.Show("У вас недостаточно прав для добавления");
        }
    }
}
