﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MiguelLarder.xaml
    /// </summary>
    public partial class MiguelLarder : Page
    {
        
        public MiguelLarder()
        {
            InitializeComponent();
            listaAlimentos.ItemsSource = Globals.Miguel;
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



        private void Order_click(object sender, RoutedEventArgs e)
        {
            listaAlimentos.ItemsSource = Globals.Miguel.OrderBy(x => x.Quantidade);
            foreach (Comida c in Globals.Miguel)
            {
                c.Estado = 1;
            }
        }

        private void OrderA_click(object sender, RoutedEventArgs e)
        {
            listaAlimentos.ItemsSource = Globals.Miguel.OrderBy(x => x.Nome);
            foreach (Comida c in Globals.Miguel)
            {
                c.Estado = 2;
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (addIngredient.Text == "" || ingQuant.Text == "" || addIngredient.Text == "Add ingredient" || ingQuant.Text == "Quantity" )
            {
                MessageBox.Show("Insert ingredient and a valid quantity", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Comida comida = new Comida
                {
                    Nome = addIngredient.Text,
                    Quantidade = ingQuant.Text.ParseInt(1)
                };
                bool flag = false;
                bool flag1 = false;
                foreach (Comida c in Globals.Miguel)
                {
                    if (String.Equals(comida.Nome, c.Nome, StringComparison.OrdinalIgnoreCase))
                    {
                        flag = true;
                    }
                 
                }
                int n = 0;

                if (!(int.TryParse(ingQuant.Text, out n) && n > 0)) { flag1 = true; }



                if (flag == true)
                {
                    MessageBox.Show("Item already in larder", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Warning);

                }else if (flag1 == true)
                {
                    MessageBox.Show("Quantity has to be a positive Number", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    
                    Globals.Miguel.Add(comida);

                }

                checkState(Globals.Miguel);
                //listaAlimentos.ItemsSource = Globals.My;
                //addIngredient.Clear();
                //ingQuant.Clear();
                addIngredient.Text = "Add ingredient";
                addIngredient.Foreground = new SolidColorBrush(Colors.Gray);
                ingQuant.Text = "Quantity";
                ingQuant.Foreground = new SolidColorBrush(Colors.Gray);

            }
        }

        

        private void removeItem(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("You really want to remove this item?", "LarderManager", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                int i = 0;
                int index = 0;
                foreach (Comida c in Globals.Miguel)
                {
                    if (c.Nome == ((Button)sender).Tag.ToString())
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                Globals.Miguel.RemoveAt(index);
            }
            checkState(Globals.Miguel);
        }


        private void AddQuant(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (Comida c in Globals.Miguel)
            {
                if (c.Nome == ((Button)sender).Tag.ToString())
                {
                    index = i;
                    break;
                }
                i++;
            }
            Globals.Miguel.ElementAt(index).Quantidade++;
            checkState(Globals.Miguel);

        }

        private void RemoveQuant(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (Comida c in Globals.Miguel)
            {
                if (c.Nome == ((Button)sender).Tag.ToString())
                {
                    index = i;
                    break;
                }
                i++;
            }
            Globals.Miguel.ElementAt(index).Quantidade--;
            if (Globals.Miguel.ElementAt(index).Quantidade <= 0)
            {
                MessageBoxResult result = MessageBox.Show("You really want to remove this item?", "LarderManager", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    Globals.Miguel.RemoveAt(index);

                }
                else
                {
                    Globals.Miguel.ElementAt(index).Quantidade = 1;
                }

            }
            checkState(Globals.Miguel);
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
                    listaAlimentos.ItemsSource = lista.OrderBy(x => x.Quantidade);
                    listaAlimentos.ItemsSource = temp;
                }
                else if (lista.ElementAt(0).Estado == 1)
                {
                    listaAlimentos.ItemsSource = lista.OrderBy(x => x.Quantidade);
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



        private void NameText_Enter(object sender, MouseEventArgs e)
        {
            if (addIngredient.Text == "Add ingredient")
            {
                addIngredient.Text = "";
                addIngredient.Foreground = new SolidColorBrush(Colors.Black);
            }
        }



        private void Quant_Text(object sender, MouseEventArgs e)
        {
            if (ingQuant.Text == "Quantity")
            {
                ingQuant.Text = "";
                ingQuant.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        
    }




}