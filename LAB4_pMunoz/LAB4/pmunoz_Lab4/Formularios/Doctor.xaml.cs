using pmunoz_Lab3.Datos;
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
using pmunoz_Lab3.Utilidades;

namespace pMunoz_Lab2.Formularios
{
    /// <summary>
    /// Lógica de interacción para Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        public Doctor()
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
            if (txtCodigo.Text.Length > 0 && txtCedula.Text.Length > 0 && txtNombre.Text.Length > 0)
            {
                dtoDoctor doc = new dtoDoctor();
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtCedula.Text.Length <= 15 && txtNombre.Text.Length <= 200)
                    {
                        clsDoctor doctor = new clsDoctor(Convert.ToInt32(txtCodigo.Text), txtNombre.Text,
                                                    Convert.ToInt32(txtCedula.Text), usuarioLogin.usuarioLogueado,
                                                    DateTime.Now);
                        if (doc.insertarDoctor(doctor) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        // Para limpiar los campos.
                        txtCodigo.Text = "";
                        txtCedula.Text = "";
                        txtNombre.Text = "";
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
                    if (txtCedula.Text.Length <= 15 && txtNombre.Text.Length <= 200)
                    {
                        clsDoctor doctorM = new clsDoctor(0, Convert.ToInt32(txtCodigo.Text), Convert.ToInt32(txtCedula.Text),
                                                     txtNombre.Text, usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (doc.modificarDoctor(doctorM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        // Para limpiar los campos.
                        txtCodigo.Text = "";
                        txtCedula.Text = "";
                        txtNombre.Text = "";
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
            dtoDoctor doc = new dtoDoctor();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = txtCedula.Text;
                clsDoctor doctor = new clsDoctor();
                doctor.Cedula = Convert.ToInt32(txtCedula.Text);
                doc.consultaPorId(txtCodigo, txtNombre, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, doctor);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCodigo.Text = "";
            txtCedula.Text = "";
            txtNombre.Text = "";
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
