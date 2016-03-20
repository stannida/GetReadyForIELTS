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
    /// Логика взаимодействия для WritingTask2.xaml
    /// </summary>
    public partial class WritingTask2 : Window
    {
        public WritingTask2()
        {
            InitializeComponent();
            UserText.Visibility = Visibility.Hidden;
            counter.Visibility = Visibility.Hidden;
            _task.Visibility = Visibility.Visible;
            GettingData();
        }
        private async void GettingData()
        {
            var1Task.Visibility = Visibility.Visible;
            try
            {
                using (StreamReader sr = new StreamReader("../../../Writing/taskWriting2.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    _task.Text = line;
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File with writing rask not found");
            }

        }

        private async void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            try
            {
                using (StreamReader sr = new StreamReader("../../../Writing/var1Task2.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    var1Task.Text = line;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File with writing rask not found");
            }
            Help.MouseLeave += Help_MouseLeave;
            next.Click += next_Click;
            UserText.TextChanged -= UserText_TextChanged1;
            UserText.TextChanged -= UserText_TextChanged2;
            UserText.TextChanged += UserText_TextChanged;
            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;
        }

        private void Help_MouseLeave(object sender, MouseEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Hidden;
        }

        private async void UserText_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("../../../Writing/Writing_Task2_Var1.txt"))
                {
                    await sw.WriteAsync(UserText.Text);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File with writing rask not found");
            }
            if (UserText.Text != "")
            {
                char[] delimiters = new char[] { ' ', ',', '.', '\n' };
                string count = UserText.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
                counter.Visibility = Visibility.Visible;
                counter.Text = "Number of words: " + count;
            }
            else
                counter.Visibility = Visibility.Hidden;
        }

        private void UserText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserText.Text == "Here you can write your essay. The file will be automatically created on your computer and named 'Writing_Task2_Var1'. You can click on the button '1' to see the task again.")
                UserText.Text = "";
        }

        private async void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            try
            {
                using (StreamReader sr = new StreamReader("../../../Writing/var2Task2.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    var1Task.Text = line;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File with writing rask not found");
            }
            next.Click += Next_Click;
            UserText.TextChanged -= UserText_TextChanged;
            UserText.TextChanged -= UserText_TextChanged2;
            UserText.TextChanged += UserText_TextChanged1;
            SecondVariant.IsEnabled = false;
            FirstVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            next.Visibility = Visibility.Hidden;
        }

        private async void UserText_TextChanged1(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("../../../Wriring/Writing_Task2_Var2.txt"))
                {
                    await sw.WriteAsync(UserText.Text);
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File with writing task not found");
            }
            if (UserText.Text != "")
            {
                char[] delimiters = new char[] { ' ', ',', '.', '\n' };
                string count = UserText.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
                counter.Visibility = Visibility.Visible;
                counter.Text = "Number of words: " + count;
            }
            else
                counter.Visibility = Visibility.Hidden;
        }


        private async void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;

            UserText.Visibility = Visibility.Hidden;
            var1Task.Visibility = Visibility.Visible;
            try
            {
                using (StreamReader sr = new StreamReader("../../../Writing/var3Task2.txt"))
                {
                    string line = await sr.ReadToEndAsync();
                    var1Task.Text = line;
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File with writing task not found");
            }
            next.Click += Next_Click1;
            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;
        }

        private void Next_Click1(object sender, RoutedEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Visible;
            UserText.TextChanged -= UserText_TextChanged;
            UserText.TextChanged -= UserText_TextChanged1;
            UserText.TextChanged += UserText_TextChanged2;
            next.Visibility = Visibility.Hidden;
        }

        private async void UserText_TextChanged2(object sender, TextChangedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("../../../Writing/Writing_Task2_Var3.txt"))
                {
                    await sw.WriteAsync(UserText.Text);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File with writing task not found");
            }
            if (UserText.Text != "")
            {
                char[] delimiters = new char[] { ' ', ',', '.', '\n' };
                string count = UserText.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
                counter.Visibility = Visibility.Visible;
                counter.Text = "Number of words: " + count;
            }
            else
                counter.Visibility = Visibility.Hidden;
        }



        private void Help_MouseEnter(object sender, MouseEventArgs e)
        {
            var1Task.Visibility = Visibility.Hidden;
            UserText.Visibility = Visibility.Hidden;
            _task.Visibility = Visibility.Visible;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StartPage StartPage = new StartPage();
            StartPage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            StartPage.Show();
            this.Close();
        }
    }
    }

