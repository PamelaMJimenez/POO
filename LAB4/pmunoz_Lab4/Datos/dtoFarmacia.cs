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
    public class dtoFarmacia
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar el registro de las farmacias.
        public bool insertarFarmacia(clsFarmacia datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_FARMACIA VALUES('" + datos.CedulaJuridica + "', '" + datos.Nombre + "', '" + datos.Telefono + "', '" + datos.CorreoElectronico + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar la farmacia por la cédula juridica
        public void consultaPorId(TextBox txtNombre, TextBox txtTelefono, TextBox txtCorreo, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsFarmacia far)
        {
            string consulta = "SELECT FAR_CED_JURIDICA, FAR_NOMBRE, FAR_TELEFONO, FAR_CORREO, FAR_ADICIONADO_POR, FAR_FECHA_ADICION, FAR_MODIFICADO_POR, FAR_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_FARMACIA WHERE FAR_CED_JURIDICA = '" + far.CedulaJuridica + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    txtNombre.Text = datos.Rows[i].ItemArray[1].ToString();
                    txtTelefono.Text = datos.Rows[i].ItemArray[2].ToString();
                    txtCorreo.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[5].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[6].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[7].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ninguna farmacia registrada para esa cédula jurídica! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar la farmacia por la cédula jurídica.
        public bool modificarFarmacia(clsFarmacia datos, string cedAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_FARMACIA SET FAR_CED_JURIDICA = '" + datos.CedulaJuridica + "', FAR_NOMBRE = '" + datos.Nombre + "', FAR_TELEFONO = '" + datos.Telefono + "', FAR_CORREO = '" + datos.CorreoElectronico + "', FAR_MODIFICADO_POR = '" + datos.ModificadoPor + "', FAR_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE FAR_CED_JURIDICA = '" + cedAnterior + "';";
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
