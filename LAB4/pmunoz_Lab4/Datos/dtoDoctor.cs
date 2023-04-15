using pmunoz_Lab3.Base_de_Datos;
using pMunoz_Lab3.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pmunoz_Lab3.Datos
{
    public class dtoDoctor
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar Doctores.
        public bool insertarDoctor(clsDoctor datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_DOCTOR VALUES('"+ datos.CodigoIncorporacion + "', '" + datos.NombreCompleto + "', '" + datos.Cedula + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar el doctor por número de identificación.
        public void consultaPorId(TextBox txtCodigo, TextBox txtNombre, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsDoctor doc)
        {
            string consulta = "SELECT DOC_CODIGO_MED, DOC_NOMBRE, DOC_IDENTIFICACION, DOC_ADICIONADO_POR, DOC_FECHA_ADICION, DOC_MODIFICADO_POR, DOC_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_DOCTOR WHERE DOC_IDENTIFICACION = '" + doc.Cedula + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    txtCodigo.Text = datos.Rows[i].ItemArray[0].ToString();
                    txtNombre.Text = datos.Rows[i].ItemArray[1].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[5].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[6].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ningún doctor registrado con ese número de identificación! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar el doctor.
        public bool modificarDoctor(clsDoctor datos, string idAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_DOCTOR SET DOC_CODIGO_MED = '" + datos.CodigoIncorporacion + "', DOC_NOMBRE = '" + datos.NombreCompleto + "', DOC_IDENTIFICACION = '" + datos.Cedula + "', DOC_MODIFICADO_POR = '" + datos.ModificadoPor + "', DOC_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE DOC_IDENTIFICACION = '" + idAnterior + "';";
                conn.SQLExecuteCmm(_SQLConnection, actualizar);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }
}
