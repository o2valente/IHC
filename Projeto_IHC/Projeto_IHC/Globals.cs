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
        private static ObservableCollection<Comida> _Shopping;
        public static ObservableCollection<Comida> Shopping
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

        public static User user;
        

        public static void InnitLists()
        {
            Shopping = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Cream",Quantidade=0, Estado=0},
                new Comida { Nome = "Onion",Quantidade=0, Estado=0},
                new Comida { Nome = "Milk",Quantidade=0, Estado=0},
                new Comida { Nome = "Steak",Quantidade=0, Estado=0},
                new Comida { Nome = "Tomato",Quantidade=0, Estado=0},
                new Comida { Nome = "Garlic",Quantidade=0, Estado=0}
            };

            Miguel = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Beer", Quantidade = 6, Estado=0 },
                new Comida { Nome = "Onion", Quantidade = 2, Estado=0 },
                new Comida { Nome = "Lettuce", Quantidade = 2, Estado=0 },
                new Comida { Nome = "Tomato", Quantidade = 3, Estado=0 }

            };

            My = new ObservableCollection<Comida>()
            {
                new Comida { Nome = "Cream", Quantidade = 6, Estado=0 },
                new Comida { Nome = "Onion", Quantidade = 1, Estado=0 },
                new Comida { Nome = "Milk", Quantidade = 2, Estado=0 },
                new Comida { Nome = "Steak", Quantidade = 4, Estado=0 },
                new Comida { Nome = "Tomato", Quantidade = 2, Estado=0 },
                new Comida { Nome = "Garlic", Quantidade = 6, Estado=0 }
            };

            user = new User
            {
                Nome = null,
                Date = "01/01/1999",
                Location = "Aveiro"

            };
        }

        
    }
}
