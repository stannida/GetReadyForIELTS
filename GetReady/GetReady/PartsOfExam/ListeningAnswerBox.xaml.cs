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

namespace GetReady
{
    /// <summary>
    /// Interaction logic for ListeningAnswerBox.xaml
    /// </summary>
    public partial class ListeningAnswerBox : Window
    {
        private int variant;
        private int section;

        public ListeningAnswerBox()
        {
            InitializeComponent();
            this.MinHeight = 400;
            this.MinWidth = 600;
        }

        public ListeningAnswerBox(int variant, int section)
        {
            this.variant = variant;
            this.section = section;

            ListeningDownloadImages();
        }

        private void ListeningDownloadImages()
        {

            //if (variant == 1)
            //{
            //    switch (section)
            //    {
            //        case 1:
            //            imageVariant1Part1.Visibility = Visibility.Visible;
            //            break;
            //        case 2:
            //            imageVariant1Part2_1.Visibility = Visibility.Visible;
            //            imageVariant1Part2_2.Visibility = Visibility.Visible;
            //            break;
            //        case 3:
            //            imageVariant1Part3_1.Visibility = Visibility.Visible;
            //            imageVariant1Part3_2.Visibility = Visibility.Visible;
            //            break;
            //        case 4:
            //            imageVariant1Part4_1.Visibility = Visibility.Visible;
            //            imageVariant1Part4_2.Visibility = Visibility.Visible;
            //            break;
            //        default:
            //            MessageBox.Show("Error!");
            //            break;
            //    }
            //}


           
        }
    }
}
