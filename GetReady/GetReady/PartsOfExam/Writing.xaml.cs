using System;
using System.Collections.Generic;
using System.IO;
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

namespace GetReady.PartsOfExam
{
    /// <summary>
    /// Логика взаимодействия для Writing.xaml
    /// </summary>
    public partial class Writing : Window
    {
        public Writing()
        {
            InitializeComponent();
            
            LoadingTask();

        }

        private async void LoadingTask ()
        {
            using (StreamReader sr = new StreamReader("../../../taskWriting.txt"))
            {

                string line = await sr.ReadToEndAsync();
                _task.Text = line;

            }
        }

        private async void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            using (StreamReader sr = new StreamReader("../../../var1Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }
            Writing_Task_1_1.Visibility = Visibility.Visible;
        }

        
    }
}
