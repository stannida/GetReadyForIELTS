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
    /// Логика взаимодействия для ReadingAnswerBox.xaml
    /// </summary>
    public partial class ReadingAnswerBox : Window
    {
        public TextBox[] answerBoxes;
        public int j, VarNum;
        public string[] R_answers = new string[15];
        public ReadingAnswerBox(int NumQuest, int j1, int VarNum1)
        {
            InitializeComponent();
            j = j1;
            VarNum = VarNum1;
            answerBoxes = createAnswerBoxes(NumQuest);
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private TextBox[] createAnswerBoxes(int NumQuest)
        {
            TextBox[] answerBoxes = new TextBox[NumQuest];
            for (int i = 0; i < answerBoxes.Length; i++)
            {
                answerBoxes[i] = new TextBox();
                string Name = "AnswerNum" + i.ToString();
                answerBoxes[i].Name = Name;
                if(i==0)
                    answerBoxes[0].Margin = new Thickness(20, 60, 3, 0);
                else
                    answerBoxes[i].Margin = new Thickness(20, 20, 3, 0);
                answerBoxes[i].Visibility = Visibility.Visible;
                this.SP.Children.Add(answerBoxes[i]);
                if ((answerBoxes[i].IsFocused == true) && (answerBoxes[i].Text == i.ToString()))
                    answerBoxes[i].Text = "";
                
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
            
            for (int i = 0; i < answerBoxes.Length; i++)
            {
                string U_answer = answerBoxes[i].Text;
                if(U_answer==R_answers[i])
                    answerBoxes[i].Background = Brushes.Green;
                else
                    answerBoxes[i].Background = Brushes.Red;                  
            }
            show.Visibility = Visibility.Visible;
        }
    }
}
