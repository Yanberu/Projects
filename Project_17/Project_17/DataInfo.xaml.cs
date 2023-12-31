﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для DataInfo.xaml
    /// </summary>
    public partial class DataInfo : Window

    {
        ClientsEntities context;
        WorkDataDBEntities context2;
        Clients row;

        public DataInfo()
        {
            InitializeComponent();
            context = new ClientsEntities();
            context2 = new WorkDataDBEntities();
            MessageBox.Show($"Приветствуем, {Environment.UserName} ✓");            
            FirstCommand();
        }


        /// <summary>
        ///  Метод вывода первичной таблицы на экран
        /// </summary>
        public void FirstCommand()
        {                                  
            try
            {
                //выгрузка всей таблицы и вывод на основной грид
                context.Clients.Load();
                gridView.DataContext = context.Clients.Local.ToBindingList<Clients>();
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Начало редактирования (получение строки до редактирвания)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            row = (Clients)gridView.SelectedItem;            
        }



        /// <summary>
        /// обработчик ПКМ - добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {

            //DataRow r = new DataRow();
            Clients new_client = new Clients();
            AddNewClient add = new AddNewClient(new_client);
            add.ShowDialog();
            if (add.DialogResult.Value)
            {
                context.Clients.Add(new_client); //добавление в таблицу на экране новой строки
                context.SaveChanges();
                gridView.Items.Refresh();
            }
        }
        private void MenuItemAddSaleClick(object sender, RoutedEventArgs e)
        {

            //DataRow r = new DataRow();
            Sales new_product = new Sales();
            AddNewSale addSale = new AddNewSale(new_product);
            addSale.ShowDialog();
            if (addSale.DialogResult.Value)
            {
                context2.Sales.Add(new_product); //добавление в таблицу на экране новой строки
                context2.SaveChanges();
                gridView.Items.Refresh();
            }
        }

        /// <summary>
        /// Обработчик ПКМ - удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            row = (Clients)gridView.SelectedItem; //выбранный клиент в данный момент (по которой был ПКМ)
            try
            {
                context.Clients.Remove(row);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"\nВыберите клиента для удаления", "Ошибка!");
            }
            
            
        }

        /// <summary>
        /// Обработчик пкм - Посмотреть покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemShowSalesClick(object sender, RoutedEventArgs e)
        {
            row = (Clients)gridView.SelectedItem; //выбранный клиент в данный момент (по которой был ПКМ)
            DetailsClient details = new DetailsClient(row);
            details.Owner = this;
            details.ShowDialog();
            
        }

        /// <summary>
        /// Редактирование записи (строка уже с внесёнными изменениями)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            try
            {
                
                context.SaveChanges();
                row = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                throw;
            }
            



            
            //row.EndEdit();
            //da_acc.Update(lt_TableData);
        }
    }
}
