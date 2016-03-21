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
using System.Data;

namespace GetReady.PartsOfExam
{
    /// <summary>
    /// Логика взаимодействия для ReadingAnswerBox.xaml
    /// </summary>
    public partial class ReadingAnswerBox : Window
    {
        public TextBox[] answerBoxes;
        public int j, VarNum;
        public string[] R_answers = new string[15];
        public ReadingAnswerBox(int NumQuest, int _j, int _VarNum)
        {
            InitializeComponent();
            j = _j;
            VarNum = _VarNum;
            answerBoxes = createAnswerBoxes(NumQuest);
            
        }


        public TextBox[] createAnswerBoxes(int NumQuest)
        {
            TextBox[] answerBoxes = new TextBox[NumQuest];
            try
            {
                for (int i = 0; i < answerBoxes.Length; i++)
                {
                    answerBoxes[i] = new TextBox();
                    string Name = "AnswerNum" + i.ToString();
                    answerBoxes[i].Name = Name;
                    if (i == 0)
                        answerBoxes[0].Margin = new Thickness(20, 60, 3, 0);
                    else
                        answerBoxes[i].Margin = new Thickness(20, 20, 3, 0);
                    answerBoxes[i].Visibility = Visibility.Visible;
                    this.SP.Children.Add(answerBoxes[i]);
                    if ((answerBoxes[i].IsFocused == true) && (answerBoxes[i].Text == i.ToString()))
                        answerBoxes[i].Text = "";

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Oops, something went wrong " + ex);
            }
            return answerBoxes;
            


        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            
            for (int i = 0; i < answerBoxes.Length; i++)
            {
                answerBoxes[i].Text = R_answers[i];
            }
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader sr = new StreamReader("../../../Reading/ReadingAnswers" + VarNum + "_" + j + ".txt"))
                {
                for (int i = 0; i < answerBoxes.Length; i++)  
                    R_answers[i] = sr.ReadLine();
                }
            UsersEntities db = new UsersEntities();


            for (int i = 0; i < answerBoxes.Length; i++)
            {
                string U_answer = answerBoxes[i].Text;
                if (U_answer == R_answers[i])
                {
                    answerBoxes[i].Background = Brushes.Green;
                    
                }

                else
                    answerBoxes[i].Background = Brushes.Red;                  
            }
            show.Visibility = Visibility.Visible;
        }
    }
}
