﻿using Project_14.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для pReplenishBalance.xaml
    /// </summary>
    public partial class pReplenishBalance : Page
    {
        public pReplenishBalance()
        {
            InitializeComponent();
        }

        private void ButtonReplenish(object sender, RoutedEventArgs e)
        {
            decimal sum;
            try
            {
                if (decimal.TryParse(TextBoxSum.Text, out sum))
                {
                    MainWindow.clients.ReplenishBalance(decimal.Parse(TextBoxSum.Text));
                }
                else
                {
                    throw new NotValidDataException();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данные введены неверно! \nВведите число", ex.Message);
            }
        }
    }
}
