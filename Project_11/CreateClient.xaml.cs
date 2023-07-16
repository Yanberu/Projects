using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_11
{
    /// <summary>
    /// Логика взаимодействия для CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        public CreateClient()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxSurname.Text) &&
                !string.IsNullOrEmpty(TextBoxName.Text) &&
                !string.IsNullOrEmpty(TextBoxPatronymic.Text) &&
                !string.IsNullOrEmpty(TextBoxPhone.Text) &&
                !string.IsNullOrEmpty(TextBoxPassport.Text) &&
                !string.IsNullOrEmpty(TextBoxDepartment.Text))
            {
                MainPage.worker.AddClient
                (
                    TextBoxSurname.Text,
                    TextBoxName.Text,
                    TextBoxPatronymic.Text,
                    TextBoxPhone.Text,
                    TextBoxPassport.Text,
                    TextBoxDepartment.Text
                );
                this.Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
        }
    }
}
