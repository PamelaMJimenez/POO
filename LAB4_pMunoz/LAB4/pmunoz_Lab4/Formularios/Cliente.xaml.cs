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
    /// Lógica de interacción para Cliente.xaml
    /// </summary>
    public partial class Cliente : Window
    {
        public Cliente()
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

            if (cmbTipoId.SelectedItem != null && txtId.Text.Length > 0 && txtPNombre.Text.Length > 0 && txtSNombre.Text.Length > 0
                && txtPApellido.Text.Length > 0 && txtSApellido.Text.Length > 0 && dtpFecNacimiento.SelectedDate != null
                && txtPeso.Text.Length > 0 && cmbSexo.SelectedItem != null && txtCelular.Text.Length > 0 && txtCorreo.Text.Length > 0)
            {

                dtoCliente cli = new dtoCliente();
                // Para insertar clientes.
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtId.Text.Length <= 15 && txtPNombre.Text.Length <= 25 && txtSNombre.Text.Length <= 25 && txtPApellido.Text.Length <= 25 && txtSApellido.Text.Length <= 25
                        && txtCelular.Text.Length <= 8 && txtCorreo.Text.Length <= 150)
                    {
                        clsCliente cliente = new clsCliente(Convert.ToString(cmbTipoId.Text), txtId.Text, txtPNombre.Text, txtSNombre.Text,
                                                   txtPApellido.Text, txtSApellido.Text, dtpFecNacimiento.SelectedDate.Value.Date,
                                                   Decimal.Parse(txtPeso.Text), Convert.ToString(cmbSexo.Text), txtCelular.Text, txtCorreo.Text,
                                                   usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (cli.insertarClientes(cliente) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        // Para limpiar los campos.
                        cmbTipoId.SelectedIndex = 5;
                        txtId.Text = "";
                        txtPNombre.Text = "";
                        txtSNombre.Text = "";
                        txtPApellido.Text = "";
                        txtSApellido.Text = "";
                        dtpFecNacimiento.SelectedDate = null;
                        txtPeso.Text = "";
                        cmbSexo.SelectedIndex = 0;
                        txtCorreo.Text = "";
                        txtCelular.Text = "";
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

                // Para modificar la información de Clientes.

                if (rbtModificar.IsChecked == true)
                {
                    if (txtId.Text.Length <= 15 && txtPNombre.Text.Length <= 25 && txtSNombre.Text.Length <= 25 && txtPApellido.Text.Length <= 25 && txtSApellido.Text.Length <= 25
                        && txtCelular.Text.Length <= 8 && txtCorreo.Text.Length <= 150)
                    {
                        clsCliente clienteM = new clsCliente(0, Convert.ToString(cmbTipoId.Text), txtId.Text, txtPNombre.Text, txtSNombre.Text,
                                                   txtPApellido.Text, txtSApellido.Text, dtpFecNacimiento.SelectedDate.Value.Date,
                                                   Decimal.Parse(txtPeso.Text), Convert.ToString(cmbSexo.Text), txtCelular.Text, txtCorreo.Text,
                                                   usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (cli.modificarCliente(clienteM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }
                    }

                    // Para limpiar los campos.
                    cmbTipoId.SelectedIndex = 5;
                    txtId.Text = "";
                    txtPNombre.Text = "";
                    txtSNombre.Text = "";
                    txtPApellido.Text = "";
                    txtSApellido.Text = "";
                    dtpFecNacimiento.SelectedDate = null;
                    txtPeso.Text = "";
                    cmbSexo.SelectedIndex = 0;
                    txtCorreo.Text = "";
                    txtCelular.Text = "";
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
            dtoCliente cliente = new dtoCliente();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = txtId.Text;
                clsCliente cli1 = new clsCliente();
                cli1.NumIdentificacion = txtId.Text;
                cliente.consultaPorId(cmbTipoId, txtPNombre, txtSNombre, txtPApellido, txtSApellido, dtpFecNacimiento, txtPeso, cmbSexo, txtCelular, txtCorreo, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, cli1);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbTipoId.SelectedIndex = 5;
            txtId.Text = "";
            txtPNombre.Text = "";
            txtSNombre.Text = "";
            txtPApellido.Text = "";
            txtSApellido.Text = "";
            dtpFecNacimiento.SelectedDate = null;
            txtPeso.Text = "";
            cmbSexo.SelectedIndex = 0;
            txtCorreo.Text = "";
            txtCelular.Text = "";
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
