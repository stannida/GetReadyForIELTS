using System;
using System.Collections.Generic;
using System.Globalization;
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
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader("../../../var1Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }
            Writing_Task_1_0.Source = Writing_Task_1_1.Source;
            Writing_Task_1_0.Visibility = Visibility.Visible;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            Writing_Task_1_0.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Hidden;
        }
        

        private async void UserText_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing_Task1_Var1.txt"))
            {
                await sw.WriteAsync(UserText.Text);
            }
            //if (UserText.Text != "")
            //{
                //string count = UserText.Text.Length.ToString();
                //counter.Text = "Number of words: " + count;
            //}
        }

        private void UserText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserText.Text == "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var1'. You can click on the button '1' to see the task again.")
                UserText.Text = "";
        }

        private void butTask2_Click(object sender, RoutedEventArgs e)
        {
            WritingTask2 WT2 = new WritingTask2();
            WT2.Show();
            this.Close();
            
        }

        private async void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader("../../../var2Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }

            Writing_Task_1_0.Source = Writing_Task_1_2.Source;
            Writing_Task_1_0.Visibility = Visibility.Visible;
            next.Click += Next_Click;

    }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            UserText.Visibility = Visibility.Visible;
            UserText.Text = "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var2'. You can click on the button '2' to see the task again.";
            UserText.GotFocus += UserText_GotFocus1;
            UserText.TextChanged += UserText_TextChanged1;
        }

        private async void UserText_TextChanged1(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing_Task1_Var2.txt"))
            {
                await sw.WriteAsync(UserText.Text);
            }
        }

        private void UserText_GotFocus1(object sender, RoutedEventArgs e)
        {
            if (UserText.Text == "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var2'. You can click on the button '2' to see the task again.")
                UserText.Text = "";
        }

        private async void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader("../../../var3Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }
            Writing_Task_1_0.Source = Writing_Task_1_3.Source;
            Writing_Task_1_0.Visibility = Visibility.Visible;
            next.Click += Next_Click1;
        }

        private void Next_Click1(object sender, RoutedEventArgs e)
        {
            UserText.Visibility = Visibility.Visible;
            UserText.Text = "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var3'. You can click on the button '3' to see the task again.";
            UserText.GotFocus += UserText_GotFocus2;
            UserText.TextChanged += UserText_TextChanged2;
        }

        private async void UserText_TextChanged2(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing_Task1_Var3.txt"))
            {
                await sw.WriteAsync(UserText.Text);
            }
        }

        private void UserText_GotFocus2(object sender, RoutedEventArgs e)
        {
            if (UserText.Text == "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var3'. You can click on the button '3' to see the task again.")
                UserText.Text = "";
        }
    }
}
