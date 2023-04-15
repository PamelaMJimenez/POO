using pMunoz_Lab3.Clases;
using pmunoz_Lab3.Datos;
using pmunoz_Lab3.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pMunoz_Lab2.Formularios
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Length > 0 && txtClave.Password.ToString().Length > 0)
            {
                clsUsuario usuario = new clsUsuario(txtUsuario.Text, txtClave.Password.ToString());

                //data transfer object DTO que comunica con la base de datos
                dtoUsuario usu = new dtoUsuario();
                if (usu.validarIngreso(usuario) == true)
                {
                    usuarioLogin.usuarioLogueado = txtUsuario.Text;

                    var ventana = new MainWindow();
                    ventana.ShowDialog();
                }
                else
                {
                    MessageBox.Show(" ¡Su usuario o clave son incorrectos! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show(" Debes de completar los campos de Usuario y Clave ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void pwClavePTI(object sender, TextCompositionEventArgs e)
        {
            util.validarNumerosyLetras(e);
        }

        private void txtUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            util.validarSoloLetras(e);
        }
    }
}
