using pMunoz_Lab2.Formularios;
using pmunoz_Lab3.Formularios;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pMunoz_Lab2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Cliente();

            ventana.ShowDialog();
        }

        private void btnAlergias_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Alergias();

            ventana.ShowDialog();
        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Doctor();

            ventana.ShowDialog();
        }

        private void btnHojaClinica_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new HojaClinica();

            ventana.ShowDialog();
        }

        private void btnReceta_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Receta();

            ventana.ShowDialog();
        }

        private void btnFarmacia_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Farmacia();

            ventana.ShowDialog();
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new Usuarios();

            ventana.ShowDialog();
        }
    }
}
