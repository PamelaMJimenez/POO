using pMunoz_Lab2.Formularios;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace pmunoz_Lab3.Formularios
{
    /// <summary>
    /// Lógica de interacción para Bienvenida.xaml
    /// </summary>
    public partial class Bienvenida : Window
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Usuario();

            ventana.ShowDialog();
        }
    }
}
