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
    public class dtoCliente
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar Clientes.
        public bool insertarClientes(clsCliente datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_CLIENTES VALUES('" + datos.TipoIdentificacion + "', '" + datos.NumIdentificacion + "', '" + datos.PNombre + "', '" + datos.SNombre + "', '" + datos.PApellido + "', '" + datos.SApellido + "', '" + datos.FechaNacimiento.ToString("yyyy-MM-dd") + "', " + datos.Peso + ", '" + datos.Sexo + "', '" + datos.Celular + "', '" + datos.CorreoElectronico + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar los Clientes por número de cédula.
        public void consultaPorId(ComboBox cmbTipoId, TextBox txtPNombre, TextBox txtSNombre, TextBox txtPApellido, TextBox txtSApellido, DatePicker dtpFecNacimiento, TextBox txtPeso, ComboBox cmbSexo, TextBox txtCelular, TextBox txtCorreo, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsCliente cli)
        {
            string consulta = "SELECT CLI_TIPO_ID, CLI_IDENTIFICACION, CLI_PRIMER_NOMBRE, CLI_SEGUNDO_NOMBRE, CLI_PRIMER_APELLIDO, CLI_SEGUNDO_APELLIDO, CLI_FECHA_NACIMIENTO, CLI_PESO, CLI_SEXO, CLI_CELULAR, CLI_CORREO, CLI_ADICIONADO_POR, CLI_FECHA_ADICION, CLI_MODIFICADO_POR, CLI_FECHA_MODIFICACION  FROM LABORATORIO.dbo.LAB_CLIENTES WHERE CLI_IDENTIFICACION = '" + cli.NumIdentificacion + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    cmbTipoId.Text = datos.Rows[i].ItemArray[0].ToString();
                    txtPNombre.Text = datos.Rows[i].ItemArray[2].ToString();
                    txtSNombre.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtPApellido.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtSApellido.Text = datos.Rows[i].ItemArray[5].ToString();
                    dtpFecNacimiento.Text = datos.Rows[i].ItemArray[6].ToString();
                    txtPeso.Text = datos.Rows[i].ItemArray[7].ToString();
                    cmbSexo.Text = datos.Rows[i].ItemArray[8].ToString();
                    txtCelular.Text = datos.Rows[i].ItemArray[9].ToString();
                    txtCorreo.Text = datos.Rows[i].ItemArray[10].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[11].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[12].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[13].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[14].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ningún cliente registrado con ese número de identificación! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para modificar todos los datos del Cliente.
        public bool modificarCliente(clsCliente datos, string idAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_CLIENTES SET CLI_TIPO_ID = '" + datos.TipoIdentificacion + "', " +
                                    "CLI_IDENTIFICACION = '" + datos.NumIdentificacion + "', CLI_PRIMER_NOMBRE = '" + datos.PNombre + "', " +
                                    "CLI_SEGUNDO_NOMBRE = '" + datos.SNombre + "', CLI_PRIMER_APELLIDO = '" + datos.PApellido + "', " +
                                    "CLI_SEGUNDO_APELLIDO = '" + datos.SApellido + "', CLI_FECHA_NACIMIENTO = '" + datos.FechaNacimiento.ToString("yyyy-MM-dd") + "', " +
                                    "CLI_PESO = " + datos.Peso + ", CLI_SEXO = '" + datos.Sexo + "', CLI_CELULAR = '" + datos.Celular + "', " +
                                    "CLI_CORREO = '" + datos.CorreoElectronico + "', CLI_MODIFICADO_POR = '" + datos.ModificadoPor + "', " +
                                    "CLI_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE CLI_IDENTIFICACION = '" + idAnterior + "';";
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
