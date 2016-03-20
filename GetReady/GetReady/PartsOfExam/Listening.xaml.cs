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
            
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;


        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            comboBoxSections.Visibility = Visibility.Visible;
            taskDescription.Visibility = Visibility.Hidden;

        }


    }
}
