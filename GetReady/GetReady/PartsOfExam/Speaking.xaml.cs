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
    /// Interaction logic for Speaking.xaml
    /// </summary>
    public partial class Speaking : Window
    {
        private int _variant = 0;

        private string Var1;
        private string Var2;
        private string Var3;

        int TheEndOf1;
        int TheEndOf2;

        public Speaking()
        {
            InitializeComponent();

            SpeakingLoad();
            
        }

        private void SpeakingLoad()
        {
            using (StreamReader sr = new StreamReader("../../../taskSpeaking.txt"))
            {
                TaskDescription.Text = sr.ReadToEnd();
            }

            RadioButtonPart1.Visibility = Visibility.Hidden;
            RadioButtonPart2.Visibility = Visibility.Hidden;
            RadioButtonPart3.Visibility = Visibility.Hidden;
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 1;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            TaskDescription.Text = "";

            FirstVariant.Background = System.Windows.Media.Brushes.PaleTurquoise;

            using (StreamReader sr = new StreamReader("../../../Speaking_Var1.txt"))
            {
                Var1 = sr.ReadToEnd();
            }

            for (int i = 0; i < Var1.Length; i++)
                if (Var1[i] == ';')
                {
                    TheEndOf1 = i;
                    break;
                }

            for (int i=TheEndOf1+1; i<Var1.Length; i++)
                if (Var1[i] == ';')
                {
                    TheEndOf2 = i;
                    break;
                }

            
        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 2;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            TaskDescription.Text = "";

        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 3;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

        }

        private void ButtonPart1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPart2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPart3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckedPart1(object sender, RoutedEventArgs e)
        {
            TextBlockTask.Text = "";
            for (int i = 0; i < TheEndOf1; i++)
                    TextBlockTask.Text += Var1[i];
        }

        private void CheckedPart2(object sender, RoutedEventArgs e)
        {
            TextBlockTask.Text = "";
            for (int i = TheEndOf1+1; i < TheEndOf2; i++)
                TextBlockTask.Text += Var1[i];

        }

        private void CheckedPart3(object sender, RoutedEventArgs e)
        {
            TextBlockTask.Text = "";
            for (int i = TheEndOf2 + 1; i < Var1.Length; i++)
                TextBlockTask.Text += Var1[i];

        }

 
    }
}
