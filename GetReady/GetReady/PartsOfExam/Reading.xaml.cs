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
            using (StreamReader sr = new StreamReader("../../../Reading/taskReading.txt"))
            {

                string line = await sr.ReadToEndAsync();
                _task.Text = line;
                
            }
        }
        private void OpeningVariantTask(int NumQuest)
        {

        }

        private async void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            VarNum = 1;
            _task.Visibility = Visibility.Hidden;
            using (StreamReader sr = new StreamReader("../../../Reading/ReadingVar1_" + j + ".txt"))
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
            answer.Visibility = Visibility.Visible;
            Help.MouseLeave += Help_MouseLeave;
            next.Visibility = Visibility.Visible;

        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {

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


        private void answer_Click(object sender, RoutedEventArgs e)
        {
            ReadingAnswerBox RAB = new ReadingAnswerBox(NumQuest, j, VarNum);
            
            RAB.Show();
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

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            ReadingPassage RP = new ReadingPassage();
            RP.Show();
        }

        private async void prev_Click(object sender, RoutedEventArgs e)
        {
            j--;
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

        private async void next_Click(object sender, RoutedEventArgs e)
        {
            j++;
            if (j == 4)
                next.Visibility = Visibility.Hidden;
            using (StreamReader sr = new StreamReader("../../../Reading/ReadingVar" + VarNum + "_" + j + ".txt"))
            {

                var line = sr.ReadLine();
                var items = line.Split(' ');
                var items2 = items[1].Split('-');
                if (items2.Length == 1)
                    NumQuest = 1;
                else
                    NumQuest = int.Parse(items2[1]) - int.Parse(items2[0]) + 1;
                string text = await sr.ReadToEndAsync();
                VarTask.Text = text;
                link.Visibility = Visibility.Visible;
            }
            prev.Visibility = Visibility.Visible;
            
            
        }
    }
}
