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
        public int NumQuest;
        public ReadingAnswerBox()
        {
            InitializeComponent();
            createAnswerBoxes();
        }
        private void createAnswerBoxes()
        {
            TextBox[] answerBoxes = new TextBox[3];
            int i = 0;
            foreach (TextBox answer in answerBoxes)
            {
                string Name = "AnswerNum" + i.ToString();
                answer.Name = Name;
                answer.Text = (i + 1).ToString();
                answer.Margin = new Thickness(20, 0, i * 28, 0);
                answer.Visibility = Visibility.Visible;
                i++;

            }
        }
    }
}
