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
using static System.Net.Mime.MediaTypeNames;

namespace Project_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Input> db = new ObservableCollection<Input>();
        ObservableCollection<Input> db2 = new ObservableCollection<Input>();

        public MainWindow()
        {
            InitializeComponent();
            listDbBView.ItemsSource = db;
            InitializeComponent();
            listDbBView2.ItemsSource = db2;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = txtMsgSend1.Text;
            string[] textSplit = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < textSplit.Length; i++)
            {
                db.Add(new Input()
                {
                    Text = textSplit[i],

                });
            }
            

        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            string resultString = "";
            string text = txtMsgSend2.Text;
            string[] textSplit = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = textSplit.Length - 1; i >= 0; i--)
            {
                resultString += textSplit[i] + " ";
            }
            db2.Add(new Input()
            {
                Text = resultString,

            });
        }
    }
}
