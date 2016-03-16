﻿using System;
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
//using System.Data;
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

        private void GotFocusUsername(object sender, RoutedEventArgs e)
        {
            if (username.Text == "Pick a username")
                username.Text = "";
        }

        private void LostFocusUsername(object sender, RoutedEventArgs e)
        {
            if (username.Text == "")
                username.Text = "Pick a username";
        }

        private void GotFocusPassword(object sender, RoutedEventArgs e)
        {
            if (password.Text == "Choose a password")
                password.Text = "";
        }

        private void LostFocusPassword(object sender, RoutedEventArgs e)
        {
            if (password.Text == "")
                password.Text = "Choose a password";
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

          
       

        public void LetsStart_Click_1(object sender, RoutedEventArgs e)
        {
            StartPage Startpage = new StartPage();
            Startpage.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Startpage.Show();
        }
    }

    }

