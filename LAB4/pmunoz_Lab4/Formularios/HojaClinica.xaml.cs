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
    /// Lógica de interacción para HojaClinica.xaml
    /// </summary>
    public partial class HojaClinica : Window
    {
        public HojaClinica()
        {
            InitializeComponent();
            txtUsuarioC.Text = usuarioLogin.usuarioLogueado;
            consultarDoctores();
            consultarClientes();
        }

        public void consultarDoctores()
        {
            dtoHojaClinica hojaC = new dtoHojaClinica();
            hojaC.consultarDoctores(cmbDoctor);
        }

        public void consultarClientes()
        {
            dtoHojaClinica hojaC = new dtoHojaClinica();
            hojaC.consultarClientes(cmbCliente);
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
            if (cmbDoctor.SelectedItem != null && cmbCliente.SelectedItem != null && dtpFecAtencion.SelectedDate != null &&
                txtSintomas.Text.Length > 0 && txtDiagnostico.Text.Length > 0)
            {
                dtoHojaClinica hojaC = new dtoHojaClinica();
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtSintomas.Text.Length <= 250 && txtDiagnostico.Text.Length <= 250)
                    {
                        clsHojaClinica hojaClinica = new clsHojaClinica(Convert.ToInt32(cmbDoctor.Text), Convert.ToInt32(cmbCliente.Text),
                                                                Convert.ToDateTime(dtpFecAtencion.Text), txtSintomas.Text, txtDiagnostico.Text,
                                                                usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (hojaC.insertarHojaClinica(hojaClinica) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        // Para limpiar los campos.
                        cmbDoctor.SelectedIndex = 0;
                        cmbCliente.SelectedIndex = 0;
                        dtpFecAtencion.SelectedDate = null;
                        txtSintomas.Text = "";
                        txtDiagnostico.Text = "";
                        txtIdentificacionDoc.Text = "";
                        txtIdentificacionCli.Text = "";
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
                    if (txtSintomas.Text.Length <= 250 && txtDiagnostico.Text.Length <= 250)
                    {
                        clsHojaClinica hojaClinicaM = new clsHojaClinica(0, Convert.ToInt32(cmbDoctor.Text), Convert.ToInt32(cmbCliente.Text),
                                                                    Convert.ToDateTime(dtpFecAtencion.Text), txtSintomas.Text, txtDiagnostico.Text,
                                                                    usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (hojaC.modificarHojaClinica(hojaClinicaM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        // Para limpiar los campos.
                        cmbDoctor.SelectedIndex = 0;
                        cmbCliente.SelectedIndex = 0;
                        dtpFecAtencion.SelectedDate = null;
                        txtSintomas.Text = "";
                        txtDiagnostico.Text = "";
                        txtIdentificacionDoc.Text = "";
                        txtIdentificacionCli.Text = "";
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
            dtoHojaClinica hojaC = new dtoHojaClinica();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = Convert.ToString(cmbCliente.Text);
                clsHojaClinica hojaClinica = new clsHojaClinica();
                hojaClinica.IdCliente = Convert.ToInt32(cmbCliente.Text);
                hojaC.consultaPorId(cmbDoctor, dtpFecAtencion, txtSintomas, txtDiagnostico, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, hojaClinica);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbDoctor.SelectedIndex = 0;
            cmbCliente.SelectedIndex = 0;
            dtpFecAtencion.SelectedDate = null;
            txtSintomas.Text = "";
            txtDiagnostico.Text = "";
            txtIdentificacionDoc.Text = "";
            txtIdentificacionCli.Text = "";
            txtModo.Text = "";
            txtAdicionado.Text = "";
            txtFechaAdicion.Text = "";
            txtModificado.Text = "";
            txtFechaModificacion.Text = "";
            rbtConsultar.IsChecked = false;
            rbtInsertar.IsChecked = false;
            rbtModificar.IsChecked = false;
        }

        private void cmbDoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            variablesGlobales.guardarI = cmbDoctor.SelectedValue.ToString();
            dtoHojaClinica hoja = new dtoHojaClinica();
            hoja.consultarCedDoctores(txtIdentificacionDoc, variablesGlobales.guardarI);
        }

        private void cmbCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            variablesGlobales.guardarI = cmbCliente.SelectedValue.ToString();
            dtoHojaClinica hoja = new dtoHojaClinica();
            hoja.consultarCedClientes(txtIdentificacionCli, variablesGlobales.guardarI);
        }
    }
}
