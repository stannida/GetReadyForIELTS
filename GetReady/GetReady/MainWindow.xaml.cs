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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Data;
namespace GetReady
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn.Visibility = Visibility.Hidden;
            SignUp.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            CheckPassword.Visibility = Visibility.Visible;
            CheckUsername.Visibility = Visibility.Visible;
            LetsStart.Visibility = Visibility.Visible;
            LetsStart.Click -= LetsStart_Click1;
            LetsStart.Click += LetsStart_Click;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignIn.Visibility = Visibility.Hidden;
            SignUp.Visibility = Visibility.Hidden;
            New_password.Visibility = Visibility.Visible;
            New_username.Visibility = Visibility.Visible;
            LetsStart.Visibility = Visibility.Visible;
            LetsStart.Click -= LetsStart_Click;
            LetsStart.Click += LetsStart_Click1;
        }

        private void LetsStart_Click1(object sender, RoutedEventArgs e)
        {
            if ((New_username.Text == "") || (New_password.Text == "") || (New_username.Text == "Pick a username") || (New_password.Text == "Choose a password"))
                MessageBox.Show("Please enter username and password");
            else
            {
                StartPage Startpage = new StartPage();
                Startpage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                this.Close();
                Startpage.Show();
            }
        }

        private void LetsStart_Click(object sender, RoutedEventArgs e)
        {
            if ((CheckPassword.Password == "") || (CheckUsername.Text == ""))
                MessageBox.Show("Please enter username and password");
            else
            {

                StartPage StartPage = new StartPage();
                StartPage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                this.Close();
                StartPage.Show();
            }
        }
        private void GotFocusUsername(object sender, RoutedEventArgs e)
        {
            if (New_username.Text == "Pick a username")
                New_username.Text = "";
        }

        private void LostFocusUsername(object sender, RoutedEventArgs e)
        {
            if (New_username.Text == "")
                New_username.Text = "Pick a username";
        }

        private void GotFocusPassword(object sender, RoutedEventArgs e)
        {
            if (New_password.Text == "Choose a password")
                New_password.Text = "";
        }

        private void LostFocusPassword(object sender, RoutedEventArgs e)
        {
            if (New_password.Text == "")
                New_password.Text = "Choose a password";
        }
        //    UsersEntities db = new UsersEntities();

        //    db.UserTable.Add(new UserTable
        //    {
        //        username = Username.Text,
        //        hash = GetHash(Password.Text)
        //    });
        //    db.SaveChanges();
        //    StartPage StartPage = new StartPage();
        //    StartPage.Show();
        //}
        //    public string GetHash(string password)
        //{ 
        //    System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
        //    string hash = String.Empty; byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
        //    foreach (byte theByte in crypto)
        //    { hash += theByte.ToString("x2"); }
        //    return hash; }
    }
}
