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

namespace DETI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class DETI_Home : Page
    {
        public DETI_Home()
        {
            InitializeComponent();
            
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            
            
            String curso = ((Curso)cursosListBox.SelectedValue).Nome;
            DETI_Cursos cursosPage = new DETI_Cursos();

            if (curso == null)
            {
                MessageBox.Show("Selecione um curso", "Erro", MessageBoxButton.OK);
                return;
            }
            cursosPage.labelDisciplina.Content = curso;
            this.NavigationService.Navigate(cursosPage);

            
        }
    }

    public class Curso
    {
        private string _nome; private int _CodCurso;

        public int CodCurso { get { return _CodCurso; } set { _CodCurso = value; } }

        public string Nome { get { return _nome; } set { _nome = value; } }

       
    }

    public class ListaCursos : ObservableCollection<Curso> 
    { 
        public ListaCursos() 
        { 
            Add(new Curso { Nome = "Computadores e Telemática", CodCurso = 8240 }); 
            Add(new Curso { Nome = "Electrónica e Telecomunicações", CodCurso = 8204 }); 
            Add(new Curso { Nome = "Engenharia Informática", CodCurso = 8295, }); 
        } 
    }

}
