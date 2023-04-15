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
    public class dtoReceta
    {
        private ConnSQL conn = new ConnSQL();//para hacer consultas SQL
        private string _SQLConnection = Conn.GetConnectionStrings();

        // Para guardar el registro de las recetas.
        public bool insertarRecetas(clsReceta datos)
        {
            try
            {
                string registro = "INSERT INTO LABORATORIO.dbo.LAB_RECETA VALUES('" + datos.IdHojaC + "', '" + datos.Descripcion + "', '" + datos.Dosis + "', '" + datos.AdicionadoPor + "', '" + datos.FechaAdicion.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null);";
                conn.SQLExecuteCmm(_SQLConnection, registro);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para consultar la receta por el id de la hoja clinica.
        public void consultaPorId(TextBox txtDescripcion, TextBox txtDosis, TextBox txtAdicionado, TextBox txtFechaAdicion, TextBox txtModificado, TextBox txtFechaModificacion, clsReceta rec)
        {
            string consulta = "SELECT REC_ID_HOJAC, REC_DESCRIPCION, REC_DOSIS, REC_ADICIONADO_POR, REC_FECHA_ADICION, REC_MODIFICADO_POR, REC_FECHA_MODIFICACION FROM LABORATORIO.dbo.LAB_RECETA WHERE REC_ID_HOJAC = '" + rec.IdHojaC + "';";

            var datos = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
            if (datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //cmb.Items.Add(usuarios.Rows[i].ItemArray[0]);
                    txtDescripcion.Text = datos.Rows[i].ItemArray[1].ToString();
                    txtDosis.Text = datos.Rows[i].ItemArray[2].ToString();
                    txtAdicionado.Text = datos.Rows[i].ItemArray[3].ToString();
                    txtFechaAdicion.Text = datos.Rows[i].ItemArray[4].ToString();
                    txtModificado.Text = datos.Rows[i].ItemArray[5].ToString();
                    txtFechaModificacion.Text = datos.Rows[i].ItemArray[6].ToString();
                }
            }
            else
            {
                MessageBox.Show(" ¡No existe ninguna receta registrada para este identificador de hoja clínica! ", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Para mododificar la receta por el id de la hoja clínica
        public bool modificarReceta(clsReceta datos, string idAnterior)
        {
            try
            {
                string actualizar = "UPDATE LABORATORIO.dbo.LAB_RECETA SET REC_ID_HOJAC = '" + datos.IdHojaC + "', REC_DESCRIPCION = '" + datos.Descripcion + "', REC_DOSIS = '" + datos.Dosis + "', REC_MODIFICADO_POR = '" + datos.ModificadoPor + "', REC_FECHA_MODIFICACION = '" + datos.FechaModificacion.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE REC_ID_HOJAC = '" + idAnterior + "';";
                conn.SQLExecuteCmm(_SQLConnection, actualizar);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        // Para cargar todos los identificadores de las hojas clinicas
        public void consultarHojasClinicas(ComboBox cmbHojaC)
        {
            try
            {
                string consulta = "SELECT HOC_ID FROM LABORATORIO.dbo.LAB_HOJA_CLINICA;";

                var clientes = conn.SQLCargaDataTable(_SQLConnection, consulta, null);
                if (clientes.Rows.Count > 0)
                {
                    for (int i = 0; i < clientes.Rows.Count; i++)
                    {
                        cmbHojaC.Items.Add(clientes.Rows[i].ItemArray[0]);
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
