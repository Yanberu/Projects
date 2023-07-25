using Project_14.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Project_14
{
    /// <summary>
    /// Логика взаимодействия для pAddClient.xaml
    /// </summary>
    public partial class pAddClient : Page
    {
        private List<string> FullName = new List<string>()
        {
            "Березиков Иван Сергеевич",
            "Кротович Полина Ильинична",
            "Тушинский Андрей Данилович",
            "Гаврилова Дарья Ярославовна",
            "Никитина Мария Степановна",
            "Николаева Елена Артемьевна",
            "Семенов Семён Андреевич",
            "Архипова Стефания Ивановна",
            "Шкляр Артур Борисович",
            "Иванова Ольга Егоровна",
            "Папич Илья Степанович",
            "Калеников Михаил Демидович",
            "Иванов Иван Иванович",
            "Маковская Яна Мироновна",
            "Давыдов Дмитрий Сергеевич",
            "Олегин Олег Иванович",
            "Денисевич Максим Георгиевич",
            "Нажевская Анастасия Ярославовна",
            "Гриль Татьяна Георгиевна",
            "Дашкевич Евгений Тимофеевич",
        };

        public pAddClient()
        {
            InitializeComponent();
 
        }

        private void ButtonGeneration(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            TextBoxFullName.Text = FullName[random.Next(0, FullName.Count - 1)];
            TextBoxINN.Text = random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
            TextBoxPhone.Text = "7" + random.NextInt64(1_000_000_000, 9_999_999_999).ToString();
        }

        private void ButtonCreate(object sender, RoutedEventArgs e)
        {
            string FullName = TextBoxFullName.Text;
            string INN = TextBoxINN.Text;
            string Phone = TextBoxPhone.Text;

            try
            {
                if (String.IsNullOrEmpty(FullName) || String.IsNullOrEmpty(INN) || String.IsNullOrEmpty(Phone))
                {
                    throw new NotValidDataException();
                }
                else
                {
                    MainWindow.clients.Add(FullName, INN, Phone);
                    MainWindow.CurrentClientINN = INN;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Не все данные были внесены. \nЗаполните все поля!", ex.ToString());
            }
        }
    }
}
