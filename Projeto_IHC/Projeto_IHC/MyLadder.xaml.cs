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
        

        public MyLadder()
        {
            InitializeComponent();
            

            listaAlimentos.ItemsSource = Globals.My;
          



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



        private void shopping_click(object sender, RoutedEventArgs e)
        {
            Shopping_List shoppingPage = new Shopping_List();
            this.NavigationService.Navigate(shoppingPage);
        }



        private void Order_click(object sender, RoutedEventArgs e)
        {

            listaAlimentos.ItemsSource = Globals.My.OrderBy(x => x.Quantidade);
            foreach (Comida c in Globals.My)
            {
                c.Estado = 1;
            }
        }

        private void OrderA_click(object sender, RoutedEventArgs e)
        {
            listaAlimentos.ItemsSource = Globals.My.OrderBy(x => x.Nome);
            foreach (Comida c in Globals.My)
            {
                c.Estado = 2;
            }
        }


        



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (addIngredient.Text == "" || ingQuant.Text == "" || addIngredient.Text == "Add ingredient" || ingQuant.Text == "")
            {
                MessageBox.Show("Insert ingredient and quantity", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Comida comida = new Comida
                {
                    Nome = addIngredient.Text,
                    Quantidade = ingQuant.Text.ParseInt(1),
                    Estado = 0
                    
                };


                bool flag = false;
                foreach (Comida c in Globals.My)
                {
                    if (String.Equals(comida.Nome, c.Nome, StringComparison.OrdinalIgnoreCase))
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
                    Globals.My.Add(comida);
                    

                }
                checkState(Globals.My);
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
                foreach (Comida c in Globals.My)
                {
                    if (c.Nome == ((Button)sender).Tag.ToString())
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                Globals.My.RemoveAt(index);
            }
            checkState(Globals.My);
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
                    listaAlimentos.ItemsSource =  lista.OrderBy(x => x.Quantidade);
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

        private void AddQuant(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (Comida c in Globals.My)
            {
                if (c.Nome == ((Button)sender).Tag.ToString())
                {
                    index = i;
                    break;
                }
                i++;
            }
            Globals.My.ElementAt(index).Quantidade++;
            checkState(Globals.My);
            
        }

        private void RemoveQuant(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (Comida c in Globals.My)
            {
                if (c.Nome == ((Button)sender).Tag.ToString())
                {
                    index = i;
                    break;
                }
                i++;
            }
            Globals.My.ElementAt(index).Quantidade--;
            if (Globals.My.ElementAt(index).Quantidade <= 0)
            {
                Globals.My.RemoveAt(index);
            }
            checkState(Globals.My);
        }

        private void AddToSP(object sender, RoutedEventArgs e)
        {
            Comida ad = new Comida();
            foreach (Comida c in Globals.My)
            {
                if (c.Nome == ((Button)sender).Tag.ToString())
                {
                    foreach (Comida d in Globals.Shopping)
                    {
                        if (d.Nome == ((Button)sender).Tag.ToString())
                        {
                            MessageBox.Show("Item already in Shopping List", "LarderManager", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else
                        {

                            ad = c;
                            Globals.Shopping.Add(ad);
                            MessageBox.Show("Item added to Shopping List", "Lardermanager", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }


                }
                
            }
            //Globals.Shopping.Add(ad);
            //MessageBox.Show("Item added to Shopping List","Lardermanager",MessageBoxButton.OK,MessageBoxImage.Information);
            
        }

        
    }



    public class Comida
    {
        private string _nome;
        private int _quantidade;
        private int _estado;


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

        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        //0 -> desordenado/default
        //1 -> ordenado ascendente
        //2 -> ordenado alfabeticamente
    }

    public static class IntegerExtensios
    {
        public static int ParseInt(this string value, int defaultIntValue = 0)
        {
            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

}



    public class TextSearchFilter {
        public TextSearchFilter(
            ICollectionView filteredView,
            TextBox textBox
        )
        {
            string filterText = "";

            filteredView.Filter = delegate (object obj)
            {
                if (String.IsNullOrEmpty(filterText))
                    return true;
                string str = obj as string;
                if (String.IsNullOrEmpty(str))
                    return false;
                int index = str.IndexOf(
                    filterText,
                    0,
                    StringComparison.InvariantCultureIgnoreCase);
                return index > -1;
            };

            textBox.TextChanged += delegate
            {
                filterText = textBox.Text;
                filteredView.Refresh();
            };
        
        }
    }


    //public class SearchAndSelectViewModel{

    //        private ICollectionView products;

    //        private Comida selectedProduct;

 

    //    public SearchAndSelectViewModel()

    //    {

    //    var myProducts = (Globals.My);
    //    this.products = CollectionViewSource.GetDefaultView(myProducts);

    //    }



    //    public ICollectionView Products

    //    {
    //        get
    //        {

    //            return this.products;

    //        }

    //    }

    //    public Comida SelectedProduct

    //    {

    //        get

    //        {

    //            return this.selectedProduct;

    //        }

    //        set

    //        {

    //            if (this.selectedProduct != value)

    //            {

    //                this.selectedProduct = value;
    //            }

    //        }

    //    }

    //}


}
