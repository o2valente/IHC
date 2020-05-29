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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sign Out ?","Larder Manager",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Welcome welcomePage = new Welcome();
                this.NavigationService.Navigate(welcomePage);
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Shopping_List shoppingPage = new Shopping_List();
            this.NavigationService.Navigate(shoppingPage);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Profile profilePage = new Profile();
            this.NavigationService.Navigate(profilePage);
        }

        private void ImageButton_Click2(object sender, RoutedEventArgs e)
        {
            Shopping_List shoppingPage = new Shopping_List();
            this.NavigationService.Navigate(shoppingPage);
        }

        private void ImageButton_Click1(object sender, RoutedEventArgs e)
        {
            Profile profilePage = new Profile();
            this.NavigationService.Navigate(profilePage);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MyLadder(object sender, MouseButtonEventArgs e)
        {
            MyLadder myLadder = new MyLadder();
            this.NavigationService.Navigate(myLadder);
        }

        private void MiguelLadder(object sender, MouseButtonEventArgs e)
        {
            MiguelLarder miguel = new MiguelLarder();
            this.NavigationService.Navigate(miguel);
        }
    }
}
