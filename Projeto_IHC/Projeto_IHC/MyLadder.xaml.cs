using System;
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
using System.ComponentModel;
using System.Collections;



namespace Projeto_IHC
{
    /// <summary>
    /// Interaction logic for MyLadder.xaml
    /// </summary>
    public partial class MyLadder : Page
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

        public MyLadder()
        {
            InitializeComponent();
            lista = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Cream", Quantidade = 6 },
                new Comida { Nome = "Onion", Quantidade = 1 },
                new Comida { Nome = "Milk", Quantidade = 2 },
                new Comida { Nome = "Steak", Quantidade = 4 },
                new Comida { Nome = "Tomato", Quantidade = 2 },
                new Comida { Nome = "Garlic", Quantidade = 6 }
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
                MessageBox.Show("No entries in back navigation history.", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void shopping_click(object sender, RoutedEventArgs e)
        {
            Shopping_List shoppingPage = new Shopping_List();
            this.NavigationService.Navigate(shoppingPage);
        }



        private void Order_click(object sender, RoutedEventArgs e)
        {

            listaAlimentos.ItemsSource = lista.OrderBy(x => x.Quantidade); ;

        }




        private void AddQuant(object sender, RoutedEventArgs e)
        {

        }



        private void RemoveQuant(object sender, RoutedEventArgs e)
        {



        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (addIngredient.Text == "" || ingQuant.Text == "")
            {
                MessageBox.Show("Insert ingredient and quantity", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
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
                    MessageBox.Show("Item already in larder", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    lista.Add(comida);

                }

                listaAlimentos.ItemsSource = lista;
                addIngredient.Clear();
                ingQuant.Clear();
            }

        }

        private void listaAlimentos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Comida item = (Comida)listaAlimentos.SelectedItem;
            lista.Remove(item);
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



    public class Comida
    {
        private string _nome;
        private int _quantidade;



        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }



        public int Quantidade
        {



            get { return _quantidade; }
            set
            {
                _quantidade = value;

            }
        }







    }






    //public class ListaAlimentos : ObservableCollection<Comida> {




    //    public ListaAlimentos() 
    //    {
    //        Add(new Comida { Nome = "Onion", Quantidade = 1 });
    //        Add(new Comida { Nome = "Milk", Quantidade = 2 });
    //        Add(new Comida { Nome = "Tomato", Quantidade = 2 });
    //        Add(new Comida { Nome = "Steak", Quantidade = 4 });
    //        Add(new Comida { Nome = "Cream", Quantidade = 6 });
    //        Add(new Comida { Nome = "Garlic", Quantidade = 6 });
    //    }



    //    protected override void InsertItem(int index, Comida item)
    //    {
    //        base.InsertItem(index, item);
    //    }



    //    public void additem(string nome)
    //    {
    //        Add(new Comida { Nome = nome, Quantidade = 1 });
    //    }



    //    public void upquant(Comida c)
    //    {
    //        c.Quantidade++;
    //    }



    //    public void downquant(Comida c)
    //    {
    //        c.Quantidade--;
    //    }




    //}



}
