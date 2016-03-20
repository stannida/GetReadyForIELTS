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
using GetReady.PartsOfExam;

namespace GetReady
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Close();
            MainWindow.Show();
        }

        private void writing_Click(object sender, RoutedEventArgs e)
        {
            Writing Writing = new Writing();
            Writing.Show();
            this.Close();
        }

        private void speaking_Click(object sender, RoutedEventArgs e)
        {
            Speaking Speaking = new Speaking();
            Speaking.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Close();
            Speaking.Show();
        }

        private void reading_Click(object sender, RoutedEventArgs e)
        {
            Reading reading = new Reading();
            reading.Show();
            this.Close();
        }

        private void listening_Click(object sender, RoutedEventArgs e)
        {
            Listening Listening = new Listening();
            Listening.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Close();
            Listening.Show();
        }
    }
}
