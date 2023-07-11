using System.Windows;
using System.Windows.Controls;

namespace Project_11
{
    /// <summary>
    /// Логика взаимодействия для InitialWindow.xaml
    /// </summary>
    public partial class InitialWindow : Page
    {
        public static int ComboBoxIndex;
        public InitialWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxIndex = comboBox.SelectedIndex;

            //Uri uri = new Uri("MainPage.xaml", UriKind.Relative);
            //frame.NavigationService.Navigate(uri);
        }
    }
}
