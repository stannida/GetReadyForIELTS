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

using System.Threading;

namespace GetReady.PartsOfExam
{
    /// <summary>
    /// Interaction logic for Speaking.xaml
    /// </summary>
    public partial class Speaking : Window
    {
        int _variant = 0;
        int _checkedPart = 0; 

        private string Variant1;
        private string Variant2;
        private string Variant3;

        int TheEndOf1;
        int TheEndOf2;

        int timeLeft = 120;
        System.Windows.Threading.DispatcherTimer timer;

        public Speaking()
        {
            InitializeComponent();
            SpeakingLoad();   
        }

        private void SpeakingLoad()
        {
            using (StreamReader sr = new StreamReader("../../../taskSpeaking.txt"))
                TaskDescription.Text = sr.ReadToEnd();
            
            RadioButtonPart1.Visibility = Visibility.Hidden;
            RadioButtonPart2.Visibility = Visibility.Hidden;
            RadioButtonPart3.Visibility = Visibility.Hidden;

            using (StreamReader sr1 = new StreamReader("../../../Speaking_Var1.txt"))
                Variant1 = sr1.ReadToEnd();

            using (StreamReader sr2 = new StreamReader("../../../Speaking_Var2.txt"))
                Variant2 = sr2.ReadToEnd();

            using (StreamReader sr3 = new StreamReader("../../../Speaking_Var3.txt"))
                Variant3 = sr3.ReadToEnd();
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 1;
            TextBlockTask.Text = "";

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            FirstVariant.Background = System.Windows.Media.Brushes.PaleTurquoise;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            for (int i = 0; i < Variant1.Length; i++)
                if (Variant1[i] == ';')
                {
                    TheEndOf1 = i;
                    break;
                }

            for (int i=TheEndOf1+1; i<Variant1.Length; i++)
                if (Variant1[i] == ';')
                {
                    TheEndOf2 = i;
                    break;
                }

            if (_checkedPart == 1)
                Variant1Part1();
            if (_checkedPart == 2)
                Variant1Part2();
            if (_checkedPart == 3)
                Variant1Part3();
        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 2;
            TextBlockTask.Text = "";

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            for (int i = 0; i < Variant2.Length; i++)
                if (Variant2[i] == ';')
                {
                    TheEndOf1 = i;
                    break;
                }

            for (int i = TheEndOf1 + 1; i < Variant2.Length; i++)
                if (Variant2[i] == ';')
                {
                    TheEndOf2 = i;
                    break;
                }

            if (_checkedPart == 1)
                Variant2Part1();
            if (_checkedPart == 2)
                Variant2Part2();
            if (_checkedPart == 3)
                Variant2Part3();
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 3;
            TextBlockTask.Text = "";

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            for (int i = 0; i < Variant3.Length; i++)
                if (Variant3[i] == ';')
                {
                    TheEndOf1 = i;
                    break;
                }

            for (int i = TheEndOf1 + 1; i < Variant3.Length; i++)
                if (Variant3[i] == ';')
                {
                    TheEndOf2 = i;
                    break;
                }

            if (_checkedPart == 1)
                Variant3Part1();
            if (_checkedPart == 2)
                Variant3Part2();
            if (_checkedPart == 3)
                Variant3Part3();
        }

        private void CheckedPart1(object sender, RoutedEventArgs e)
        {
            _checkedPart = 1;
            TextBlockTask.Text = "";

            if (_variant == 1)
                Variant1Part1();

            if (_variant == 2)
                Variant2Part1();

            if (_variant == 3)
                Variant3Part1();
        }

        private void CheckedPart2(object sender, RoutedEventArgs e)
        {
            _checkedPart = 2;
            TextBlockTask.Text = "";

            if (_variant == 1)
                Variant1Part2();

            if (_variant == 2)
                Variant2Part2();

            if (_variant == 3)
                Variant3Part2();
        }

        private void CheckedPart3(object sender, RoutedEventArgs e)
        {
            _checkedPart = 3;
            TextBlockTask.Text = "";

            if (_variant == 1)
                Variant1Part3();

            if (_variant == 2)
                Variant2Part3();

            if (_variant == 3)
                Variant3Part3();
        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlockTask.Visibility = Visibility.Hidden;
            RadioButtonPart1.Visibility = Visibility.Hidden;
            RadioButtonPart2.Visibility = Visibility.Hidden;
            RadioButtonPart3.Visibility = Visibility.Hidden;
            TaskDescription.Visibility = Visibility.Visible;
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlockTask.Visibility = Visibility.Visible;
            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;
            TaskDescription.Visibility = Visibility.Hidden;
        }

        private void Variant1Part1()
        {
            for (int i = 0; i < TheEndOf1; i++)
                TextBlockTask.Text += Variant1[i];
        }

        private void Variant1Part2()
        {
            for (int i = TheEndOf1 + 1; i < TheEndOf2; i++)
                TextBlockTask.Text += Variant1[i]; 
        }

        private void Variant1Part3()
        {
            for (int i = TheEndOf2 + 1; i < Variant1.Length; i++)
                TextBlockTask.Text += Variant1[i];
        }

        private void Variant2Part1()
        {
            for (int i = 0; i < TheEndOf1; i++)
                TextBlockTask.Text += Variant2[i];
        }

        private void Variant2Part2()
        {
            for (int i = TheEndOf1 + 1; i < TheEndOf2; i++)
                TextBlockTask.Text += Variant2[i];
        }

        private void Variant2Part3()
        {
            for (int i = TheEndOf2 + 1; i < Variant2.Length; i++)
                TextBlockTask.Text += Variant2[i];
        }

        private void Variant3Part1()
        {
            for (int i = 0; i < TheEndOf1; i++)
                TextBlockTask.Text += Variant3[i];
        }

        private void Variant3Part2()
        {
            for (int i = TheEndOf1 + 1; i < TheEndOf2; i++)
                TextBlockTask.Text += Variant3[i];
        }

        private void Variant3Part3()
        {
            for (int i = TheEndOf2 + 1; i < Variant3.Length; i++)
                TextBlockTask.Text += Variant3[i];
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                LabelTime.Content = timeLeft + " seconds";

            }
            else
            {
                timer.Stop();

                //timeLabel.Text = "Time's up!";
                //LabelTime.Content = "";
                //MessageBox.Show("You didn't finish in time.", "Sorry!");
                //sum.Value = addend1 + addend2;
                //startButton.Enabled = true;
            }
        }

        private void ButtonTime_Click(object sender, RoutedEventArgs e)
        {
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Start();

        }
    }
}
