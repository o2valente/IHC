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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projeto_IHC
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(username.Text == ""  || password.Password.ToString()=="" )
            {
                MessageBox.Show("Insert Username and Password", "LarderManager",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                Home homePage = new Home();
                this.NavigationService.Navigate(homePage);
            }

            
        }

        

        private void NameText1_Enter(object sender, MouseEventArgs e)
        {
            if (password.Password == "password")
            {
                password.Password = "";
                password.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void NameText_Enter(object sender, MouseEventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
