using Project_18;
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

namespace Project_18_Patterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presenter presenter = new Presenter();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = presenter;
            AnimalList.ItemsSource = presenter.Repository.Animals;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                presenter.RepositoryControl.AddAnimal(InputType.Text, InputName.Text, Convert.ToInt32(InputAge.Text), Convert.ToBoolean(InputState.IsChecked));
                InputType.Text = string.Empty;
                InputName.Text = string.Empty;
                InputAge.Text = string.Empty;
                InputState.IsChecked = false;
            }
            catch 
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
            }
        }

        
        private void SaveToTxt_Click(object sender, RoutedEventArgs e)
        {
            presenter.UpdateTxt();
        }

        private void SaveToJson_Click(object sender, RoutedEventArgs e)
        {
            presenter.UpdateJson();
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            presenter.RepositoryControl.DeleteAnimal((IAnimalEntity)AnimalList.SelectedItem);
        }

        private void AnimalList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Белорусский заповедник \n\nВозможные семейства животных:" +
                "\nМлекопитающее ✓" +
                "\nЗемноводное ✓" +
                "\nПтица ✓ \n\nЕсли название семейства введено неверно или такое семейство отсутствует, то программа возвращает null семейство", "Краткое руководство");
        }
    }
}
