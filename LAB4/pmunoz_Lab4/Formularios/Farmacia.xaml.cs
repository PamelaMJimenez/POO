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

namespace pMunoz_Lab2.Formularios
{
    /// <summary>
    /// Lógica de interacción para Farmacia.xaml
    /// </summary>
    public partial class Farmacia : Window
    {
        public Farmacia()
        {
            InitializeComponent();
            txtUsuarioC.Text = usuarioLogin.usuarioLogueado;
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

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCedJuridica.Text.Length > 0 && txtNombre.Text.Length > 0 && txtTelefono.Text.Length > 0 &&
                txtCorreo.Text.Length > 0)
            {
                dtoFarmacia farmacia = new dtoFarmacia();

                if (rbtInsertar.IsChecked == true)
                {
                    if (txtCedJuridica.Text.Length <= 25 && txtNombre.Text.Length <= 100 && txtTelefono.Text.Length <= 9 && txtCorreo.Text.Length <= 150)
                    {
                        clsFarmacia farmaciaI = new clsFarmacia(txtCedJuridica.Text, txtNombre.Text, txtTelefono.Text, txtCorreo.Text,
                                                       usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (farmacia.insertarFarmacia(farmaciaI) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        // Para limpiar los campos.
                        txtCedJuridica.Text = "";
                        txtNombre.Text = "";
                        txtTelefono.Text = "";
                        txtCorreo.Text = "";
                        txtModo.Text = "";
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

                if (rbtModificar.IsChecked == true)
                {
                    if (txtCedJuridica.Text.Length <= 25 && txtNombre.Text.Length <= 100 && txtTelefono.Text.Length <= 9 && txtCorreo.Text.Length <= 150)
                    {
                        clsFarmacia farmaciaM = new clsFarmacia(0, txtCedJuridica.Text, txtNombre.Text, txtTelefono.Text, txtCorreo.Text,
                                                                usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (farmacia.modificarFarmacia(farmaciaM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        // Para limpiar los campos.
                        txtCedJuridica.Text = "";
                        txtNombre.Text = "";
                        txtTelefono.Text = "";
                        txtCorreo.Text = "";
                        txtModo.Text = "";
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dtoFarmacia farmacia = new dtoFarmacia();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = txtCedJuridica.Text;
                clsFarmacia far = new clsFarmacia();
                far.CedulaJuridica = txtCedJuridica.Text;
                farmacia.consultaPorId(txtNombre, txtTelefono, txtCorreo, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, far);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCedJuridica.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtModo.Text = "";
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
