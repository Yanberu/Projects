using Project_12.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Project_12
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

            if (String.IsNullOrEmpty(FullName) || String.IsNullOrEmpty(INN) || String.IsNullOrEmpty(Phone))
            {
                MessageBox.Show("Все поля должны быть заполнены!");
            }
            else
            {
                MainWindow.clients.Add(FullName, INN, Phone);
                MainWindow.CurrentClientINN = INN;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автоматически генерирует все поля клинта.\nВозможные варианты имён можно найти в файле ./pAddClient.xaml.cs", "Краткое руководство");
        }
    }
}
