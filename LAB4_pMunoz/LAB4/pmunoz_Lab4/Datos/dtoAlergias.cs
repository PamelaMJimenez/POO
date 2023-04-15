using pmunoz_Lab3.Base_de_Datos;
using pMunoz_Lab3.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace pmunoz_Lab3.Datos
{
    public class dtoAlergias
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar el registro de las alergias.
        public bool insertarAlergias(clsAlergias datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_ALERGIAS VALUES('" + datos.IdCliente + "', '" + datos.Alergia + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar la alergia por el identificador del cliente.
        public void consultaPorId(TextBox txtAlergia, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsAlergias alergia)
        {
            string consulta = "SELECT ALE_ID_CLIENTE, ALE_ALERGIAS, ALE_ADICIONADO_POR, ALE_FECHA_ADICION, ALE_MODIFICADO_POR, ALE_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_ALERGIAS WHERE ALE_ID_CLIENTE = '" + alergia.IdCliente + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    txtAlergia.Text = datos.Rows[i].ItemArray[1].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[2].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[5].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ninguna alergia registrada para el cliente con ese identificador! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar la alergia.
        public bool modificarAlergia(clsAlergias datos, string idAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_ALERGIAS SET ALE_ID_CLIENTE = '" + datos.IdCliente + "', ALE_ALERGIAS = '" + datos.Alergia + "', ALE_MODIFICADO_POR = '" + datos.ModificadoPor + "', ALE_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE ALE_ID_CLIENTE = '" + idAnterior + "'";
                conn.SQLExecuteCmm(_SQLConnection, actualizar);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para cargar los clientes al combo box
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

        // Para cargar el número de identificación del cliente.
        public void consultarCedCliente(TextBox txtIdentificacionC, string idSeleccionado)
        {
            try
            {
                string consulta = "SELECT CLI_ID, CLI_IDENTIFICACION FROM LABORATORIO.dbo.LAB_CLIENTES WHERE CLI_ID = '" + idSeleccionado + "';";

                var clientes = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (clientes.Rows.Count > 0)
                {
                    for (int i = 0; i < clientes.Rows.Count; i++)
                    {
                        txtIdentificacionC.Text = clientes.Rows[i].ItemArray[1].ToString();
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
