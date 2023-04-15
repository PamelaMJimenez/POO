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
    public class dtoUsuario
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        public bool validarIngreso(clsUsuario datos)
        {
            try
            {
                string consulta = "SELECT USU_USUARIO FROM LABORATORIO.dbo.LAB_USUARIOS WHERE USU_USUARIO ='"
                    + datos.Usuario + "' AND USU_CLAVE = '" + datos.Clave + "'";

                var existe = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (existe.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para guardar Usuario.
        public bool guardarUsuario(clsUsuario datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_USUARIOS VALUES('" + datos.Usuario + "', '" + datos.Clave + "', '" + datos.Estado + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar Usuario por nombre de Usuario
        public void consultarUsuario(TextBox txtClave, CheckBox chkEstado, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsUsuario usu)
        {
            string consulta = "SELECT USU_USUARIO, USU_CLAVE, USU_ESTADO, USU_ADICIONADO_POR, USU_FECHA_ADICION, USU_MODIFICADO_POR, USU_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_USUARIOS WHERE USU_USUARIO = '" + usu.Usuario + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    txtClave.Text = datos.Rows[i].ItemArray[1].ToString();
                    if (datos.Rows[i].ItemArray[2].ToString() == "A")
                    {
                        chkEstado.IsChecked = true;
                    }
                    else
                    {
                        chkEstado.IsChecked = false;
                    }
                    txtAdicionado.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[5].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[6].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ningún usuario con ese nombre! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar usuario 
        public bool modificarUsuario(clsUsuario datos, string usuarioAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_USUARIOS SET USU_USUARIO = '" + datos.Usuario + "', USU_CLAVE = '" + datos.Clave + "', USU_ESTADO = '" + datos.Estado + "', USU_MODIFICADO_POR = '" + datos.ModificadoPor + "', USU_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE USU_USUARIO = '" + usuarioAnterior + "';";
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
