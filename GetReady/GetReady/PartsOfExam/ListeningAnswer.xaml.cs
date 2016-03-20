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
    /// Interaction logic for ListeningAnswer.xaml
    /// </summary>
    public partial class ListeningAnswer : Window
    {
        private int variant;
        private int section;

        public ListeningAnswer()
        {
            InitializeComponent();
        }

        public ListeningAnswer(int variant, int section)
        {
            this.variant = variant;
            this.section = section;
        }
    }
}
