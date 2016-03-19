using System;
using System.Collections.Generic;
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

        public ReadingAnswerBox(int NumQuest)
        {
            InitializeComponent();
            createAnswerBoxes(NumQuest);
        }
        private void createAnswerBoxes(int NumQuest)
        {
            TextBox[] answerBoxes = new TextBox[NumQuest];
            for (int i = 0; i < answerBoxes.Length; i++)
            {
                answerBoxes[i] = new TextBox();
                string Name = "AnswerNum" + i.ToString();
                answerBoxes[i].Name = Name;
                answerBoxes[i].Text = (i + 1).ToString();
                if(i==0)
                    answerBoxes[0].Margin = new Thickness(20, 60, 20, 0);
                else
                    answerBoxes[i].Margin = new Thickness(20, 20, 20, 0);
                answerBoxes[i].Visibility = Visibility.Visible;
                this.SP.Children.Add(answerBoxes[i]);
                if ((answerBoxes[i].IsFocused == true) && (answerBoxes[i].Text == i.ToString()))
                    answerBoxes[i].Text = "";
            }
            


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Answers are saved!");
            ReadingAnswerBox RAB = new ReadingAnswerBox(0);
            RAB.Close();
        }
    }
}
