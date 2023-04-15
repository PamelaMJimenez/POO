using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsReceta
    {
        #region Atributos
        private int identificador, idHojaC;
        private string descripcion;
        private string dosis;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsReceta()
        {
            this.identificador = 0;
            this.idHojaC = 0; 
            this.descripcion = "";
            this.dosis = "";
            this.adicionadoPor = "";
            this.fechaAdicion = DateTime.Now;
            this.modificadorPor = "";
            this.fechaModificacion = DateTime.Now;
        }

        public clsReceta(int idHoC, string desc, string dos)
        {
            this.idHojaC = idHoC;
            this.descripcion = desc;
            this.dosis = dos;
        }

        public clsReceta(int idHoC, string desc, string dos, String padicpor, DateTime pfecadic)
        {
            this.idHojaC = idHoC;
            this.descripcion = desc;
            this.dosis = dos;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsReceta(int id, int idHoC, string desc, string dos, String pmodpor, DateTime pfecmod)
        {
            this.idHojaC = idHoC;
            this.descripcion = desc;
            this.dosis = dos;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsReceta(int id, int idHoC, string desc, string dos, String padicpor, DateTime pfecadic,
                           String pmodpor, DateTime pfecmod)
        {
            this.idHojaC = idHoC;
            this.descripcion = desc;
            this.dosis = dos;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }
        #endregion

        #region Funciones y Procedimientos
        public string imprimirDatos()
        {
            string datos = "";
            datos = "Hoja Clínica: " + this.idHojaC + "\n" +
                    "Descripcion: " + this.descripcion + "\n" +
                    "Dosis: " + this.dosis + "\n";
            return datos;
        }
        #endregion

        #region Métodos
        public int Identificador
        {
            set { identificador = value; }
            get { return identificador;}
        }

        public int IdHojaC
        {
            set { idHojaC = value; }
            get { return idHojaC; }
        }

        public string Descripcion
        {
            set { descripcion = value.ToUpper(); }
            get { return descripcion; }
        }

        public string Dosis
        {
            set { dosis = value.ToUpper(); }
            get { return dosis; }
        }

        public String AdicionadoPor
        {
            set { adicionadoPor = value; }
            get { return adicionadoPor; }
        }
        public DateTime FechaAdicion
        {
            set { fechaAdicion = value; }
            get { return fechaAdicion; }
        }
        public String ModificadoPor
        {
            set { modificadorPor = value; }
            get { return modificadorPor; }
        }
        public DateTime FechaModificacion
        {
            set { fechaModificacion = value; }
            get { return fechaModificacion; }
        }
        #endregion
    }
}
