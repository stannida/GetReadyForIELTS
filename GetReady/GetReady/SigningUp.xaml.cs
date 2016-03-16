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
    /// Логика взаимодействия для SigningUp1.xaml
    /// </summary>
    public partial class SigningUp : Window
    {
        public SigningUp()
        {
            InitializeComponent();
        }

        private void FocusUsernameDeleteText(object sender, RoutedEventArgs e)
        {
            if (username.Text == "Pick a username")
                username.Text = "";
        }

        private void FocusPasswordDeleteText(object sender, RoutedEventArgs e)
        {
            if (password.Text == "Choose a password")
                password.Text = "";
        }

        private void LostFocusUsername(object sender, RoutedEventArgs e)
        {
            if (username.Text == "")
                username.Text = "Pick a username";
        }

        private void LostFocusPassword(object sender, RoutedEventArgs e)
        {
            if (password.Text == "")
                password.Text = "Choose a password";
        }
    }
}
