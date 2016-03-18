﻿using System;
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
using System.Windows.Navigation;
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
            using (StreamReader sr = new StreamReader("../../../Writing/taskWriting.txt"))
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
            using (StreamReader sr = new StreamReader("../../../Writing/var1Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }
            Writing_Task_1_0.Source = Writing_Task_1_1.Source;
            Writing_Task_1_0.Visibility = Visibility.Visible;
            Help.MouseLeave += Help_MouseLeave;
            next.Click += next_Click;
            UserText.TextChanged -= UserText_TextChanged1;
            UserText.TextChanged -= UserText_TextChanged2;
            UserText.TextChanged += UserText_TextChanged;
        }



        private void next_Click(object sender, RoutedEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            Writing_Task_1_0.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Hidden;
            Help.MouseLeave += Help_MouseLeave1;
        }

        private void Help_MouseLeave1(object sender, MouseEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            Writing_Task_1_0.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
        }

        private async void UserText_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing/Writing_Task1_Var1.txt"))
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
            if (UserText.Text == "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var#'. You can click on the variant button to see the task again.")
                UserText.Text = "";
        }

        private void butTask2_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private async void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader("../../../Writing/var2Task1.txt"))
            {
                string line = await sr.ReadToEndAsync();
                var1Task.Text = line;
            }

            Writing_Task_1_0.Source = Writing_Task_1_2.Source;
            Writing_Task_1_0.Visibility = Visibility.Visible;
            next.Click += Next_Click;
            UserText.TextChanged -= UserText_TextChanged;
            UserText.TextChanged -= UserText_TextChanged;
            UserText.TextChanged += UserText_TextChanged1;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            
            Help.MouseLeave += Help_MouseLeave1;
        }

        private async void UserText_TextChanged1(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing/Writing_Task1_Var2.txt"))
            {
                await sw.WriteAsync(UserText.Text);
            }
        }


        private async void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            using (StreamReader sr = new StreamReader("../../../Writing/var3Task1.txt"))
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
            _task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            UserText.TextChanged -= UserText_TextChanged;
            UserText.TextChanged -= UserText_TextChanged1;
            UserText.TextChanged += UserText_TextChanged2;
            Help.MouseLeave += Help_MouseLeave1;
        }

        private async void UserText_TextChanged2(object sender, TextChangedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("../../../Writing/Writing_Task1_Var3.txt"))
            {
                await sw.WriteAsync(UserText.Text);
            }
        }


        
        //СОНЯ ЭТО НЕ РАБОТАЕТ
        private void UserText_DragLeave(object sender, DragEventArgs e)
        {
            if (UserText.Text == "")
                UserText.Text = "Here you can write your graph description. The file will be automatically created on your computer and named 'Writing_Task1_Var#'. You can click on the variant button to see the task again.";
        
    }



        private void Help_MouseEnter(object sender, MouseEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Hidden;
            Writing_Task_1_0.Visibility = Visibility.Hidden;
            _task.Visibility = Visibility.Visible;
        }
        private void Help_MouseLeave(object sender, MouseEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            Writing_Task_1_0.Visibility = Visibility.Visible;
            var1Task.Visibility = Visibility.Visible;
        }


        private void GoTask2_Click(object sender, RoutedEventArgs e)
        {
            WritingTask2 WritingTask2 = new WritingTask2();
            WritingTask2.Show();
            this.Close();
        }
    }
}
