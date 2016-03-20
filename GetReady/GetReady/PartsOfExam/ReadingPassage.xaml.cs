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
    /// Логика взаимодействия для ReadingPassage.xaml
    /// </summary>
    public partial class ReadingPassage : Window
    {
        public ReadingPassage(int VarNum)
        {
            InitializeComponent();
            OpeningData(VarNum);
        }

        private async void OpeningData(int VarNum)
        {
            using (StreamReader sr = new StreamReader("../../../Reading/TextPassage" + VarNum + ".txt"))
            {
                headline.Text = sr.ReadLine();
                string line = await sr.ReadToEndAsync();
                passage.Text = line;
            }
        }
    }
}
