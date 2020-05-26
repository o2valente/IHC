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
            foreach (Alimento a in Globals.Shopping)
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
                Alimento comida = new Alimento
                {
                    Nome = addIngredient.Text,
                    // Quantidade = int.Parse(ingQuant.Text)
                };
                bool flag = false;
                foreach (Alimento c in Globals.Shopping)
                {
                    if (c.Nome == comida.Nome)
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

        private void checkState(ObservableCollection<Alimento> lista)
        {
            if (lista.Count > 0)
            {
                
                if (lista.ElementAt(0).Estado == 2)
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
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("No entries in back navigation history.", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            MessageBoxResult result = MessageBox.Show("You really want to remove this item?","LarderManager",MessageBoxButton.YesNo,MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                Alimento item = (Alimento)listaAlimentos.SelectedItem;
                Globals.Shopping.Remove(item);
            }
            checkState(Globals.Shopping);
            listaAlimentos.UnselectAll();
            listaAlimentos.SelectionChanged += listaAlimentos_SelectionChanged_1;
            
        }

        private void larder_click(object sender, RoutedEventArgs e)
        {
            MyLadder larderPage = new MyLadder();
            this.NavigationService.Navigate(larderPage);
        }

        //private void desaparecer(object sender, RoutedEventArgs e)
        //{


        //    Button b = (Button)sender;
        //    StackPanel p = (StackPanel)b.Parent;
        //    int index = p.Children.IndexOf(b);


        //    lista1.Remove(lista1.ElementAt(index));


        //}
    }

    public class Alimento
    {
        private string _nome;
        private int _estado;
        //private int _quantidade;

        public string Nome
        {

            get { return _nome; }
            set { _nome = value; }
        }

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        //0 -> desordenado/default
        //1 -> ordenado ascendente
        //2 -> ordenado alfabeticamente



        //public int Quantidade
        //{

        //    get { return _quantidade; }
        //    set
        //    {
        //        _quantidade = value;

        //    }
        //}


    }

}

