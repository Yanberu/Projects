using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_17
{
    /// <summary>
    /// Логика взаимодействия для DetailsClient.xaml
    /// </summary>
    public partial class DetailsClient : Window
    {
        WorkDataDBEntities context;

        public DetailsClient()
        {
            InitializeComponent();
            context = new WorkDataDBEntities();
        }
        public DetailsClient(Clients clientnow) : this()
        {
            try
            {
                if (clientnow != null)
                {
                    string email = clientnow.Email;
                    context.Sales.Load();
                    var msd = context.Sales.Where(w => w.Email == email);
                    gridView.DataContext = new ObservableCollection<Sales>(msd);
                }
                else
                {
                    MessageBox.Show($"\nВыберите клиента для просмотра его заказов", "Ошибка!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\n {ex}", "Ошибка!");
            }
        }
    }
}
