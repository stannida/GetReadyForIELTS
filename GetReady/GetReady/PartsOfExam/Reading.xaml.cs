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
    /// Логика взаимодействия для Reading.xaml
    /// </summary>
    public partial class Reading : Window
    {
        public int NumQuest, j=1, VarNum;
        public Reading()
        {
            InitializeComponent();
            LoadingTask();
            
        }
        private async void LoadingTask()
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../../Reading/taskReading.txt"))
                {

                    string line = await sr.ReadToEndAsync();
                    _task.Text = line;

                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("File with reading task not found");
            }
        }
        private async void OpeningVariant(int VarNum, int j)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../../Reading/ReadingVar" + VarNum + "_" + j + ".txt"))
                {

                    var line = sr.ReadLine();
                    var items = line.Split(' ');
                    var items2 = items[1].Split('-');
                    if (items2.Length == 1)
                        NumQuest = int.Parse(items2[0]);
                    else
                        NumQuest = int.Parse(items2[1]) - int.Parse(items2[0]) + 1;
                    string text = await sr.ReadToEndAsync();
                    VarTask.Text = text;
                    link.Visibility = Visibility.Visible;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File with reading task not found");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops, something went wrong /n" + ex);
            }
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            VarNum = 1;
            j = 1;
            _task.Visibility = Visibility.Hidden;
            OpeningVariant(VarNum, j);
            answer.Visibility = Visibility.Visible;
            Help.MouseLeave += Help_MouseLeave;
            next.Visibility = Visibility.Visible;
            prev.Visibility = Visibility.Hidden;
            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;
        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            VarNum = 2;
            j = 1;
            _task.Visibility = Visibility.Hidden;
            OpeningVariant(VarNum, j);   
            answer.Visibility = Visibility.Visible;
            Help.MouseLeave += Help_MouseLeave;
            next.Visibility = Visibility.Visible;
            prev.Visibility = Visibility.Hidden;
            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = false;
            ThirdVariant.IsEnabled = true;
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            VarNum = 3;
            j = 1;
            _task.Visibility = Visibility.Hidden;
            OpeningVariant(VarNum, j);
            answer.Visibility = Visibility.Visible;
            Help.MouseLeave += Help_MouseLeave;
            next.Visibility = Visibility.Visible;
            prev.Visibility = Visibility.Hidden;
            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = false;
        }

        private void Help_MouseEnter(object sender, MouseEventArgs e)
        {
            VarTask.Visibility = Visibility.Hidden;
            answer.Visibility = Visibility.Hidden;
            _task.Visibility = Visibility.Visible;
            link.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Hidden;
            prev.Visibility = Visibility.Hidden;
        }


        private void Help_MouseLeave(object sender, MouseEventArgs e)
        {
            _task.Visibility = Visibility.Hidden;
            link.Visibility = Visibility.Visible;
            answer.Visibility = Visibility.Visible;
            VarTask.Visibility = Visibility.Visible;
            if (j != 4)
                next.Visibility = Visibility.Visible;
            if (j != 1)
                prev.Visibility = Visibility.Visible;
        }

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            ReadingAnswerBox RAB = new ReadingAnswerBox(NumQuest, j, VarNum);
            RAB.Show();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            ReadingPassage RP = new ReadingPassage(VarNum);
            RP.Show();
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            j--;
            OpeningVariant(VarNum, j);
            if (j == 1)
                prev.Visibility = Visibility.Hidden;
            next.Visibility = Visibility.Visible;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StartPage StartPage = new StartPage();
            StartPage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            StartPage.Show();
            this.Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            j++;
            if (j == 4)
                next.Visibility = Visibility.Hidden;
            OpeningVariant(VarNum, j);
            prev.Visibility = Visibility.Visible;
            
            
        }
    }
}
