using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Shopping_List.xaml
    /// </summary>
    public partial class Shopping_List : Page
    {

        private ObservableCollection<Alimento> _lista1;

        public ObservableCollection<Alimento> lista1
        {

            get { return _lista1; }
            set
            {
                _lista1 = value;
            }
        }

        public Shopping_List()
        {
            InitializeComponent();
       
            lista1 = new ObservableCollection<Alimento>()
            {
                new Alimento { Nome = "Cream"},
                new Alimento { Nome = "Onion"},
                new Alimento { Nome = "Milk"},
                new Alimento { Nome = "Steak"},
                new Alimento { Nome = "Tomato"},
                new Alimento { Nome = "Garlic"}
            };
            listaAlimentos.ItemsSource = lista1;
           

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
                foreach (Alimento c in lista1)
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
                    lista1.Add(comida);
                }

                addIngredient.Clear();
                //ingQuant.Clear();
            }



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
            Alimento item = (Alimento) listaAlimentos.SelectedItem;
            lista1.Remove(item);
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
        //private int _quantidade;

        public string Nome
        {

            get { return _nome; }
            set { _nome = value; }
        }

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

