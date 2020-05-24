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
    /// Interaction logic for Add_Member.xaml
    /// </summary>
    public partial class Add_Member : Page
    {
        public Add_Member()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.");
            }
        }

        private void NameText_Enter(object sender, MouseEventArgs e)
        {
            if (user_member.Text == "Member username")
            {
                user_member.Text = "";
                user_member.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (user_member.Text == "")
            {
                MessageBox.Show("Insert a username");
            }
            else
            {
                MessageBox.Show("Invite sent to user");
                this.NavigationService.GoBack();
            }
        }

        
    }
}
