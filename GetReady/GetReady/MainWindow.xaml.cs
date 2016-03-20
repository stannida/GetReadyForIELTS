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

        private void SigningIn()
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
            change.Content = "Don't have an account?";
            change.Visibility = Visibility.Visible;
            change.Click -= change_Click;
            change.Click += change_Click1;
        }



        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SigningIn();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SigningUp();
        }
        private void SigningUp()
        {
            SignIn.Visibility = Visibility.Hidden;
            SignUp.Visibility = Visibility.Hidden;
            New_password.Visibility = Visibility.Visible;
            New_username.Visibility = Visibility.Visible;
            LetsStart.Visibility = Visibility.Visible;
            LetsStart.Click -= LetsStart_Click;
            LetsStart.Click += LetsStart_Click1;
            change.Content = "Already have an account?";
            change.Visibility = Visibility.Visible;
            change.Click += change_Click;
            change.Click -= change_Click1;
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

        private void Rules_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application will assist you on your way of preparing to IELTS exam. You need to register as your progress will be saved only if you have an account. Once you did this, you will see the start page with four main sections of IELTS exam: Listening, Reading, Writing and Speaking. Each section contains main rules and 3 variants to practice your skills. Writing section saves everything you write there on your computer, named 'Writing_Task#_Var#'. For Reading and Listening tasks you get scores which will be saved in your account. Good luck!");
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            New_password.Visibility = Visibility.Hidden;
            New_username.Visibility = Visibility.Hidden;
            SigningIn();
        }
        private void change_Click1(object sender, RoutedEventArgs e)
        {
            CheckPassword.Visibility = Visibility.Hidden;
            CheckUsername.Visibility = Visibility.Hidden;
            name.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Hidden;
            SigningUp();
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
