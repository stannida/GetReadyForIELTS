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

        string variant1;
        int section = 1;

        int TheEndOf1;
        int TheEndOf2;
        int TheEndOf3;

        private void ListeningLoad()
        {
            using (StreamReader sr = new StreamReader("../../../Listening/taskListening.txt"))
                taskDescription.Text = sr.ReadToEnd();

            using (StreamReader sr1 = new StreamReader("../../../Listening/Listening_Var1.txt"))
                variant1 = sr1.ReadToEnd();

            TheFirstDownload();

            textBlockQuestions.Visibility = Visibility.Hidden;

            comboBoxSections.Visibility = Visibility.Hidden;
            for (int i = 1; i < 5; i++)
                comboBoxSections.Items.Add("Section " + i);
            comboBoxSections.SelectedIndex = 0;

            textBlockTask.Visibility = Visibility.Hidden;

            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = "../../../Listening/Listening_Var1.wav";
            //player.Load();
            //player.Play();

        }

        private void TheFirstDownload()
        {
            for (int i = 0; i < variant1.Length; i++)
                if (variant1[i] == ';')
                {
                    TheEndOf1 = i;
                    break;
                }

            for (int i = TheEndOf1 + 1; i < variant1.Length; i++)
                if (variant1[i] == ';')
                {
                    TheEndOf2 = i;
                    break;
                }

            for (int i = TheEndOf2 + 1; i < variant1.Length; i++)
                if (variant1[i] == ';')
                {
                    TheEndOf3 = i;
                    break;
                }
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;
            textBlockQuestions.Visibility = Visibility.Visible;

            textBlockTask.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;

            if (section == 1)
                for (int i = 0; i < TheEndOf1; i++)
                {
                    textBlockTask.Text += variant1[i];
                }

            if (section == 2)
                for (int i = TheEndOf1 + 1; i < TheEndOf2; i++)
                {
                    textBlockTask.Text += variant1[i];
                }

            if (section == 3)
                for (int i = TheEndOf2 + 1; i < TheEndOf3; i++)
                {
                    textBlockTask.Text += variant1[i];
                }

            if (section == 4)
                for (int i = TheEndOf3 + 1; i < variant1.Length; i++)
                {
                    textBlockTask.Text += variant1[i];
                }

        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;
            textBlockQuestions.Visibility = Visibility.Visible;

            textBlockTask.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = false;
            ThirdVariant.IsEnabled = true;
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;
            textBlockQuestions.Visibility = Visibility.Visible;

            textBlockTask.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = false;

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxSections.SelectedIndex == 0)
            {
                textBlockQuestions.Text = "Questions 1-10";
                section = 1;
            }

            if (comboBoxSections.SelectedIndex == 1)
            {
                textBlockQuestions.Text = "Questions 11-20";
                section = 2;
            }

            if (comboBoxSections.SelectedIndex == 2)
            {
                textBlockQuestions.Text = "Questions 21-30";
                section = 3;
            }

            if (comboBoxSections.SelectedIndex == 3)
            {
                textBlockQuestions.Text = "Questions 31-40";
                section = 4;
            }
        }

        private void Variant1Section1()
        { 
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
