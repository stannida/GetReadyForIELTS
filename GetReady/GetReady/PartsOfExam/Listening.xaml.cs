using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для Listening.xaml
    /// </summary>
    public partial class Listening : Window
    {
        public Listening()
        {
            InitializeComponent();
            ListeningLoad();
        }

        private void ListeningLoad()
        {
            using (StreamReader sr = new StreamReader("../../../Listening/taskListening.txt"))
                taskDescription.Text = sr.ReadToEnd();

            comboBoxSections.Visibility = Visibility.Hidden;
            for (int i = 1; i < 5; i++)
                comboBoxSections.Items.Add("Section " + i);
            comboBoxSections.SelectedIndex = 0;

            SoundPlayer player = new SoundPlayer();

            //player.Stream = "../../../Listening/Listening_Var1.wav";

            player.SoundLocation = "../../../Listening/Listening_Var1.wav";
            player.Load();
            player.Play();

        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;

            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;


        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = false;
            ThirdVariant.IsEnabled = true;
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = false;

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSections.SelectedIndex == 0)
            {
                textBlockQuestions.Text = "Questions 1-10";
            }

            if (comboBoxSections.SelectedIndex == 1)
            {
                textBlockQuestions.Text = "Questions 11-20";
            }

            if (comboBoxSections.SelectedIndex == 2)
            {
                textBlockQuestions.Text = "Questions 21-30";
            }

            if (comboBoxSections.SelectedIndex == 3)
            {
                textBlockQuestions.Text = "Questions 31-40";
            }


        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StartPage StartPage = new StartPage();
            StartPage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Close();
            StartPage.Show();
        }

    }
}
