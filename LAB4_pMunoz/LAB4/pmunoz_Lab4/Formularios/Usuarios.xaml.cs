using pmunoz_Lab3.Datos;
using pmunoz_Lab3.Utilidades;
using pMunoz_Lab3.Clases;
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
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        public Usuarios()
        {
            InitializeComponent();
            txtUsuarioC.Text = usuarioLogin.usuarioLogueado;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string estado;

            if (chkEstado.IsChecked == true)
            {
                estado = "A";
            }
            else
            {
                estado = "I";
            }

            if (txtUsuario.Text.Length > 0 && txtClave.Text.Length > 0)
            {
                dtoUsuario usu = new dtoUsuario();
                // Para guardar
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtUsuario.Text.Length <= 15 && txtClave.Text.Length <= 10)
                    {
                        clsUsuario usuario = new clsUsuario(txtUsuario.Text, txtClave.Text,
                                                    estado, usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (usu.guardarUsuario(usuario) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Datos incorrectos!");
                        }

                        txtUsuario.Text = "";
                        txtClave.Text = "";
                        chkEstado.IsChecked = false;
                        txtAdicionado.Text = "";
                        txtFechaAdicion.Text = "";
                        txtModificado.Text = "";
                        txtFechaModificacion.Text = "";
                        rbtConsultar.IsChecked = false;
                        rbtInsertar.IsChecked = false;
                        rbtModificar.IsChecked = false;
                    }
                    else
                    {
                        MessageBox.Show(" Excediste el número de caracteres permitidos ", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                }

                // Para modificar
                if (rbtModificar.IsChecked == true)
                {
                    if (txtUsuario.Text.Length <= 15 && txtClave.Text.Length <= 10)
                    {
                        clsUsuario usuarioM = new clsUsuario(0, txtUsuario.Text, txtClave.Text,
                                                    estado, usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (usu.modificarUsuario(usuarioM, guardarUsuario.guardarUsu) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        // Para limpiar los campos.
                        txtUsuario.Text = "";
                        txtClave.Text = "";
                        chkEstado.IsChecked = false;
                        txtAdicionado.Text = "";
                        txtFechaAdicion.Text = "";
                        txtModificado.Text = "";
                        txtFechaModificacion.Text = "";
                        rbtConsultar.IsChecked = false;
                        rbtInsertar.IsChecked = false;
                        rbtModificar.IsChecked = false;
                    }
                    else
                    {
                        MessageBox.Show(" Excediste el número de caracteres permitidos ", "ALERTA", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show(" Debes de completar todos los campos ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtModo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbtConsultar_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtConsultar.IsPressed)
            {
                txtModo.Text = "Consultar";
            }
        }

        private void rbtInsertar_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtInsertar.IsPressed)
            {
                txtModo.Text = "Insertar";
            }
        }

        private void rbtModificar_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtModificar.IsPressed)
            {
                txtModo.Text = "Modificar";
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtoUsuario usuario = new dtoUsuario();
            if (rbtConsultar.IsChecked == true)
            {
                guardarUsuario.guardarUsu = txtUsuario.Text;
                clsUsuario usu = new clsUsuario();
                usu.Usuario = txtUsuario.Text;
                usuario.consultarUsuario(txtClave, chkEstado, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, usu);
            }
        }

        private void txtUsuario_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            util.validarSoloLetras(e);
        }

        private void txtClave_pti(object sender, TextCompositionEventArgs e)
        {
            util.validarNumerosyLetras(e);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
            chkEstado.IsChecked = false;
            txtAdicionado.Text = "";
            txtFechaAdicion.Text = "";
            txtModificado.Text = "";
            txtFechaModificacion.Text = "";
            rbtConsultar.IsChecked = false;
            rbtInsertar.IsChecked = false;
            rbtModificar.IsChecked = false;
        }
    }
}
