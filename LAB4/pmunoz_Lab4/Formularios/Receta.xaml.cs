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
    /// Lógica de interacción para Receta.xaml
    /// </summary>
    public partial class Receta : Window
    {
        public Receta()
        {
            InitializeComponent();
            txtUsuarioC.Text = usuarioLogin.usuarioLogueado;
            consultarHojasClinicas();
        }

        public void consultarHojasClinicas()
        {
            dtoReceta receta = new dtoReceta();
            receta.consultarHojasClinicas(cmbHojaC);
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
            if (cmbHojaC.SelectedItem != null && txtDescripcion.Text.Length > 0 && txtDosis.Text.Length > 0)
            {
                dtoReceta receta = new dtoReceta();
                if (rbtInsertar.IsChecked == true)
                {
                    if (txtDescripcion.Text.Length <= 200 && txtDosis.Text.Length <= 100)
                    {
                        clsReceta recetaI = new clsReceta(Convert.ToInt32(cmbHojaC.Text), txtDescripcion.Text, txtDosis.Text,
                                                 usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (receta.insertarRecetas(recetaI) == true)
                        {
                            MessageBox.Show("Datos Guardados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al almacenar los datos!");
                        }

                        // Para limpiar los campos.
                        cmbHojaC.SelectedIndex = 0;
                        txtDescripcion.Text = "";
                        txtDosis.Text = "";
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
                    if (txtDescripcion.Text.Length <= 200 && txtDosis.Text.Length <= 100)
                    {
                        clsReceta recetaM = new clsReceta(0, Convert.ToInt32(cmbHojaC.Text), txtDescripcion.Text, txtDosis.Text,
                                                      usuarioLogin.usuarioLogueado, DateTime.Now);

                        if (receta.modificarReceta(recetaM, guardarId.guardarIdentificación) == true)
                        {
                            MessageBox.Show("Datos Modificados con éxito!");
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar los datos!");
                        }

                        // Para limpiar los campos.
                        cmbHojaC.SelectedIndex = 0;
                        txtDescripcion.Text = "";
                        txtDosis.Text = "";
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
            dtoReceta receta = new dtoReceta();
            if (rbtConsultar.IsChecked == true)
            {
                guardarId.guardarIdentificación = Convert.ToString(cmbHojaC.Text);
                clsReceta rec = new clsReceta();
                rec.IdHojaC = Convert.ToInt32(cmbHojaC.Text);
                receta.consultaPorId(txtDescripcion, txtDosis, txtAdicionado, txtFechaAdicion, txtModificado, txtFechaModificacion, rec);
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbHojaC.SelectedIndex = 0;
            txtDescripcion.Text = "";
            txtDosis.Text = "";
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
