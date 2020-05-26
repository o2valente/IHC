using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_IHC
{
    public static class Globals
    {
        private static ObservableCollection<Alimento> _Shopping;
        public static ObservableCollection<Alimento> Shopping
        {

            get { return _Shopping; }
            set
            {
                _Shopping = value;
            }
        }

        private static ObservableCollection<Comida> _My;

        public static ObservableCollection<Comida> My
        {
            get { return _My; }
            set
            {
                _My = value;
            }
        }

        private static ObservableCollection<Comida> _Miguel;
        public static ObservableCollection<Comida> Miguel
        {
            get { return _Miguel; }
            set
            {
                _Miguel = value;
            }
        }

        public static void InnitLists()
        {
            Shopping = new ObservableCollection<Alimento>()
            {
                new Alimento { Nome = "Cream"},
                new Alimento { Nome = "Onion"},
                new Alimento { Nome = "Milk"},
                new Alimento { Nome = "Steak"},
                new Alimento { Nome = "Tomato"},
                new Alimento { Nome = "Garlic"}
            };

            Miguel = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Beer", Quantidade = 6 },
                new Comida { Nome = "Onion", Quantidade = 2 },
                new Comida { Nome = "Lettuce", Quantidade = 2 },
                new Comida { Nome = "Tomato", Quantidade = 3 }

            };

            My = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Cream", Quantidade = 6 },
                new Comida { Nome = "Onion", Quantidade = 1 },
                new Comida { Nome = "Milk", Quantidade = 2 },
                new Comida { Nome = "Steak", Quantidade = 4 },
                new Comida { Nome = "Tomato", Quantidade = 2 },
                new Comida { Nome = "Garlic", Quantidade = 6 }
            };
        }

        
    }
}
