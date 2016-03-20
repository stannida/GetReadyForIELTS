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
        int timeNow = 0;
        System.Windows.Threading.DispatcherTimer timer;
        int PausePlay = 0;

        public Speaking()
        {
            InitializeComponent();
            SpeakingLoad();        
        }

        private void SpeakingLoad()
        {
            RadioButtonPart1.Visibility = Visibility.Hidden;
            RadioButtonPart2.Visibility = Visibility.Hidden;
            RadioButtonPart3.Visibility = Visibility.Hidden;

            ProgressBarTime.Maximum = 120;

            ButtonTime.Visibility = Visibility.Hidden;
            ProgressBarTime.Visibility = Visibility.Hidden;
            ButtonPause.Visibility = Visibility.Hidden;
            ButtonStop.Visibility = Visibility.Hidden;

            try
            {
                using (StreamReader sr = new StreamReader("../../../Speaking/taskSpeaking.txt"))
                    TaskDescription.Text = sr.ReadToEnd();

                using (StreamReader sr1 = new StreamReader("../../../Speaking/Speaking_Var1.txt"))
                    Variant1 = sr1.ReadToEnd();

                using (StreamReader sr2 = new StreamReader("../../../Speaking/Speaking_Var2.txt"))
                    Variant2 = sr2.ReadToEnd();

                using (StreamReader sr3 = new StreamReader("../../../Speaking/Speaking_Var3.txt"))
                    Variant3 = sr3.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found");
            }
        }

        private void FirstVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 1;
            TextBlockTask.Text = "";
            ButtonTime.Visibility = Visibility.Visible;

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = false;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = true;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            try
            {
                for (int i = 0; i < Variant1.Length; i++)
                    if (Variant1[i] == ';')
                    {
                        TheEndOf1 = i;
                        break;
                    }

                for (int i = TheEndOf1 + 1; i < Variant1.Length; i++)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }
        }

        private void SecondVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 2;
            TextBlockTask.Text = "";
            ButtonTime.Visibility = Visibility.Visible;

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = false;
            ThirdVariant.IsEnabled = true;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }          
        }

        private void ThirdVariant_Click(object sender, RoutedEventArgs e)
        {
            _variant = 3;
            TextBlockTask.Text = "";
            ButtonTime.Visibility = Visibility.Visible;

            TaskDescription.Visibility = Visibility.Hidden;

            RadioButtonPart1.Visibility = Visibility.Visible;
            RadioButtonPart2.Visibility = Visibility.Visible;
            RadioButtonPart3.Visibility = Visibility.Visible;

            FirstVariant.IsEnabled = true;
            SecondVariant.IsEnabled = true;
            ThirdVariant.IsEnabled = false;

            if (_checkedPart == 0)
            {
                RadioButtonPart1.IsChecked = true;
                _checkedPart = 1;
            }

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }       
        }

        private void CheckedPart1(object sender, RoutedEventArgs e)
        {
            _checkedPart = 1;
            TextBlockTask.Text = "";

            try
            {
                if (_variant == 1)
                    Variant1Part1();

                if (_variant == 2)
                    Variant2Part1();

                if (_variant == 3)
                    Variant3Part1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }  

        }

        private void CheckedPart2(object sender, RoutedEventArgs e)
        {
            _checkedPart = 2;
            TextBlockTask.Text = "";

            try
            {
                if (_variant == 1)
                    Variant1Part2();

                if (_variant == 2)
                    Variant2Part2();

                if (_variant == 3)
                    Variant3Part2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }  
        }

        private void CheckedPart3(object sender, RoutedEventArgs e)
        {
            _checkedPart = 3;
            TextBlockTask.Text = "";

            try
            {
                if (_variant == 1)
                    Variant1Part3();

                if (_variant == 2)
                    Variant2Part3();

                if (_variant == 3)
                    Variant3Part3();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex);
            }  
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
            if (timeNow < 120)
            {
                timeNow = timeNow + 1;
                ProgressBarTime.Value += 1;

                if (timeNow == 1)
                {
                    LabelTime.Content = "1 second";
                    return;
                }

                if ((timeNow < 60) && (timeNow != 1))
                {
                    LabelTime.Content = timeNow + " seconds";
                    return;
                }

                if (timeNow == 60)
                {
                    LabelTime.Content = "1 minute";
                    return;
                }

                if (timeNow == 61)
                {
                    LabelTime.Content = "1 minute 1 second";
                    return;
                }

                if ((timeNow > 60) && (timeNow != 61) && (timeNow != 120))
                {
                    LabelTime.Content = "1 minute " + (timeNow - 60) + " seconds";
                    return;
                }
            }
            else
            {
                timer.Stop();
                LabelTime.Content = "2 minutes";
            }
        }

        private void ButtonTime_Click(object sender, RoutedEventArgs e)
        {
            PausePlay = 1;

            ProgressBarTime.Value = 0;
            timeNow = 0;

            if (ProgressBarTime.Visibility == Visibility.Hidden)
            {
                ProgressBarTime.Visibility = Visibility.Visible;
                ButtonPause.Visibility = Visibility.Visible;
                ButtonStop.Visibility = Visibility.Visible;

                timer = new System.Windows.Threading.DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
            }
            else
            {
                ProgressBarTime.Visibility = Visibility.Hidden;
                ButtonPause.Visibility = Visibility.Hidden;
                ButtonStop.Visibility = Visibility.Hidden;

                TimerClearAll();
            }
        }

        private void ButtonPause_Click(object sender, RoutedEventArgs e)
        {
            if (timeNow != 120)
            {
                if (PausePlay == 1)
                {
                    timer.Stop();
                    PausePlay = 0;
                }
                else
                {
                    timer.Start();
                    PausePlay = 1;
                }
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            TimerClearAll();        
        }

        private void TimerClearAll()
        {
            timer.Stop();
            ProgressBarTime.Value = 0;
            PausePlay = 0;
            timeNow = 0;
            LabelTime.Content = "";
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
