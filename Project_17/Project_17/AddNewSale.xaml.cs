using System;
using System.Collections.Generic;
using System.Data;
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

namespace Project_17
{
    /// <summary>
    /// Логика взаимодействия для AddNewSale.xaml
    /// </summary>
    public partial class AddNewSale : Window
    {
        public AddNewSale()
        {
            InitializeComponent();
        }
        public AddNewSale(Sales new_product) : this()
        {
            //события после нажатия кнопки
            addSale.Click += delegate
            {
                //проверка на заполненность 
                if (NameProduct.Text == string.Empty ||
                CodeProduct.Text == string.Empty || Email.Text == string.Empty 
                )
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                new_product.description_product = NameProduct.Text;
                new_product.code_product = Convert.ToInt32(CodeProduct.Text);
                new_product.Email = Email.Text;
                this.DialogResult = true;
            };
        }
   
    }
}
