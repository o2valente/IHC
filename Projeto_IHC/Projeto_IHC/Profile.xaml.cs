using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();
            name.Content = Globals.user.Nome;
            date.Text = Globals.user.Date;
            location.Text = Globals.user.Location;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (this.NavigationService.CanGoBack)
            //{
            //    this.NavigationService.GoBack();
            //}
            //else
            //{
            //    MessageBox.Show("No entries in back navigation history.", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            Home homePage = new Home();
            this.NavigationService.Navigate(homePage);


        }

        private void MiguelLarderProfile(object sender, MouseButtonEventArgs e)
        {
            MiguelLarder miguel = new MiguelLarder();
            this.NavigationService.Navigate(miguel);
        }

        private void AddMember(object sender, MouseButtonEventArgs e)
        {
            Add_Member add = new Add_Member();
            this.NavigationService.Navigate(add);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] formats = {"d/M/yyyy","d/M/yy", "dd/MM/yy",
                   "dd/MM/yyyy"};

            DateTime dateValue;

            if (DateTime.TryParseExact(date.Text, formats, new CultureInfo("pt-PT"), DateTimeStyles.None, out dateValue)) { 
                Globals.user.Date = date.Text;
                Globals.user.Location = location.Text;
                MessageBox.Show("Profile Saved", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { MessageBox.Show("Invalid Date \nFormat dd/mm/yyyy or dd/mm/yy", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error); }

            
        }
    }
}