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
        private ObservableCollection<Comida> _lista;



        public ObservableCollection<Comida> lista
        {
            get { return _lista; }
            set
            {
                _lista = value;
            }
        }
        public MiguelLarder()
        {
            InitializeComponent();
            lista = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Beer", Quantidade = 6 },
                new Comida { Nome = "Onion", Quantidade = 2 },
                new Comida { Nome = "Lettuce", Quantidade = 2 },
                new Comida { Nome = "Tomato", Quantidade = 3 }

            };



            listaAlimentos.ItemsSource = lista;
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



        private void Order_click(object sender, RoutedEventArgs e)
        {
           listaAlimentos.ItemsSource = lista.OrderBy(x => x.Quantidade); 
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Comida comida = new Comida
            {
                Nome = addIngredient.Text,
                Quantidade = int.Parse(ingQuant.Text)
            };
            bool flag = false;
            foreach (Comida c in lista)
            {
                if (comida.Nome == c.Nome)
                {
                    flag = true;
                }

            }
            if (flag == true)
            {
                MessageBox.Show("Item already in larder");
            }
            else
            {
                lista.Add(comida);

            }
            
            listaAlimentos.ItemsSource = lista;
            addIngredient.Clear();
            ingQuant.Clear();



        }



        private void AddQuant(object sender, RoutedEventArgs e)
        {



        }



        private void RemoveQuant(object sender, RoutedEventArgs e)
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