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
    /// Lógica de interacción para Alergias.xaml
    /// </summary>
    public partial class Alergias : Window
    {
        public Alergias()
        {
            InitializeComponent();
            cargarClientes();
            txtUsuarioC.Text = usuarioLogin.usuarioLogueado;
        }

        public void cargarClientes()
        {
            dtoAlergias alergias = new dtoAlergias();
            alergias.consultarClientes(cmbClientes);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClientes.SelectedItem != null && txtAlergia.Text.Length > 0)
            {
                dtoAlergias aler = new dtoAlergias();
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtAlergia.Text.Length <= 200)
                    {
                        clsAlergias alergias = new clsAlergias(Convert.ToInt32(cmbClientes.Text), txtAlergia.Text, usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (aler.insertarAlergias(alergias) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        cmbClientes.SelectedIndex = 0;
                        txtAlergia.Text = "";
                        txtIdentificacionC.Text = "";
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
                    if (txtAlergia.Text.Length <= 200)
                    {
                        clsAlergias alergiaM = new clsAlergias(0, Convert.ToInt32(cmbClientes.Text), txtAlergia.Text,
                                                           usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (aler.modificarAlergia(alergiaM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        cmbClientes.SelectedIndex = 0;
                        txtAlergia.Text = "";
                        txtIdentificacionC.Text = "";
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
            dtoAlergias alergias = new dtoAlergias();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = Convert.ToString(cmbClientes.Text);
                clsAlergias alerg = new clsAlergias();
                alerg.IdCliente = Convert.ToInt32(cmbClientes.Text);
                alergias.consultaPorId(txtAlergia, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, alerg);
            }   
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbClientes.SelectedIndex = 0;
            txtAlergia.Text = "";
            txtIdentificacionC.Text = "";
            txtModo.Text = "";
            txtAdicionado.Text = "";
            txtFechaAdicion.Text = "";
            txtModificado.Text = "";
            txtFechaModificacion.Text = "";
            rbtConsultar.IsChecked = false;
            rbtInsertar.IsChecked = false;
            rbtModificar.IsChecked = false;
        }

        private void cmbClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            variablesGlobales.guardarI = cmbClientes.SelectedValue.ToString();
            dtoAlergias alergias = new dtoAlergias();
            alergias.consultarCedCliente(txtIdentificacionC, variablesGlobales.guardarI);
        }
    }
}
