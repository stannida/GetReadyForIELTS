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
        int variant = 0;

        int TheEndOf1;
        int TheEndOf2;
        int TheEndOf3;

        List<string> listFirst;

        private void ListeningLoad()
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../../Listening/taskListening.txt"))
                    taskDescription.Text = sr.ReadToEnd();
                using (StreamReader sr1 = new StreamReader("../../../Listening/Listening_Var1.txt"))
                    variant1 = sr1.ReadToEnd();
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }

            textBlockQuestions.Visibility = Visibility.Hidden;
            comboBoxSections.Visibility = Visibility.Hidden;
            for (int i = 1; i < 5; i++)
                comboBoxSections.Items.Add("Section " + i);
            comboBoxSections.SelectedIndex = 0;

            textBlockTask.Visibility = Visibility.Hidden;
            buttonPrev.Visibility = Visibility.Hidden;
            buttonNext.Visibility = Visibility.Hidden;
            buttonAnswer.Visibility = Visibility.Hidden;

            listFirst = new List<string>();
            listFirst.Add("");
            listFirst.Add("");

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

            int itemQ = 0;
            if (section == 1)
            {
                buttonPrev.IsEnabled = false;
                buttonNext.IsEnabled = false;
                for (int i = 0; i < TheEndOf1; i++)
                    textBlockTask.Text += variant1[i];
            }

            if (section == 2)
            {
                listFirst[0] = "";
                listFirst[1] = "";
                itemQ = 0;
                buttonPrev.IsEnabled = false;
                buttonNext.IsEnabled = true;

                for (int i = TheEndOf1 + 1; i < TheEndOf2; i++)
                    if (variant1[i] == 'Q')
                        itemQ = i;

                for (int i = TheEndOf1 + 1; i < itemQ; i++)
                    listFirst[0] += variant1[i];
                for (int i = itemQ; i < TheEndOf2; i++)
                    listFirst[1] += variant1[i];
                
                textBlockTask.Text = listFirst[0];
            }

            if (section == 3)
            {
                listFirst[0] = "";
                listFirst[1] = "";
                itemQ = 0;
                buttonPrev.IsEnabled = false;
                buttonNext.IsEnabled = true;

                for (int i = TheEndOf2 + 1; i < TheEndOf3; i++)
                    if (variant1[i] == 'Q')
                        itemQ = i;

                for (int i = TheEndOf2 + 1; i < itemQ; i++)
                    listFirst[0] += variant1[i];
                for (int i = itemQ; i < TheEndOf3; i++)
                    listFirst[1] += variant1[i];

                textBlockTask.Text = listFirst[0];
            }

            if (section == 4)
            {
                listFirst[0] = "";
                listFirst[1] = "";
                itemQ = 0;
                buttonPrev.IsEnabled = false;
                buttonNext.IsEnabled = true;

                for (int i = TheEndOf3 + 1; i < variant1.Length; i++)
                    if (variant1[i] == 'Q')
                        itemQ = i;

                for (int i = TheEndOf3 + 1; i < itemQ; i++)
                    listFirst[0] += variant1[i];
                for (int i = itemQ; i < variant1.Length; i++)
                    listFirst[1] += variant1[i];

                textBlockTask.Text = listFirst[0];
            }
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            textBlockTask.Text = "";

            try
            {
                TheFirstDownload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }  
            
            variant = 1;

            ChangeInterface();

            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;
        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            ChangeInterface();

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = false;
            ThirdVariant.IsEnabled = true;
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            ChangeInterface();

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = false;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonPrev.IsEnabled = false;
            buttonNext.IsEnabled = true;
            textBlockTask.Text = "";

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

            if (variant == 1)
                TheFirstDownload();  
        }

        private void ChangeInterface()
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;
            textBlockQuestions.Visibility = Visibility.Visible;

            textBlockTask.Visibility = Visibility.Visible;
            buttonAnswer.Visibility = Visibility.Visible;

            buttonPrev.Visibility = Visibility.Visible;
            buttonNext.Visibility = Visibility.Visible;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StartPage StartPage = new StartPage();
            StartPage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Close();
            StartPage.Show();
        }

        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            ListeningAnswerBox answerbox = new ListeningAnswerBox();
            ListeningAnswerBox answerItems = new ListeningAnswerBox(variant, section);
            answerbox.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            answerbox.Show();
        }

        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            if ((variant == 1) && (section != 1))
            {
                buttonPrev.IsEnabled = false;
                buttonNext.IsEnabled = true;
                textBlockTask.Text = listFirst[0];
            }   
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if ((variant == 1) && (section != 1))
            {
                buttonPrev.IsEnabled = true;
                buttonNext.IsEnabled = false;
                textBlockTask.Text = listFirst[1];
            }   
        }

    }
}
