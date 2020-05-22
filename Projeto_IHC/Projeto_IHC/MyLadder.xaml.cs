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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shopping_click(object sender, RoutedEventArgs e)
        {

        }

        private void order_click(object sender, RoutedEventArgs e)
        {

        }

        private void AddQuant(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveQuant(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Comida {
        private string _nome;
        private int _quantidade;

        public string Nome {
            get { return _nome; }
            set { _nome = value;}
        }

        public int Quantidade {

            get { return _quantidade; }
            set { _quantidade = value;
                
            }
        }

    }




    public class ListaAlimentos : ObservableCollection<Comida> {

        
        public ListaAlimentos() {
            Add(new Comida { Nome = "Onion", Quantidade = 1 });
            Add(new Comida { Nome = "Milk", Quantidade = 2 });
            Add(new Comida { Nome = "Tomato", Quantidade = 2 });
            Add(new Comida { Nome = "Steak", Quantidade = 4 });
            Add(new Comida { Nome = "Cream", Quantidade = 6 });
            Add(new Comida { Nome = "Garlic", Quantidade = 6 });
        }

        public void additem(string nome)
        {
            Add(new Comida { Nome = nome, Quantidade = 1 });
        }

        public void upquant(Comida c)
        {
            c.Quantidade++;
        }

        public void downquant(Comida c)
        {
            c.Quantidade--;
        }


    }

}
