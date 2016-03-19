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
        public ReadingPassage()
        {
            InitializeComponent();
            OpeningData();
        }

        private async void OpeningData()
        {
            using (StreamReader sr = new StreamReader("../../../Reading/TextPassage1_1.txt"))
            {
                headline.Text = sr.ReadLine();
                string line = await sr.ReadToEndAsync();
                passage.Text = line;
            }
        }
    }
}
