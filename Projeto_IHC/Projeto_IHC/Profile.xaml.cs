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
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
            Globals.user.Date = date.Text;
            Globals.user.Location = location.Text;
            MessageBox.Show("Profile Saved","LarderManager",MessageBoxButton.OK,MessageBoxImage.Information);
            
        }
    }
}