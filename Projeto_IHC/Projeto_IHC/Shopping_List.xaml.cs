using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
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
using Projeto_IHC;

namespace Projeto_IHC
{
    /// <summary>
    /// Interaction logic for Shopping_List.xaml
    /// </summary>
    
    public partial class Shopping_List : Page
    {

        
        

        public Shopping_List()
        {
            InitializeComponent();
            
            
            listaAlimentos.ItemsSource = Globals.Shopping;
         
        }
            
   
        private void OrderA_click(object sender, RoutedEventArgs e)
        {
            listaAlimentos.ItemsSource = Globals.Shopping.OrderBy(x => x.Nome);
            foreach (Comida a in Globals.Shopping)
            {
                a.Estado = 2;
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (addIngredient.Text == "")
            {
                MessageBox.Show("No ingredient to add", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Comida comida = new Comida
                {
                    Nome = addIngredient.Text,
                    Quantidade = 0,
                    Estado =0
                };
                bool flag = false;
                foreach (Comida c in Globals.Shopping)
                {
                    if (String.Equals(comida.Nome, c.Nome, StringComparison.OrdinalIgnoreCase))
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    MessageBox.Show("Item already in Shopping List", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Globals.Shopping.Add(comida);
                }
                checkState(Globals.Shopping);
                //listaAlimentos.ItemsSource = Globals.Shopping;
                //addIngredient.Clear();
                addIngredient.Text = "Add ingredient";
                addIngredient.Foreground = new SolidColorBrush(Colors.Gray);
            }



        }

        private void checkState(ObservableCollection<Comida> lista)
        {
            ObservableCollection<Comida> temp;
            if (lista.Count > 0)
            {
                if (lista.ElementAt(0).Estado == 0)
                {
                    // the list needs to be refreshed
                    temp = lista;
                    listaAlimentos.ItemsSource = lista.OrderBy(x => x.Nome);
                    listaAlimentos.ItemsSource = temp;
                }
                else if (lista.ElementAt(0).Estado == 2)
                {
                    listaAlimentos.ItemsSource = lista.OrderBy(x => x.Nome);
                }
                else
                {
                    bye();
                }
            }

        }

        private void bye()
        {

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



        private void NameText_Enter(object sender, MouseEventArgs e)
        {
            if (addIngredient.Text == "Add ingredient")
            {
                addIngredient.Text = "";
                addIngredient.Foreground = new SolidColorBrush(Colors.Black);
            }
        }




        private void listaAlimentos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //First and last line needed cause otherwise messagebox runs twice
            listaAlimentos.SelectionChanged -= listaAlimentos_SelectionChanged_1; 
            listaAlimentos.UnselectAll();
            listaAlimentos.SelectionChanged += listaAlimentos_SelectionChanged_1;
            
        }

        private void desaparecer(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You really want to remove this item?", "LarderManager", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                int i = 0;
                int index = 0;
                foreach (Comida c in Globals.Shopping)
                {
                    if (c.Nome == ((Button)sender).Tag.ToString())
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                Globals.Shopping.RemoveAt(index);
                checkState(Globals.Shopping);
      
            }
            
        }

        private void larder_click(object sender, RoutedEventArgs e)
        {
            MyLadder larderPage = new MyLadder();
            this.NavigationService.Navigate(larderPage);
        }

        
    }

    
}

