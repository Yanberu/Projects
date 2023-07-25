using Project_14.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_14
{
    /// <summary>
    /// Логика взаимодействия для pAddAccount.xaml
    /// </summary>
    public partial class pAddAccount : Page
    {
        public pAddAccount()
        {
            InitializeComponent();
        }

        private void ButtonGeneration(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int cm = random.Next(0, 2);
            ComboBoxType.SelectedIndex = cm;
            string acc;
            if (cm == 0)
            {
                acc = "40817810";
            }
            else
            {
                acc = "45508810";
            }
            TextBoxNumber.Text = acc + random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxType.Text != "" && TextBoxNumber.Text != "")
                {
                    Account account;
                    if (ComboBoxType.SelectedIndex == 0)
                    {
                        account = new NonDeposit(TextBoxNumber.Text, 0);
                    }
                    else
                    {
                        account = new Deposit(TextBoxNumber.Text, 0);
                    }
                    MainWindow.clients.AddAccount(MainWindow.CurrentClientINN, account);
                }
                else
                {
                    throw new NotValidDataException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не все данные были внесены. \nЗаполните все поля!", ex.ToString());
            }
            
        }
    }
}
