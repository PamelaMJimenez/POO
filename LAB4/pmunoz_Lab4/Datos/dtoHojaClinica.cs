using pMunoz_Lab2.Formularios;
using pmunoz_Lab3.Base_de_Datos;
using pMunoz_Lab3.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pmunoz_Lab3.Datos
{
    public class dtoHojaClinica
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar el registro de las hojas clinicas.
        public bool insertarHojaClinica(clsHojaClinica datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_HOJA_CLINICA VALUES('" + datos.IdDoctor + "', '" + datos.IdCliente + "', '" + datos.FechaAtencion.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + datos.Sintomas + "', '" + datos.Diagnostico + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar la hoja clinica por el identificador del cliente.
        public void consultaPorId(ComboBox cmbDoctor, DatePicker dtpFecAtencion, TextBox txtSintomas, TextBox txtDiagnostico, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsHojaClinica hojC)
        {
            string consulta = "SELECT HOC_ID_DOCTOR, HOC_ID_CLIENTE, HOC_FECHA_ATENCION, HOC_SINTOMAS, HOC_DIAGNOSTICO, HOC_ADICIONADO_POR, HOC_FECHA_ADICION, HOC_MODIFICADO_POR, HOC_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_HOJA_CLINICA WHERE HOC_ID_CLIENTE = '" + hojC.IdCliente + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    cmbDoctor.Text = datos.Rows[i].ItemArray[0].ToString();
                    dtpFecAtencion.Text = datos.Rows[i].ItemArray[2].ToString();
                    txtSintomas.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtDiagnostico.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[5].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[6].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[7].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[8].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ninguna hoja clínica registrada para el cliente con ese identificador! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar la hoja clínica.
        public bool modificarHojaClinica(clsHojaClinica datos, string idAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_HOJA_CLINICA SET HOC_ID_DOCTOR = '" + datos.IdDoctor + "', HOC_ID_CLIENTE = '" + datos.IdCliente + "', HOC_FECHA_ATENCION = '" + datos.FechaAtencion.ToString("yyyy-MM-dd HH:mm:ss") + "', HOC_SINTOMAS = '" + datos.Sintomas + "', HOC_DIAGNOSTICO = '" + datos.Diagnostico + "', HOC_MODIFICADO_POR = '" + datos.ModificadoPor + "', HOC_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE HOC_ID_CLIENTE = '" + idAnterior + "';";
                conn.SQLExecuteCmm(_SQLConnection, actualizar);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar todos los doctores
        public void consultarDoctores(ComboBox cmbDoctores)
        {
            try
            {
                string consulta = "SELECT DOC_ID FROM LABORATORIO.dbo.LAB_DOCTOR;";

                var doctores = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (doctores.Rows.Count > 0)
                {
                    for (int i = 0; i < doctores.Rows.Count; i++)
                    {
                        cmbDoctores.Items.Add(doctores.Rows[i].ItemArray[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Para consultar las identificaciones de los doctores.
        public void consultarCedDoctores(TextBox txtIdentificacionDoc, string idSeleccionado)
        {
            try
            {
                string consulta = "SELECT DOC_ID, DOC_IDENTIFICACION FROM LABORATORIO.dbo.LAB_DOCTOR WHERE DOC_ID = '" + idSeleccionado + "';";

                var doctores = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (doctores.Rows.Count > 0)
                {
                    for (int i = 0; i < doctores.Rows.Count; i++)
                    {
                        txtIdentificacionDoc.Text = doctores.Rows[i].ItemArray[1].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Para consultar todos los clientes.
        public void consultarClientes(ComboBox cmbClientes)
        {
            try
            {
                string consulta = "SELECT CLI_ID FROM LABORATORIO.dbo.LAB_CLIENTES;";

                var clientes = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (clientes.Rows.Count > 0)
                {
                    for (int i = 0; i < clientes.Rows.Count; i++)
                    {
                        cmbClientes.Items.Add(clientes.Rows[i].ItemArray[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Para consultar las identificaciones de los clientes.
        public void consultarCedClientes(TextBox txtIdentificacionCli, string idSeleccionado)
        {
            try
            {
                string consulta = "SELECT CLI_ID, CLI_IDENTIFICACION FROM LABORATORIO.dbo.LAB_CLIENTES WHERE CLI_ID = '" + idSeleccionado + "';";

                var clientes = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (clientes.Rows.Count > 0)
                {
                    for (int i = 0; i < clientes.Rows.Count; i++)
                    {
                        txtIdentificacionCli.Text = clientes.Rows[i].ItemArray[1].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
