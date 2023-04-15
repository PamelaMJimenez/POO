using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsDoctor
    {
        #region Atributos
        private int identificador, codigoIncorporacion, cedula;
        private string nombreCompleto;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsDoctor()
        {
            this.identificador = 0;
            this.codigoIncorporacion = 0;
            this.cedula = 0;
            this.nombreCompleto = "";;     
        }

        public clsDoctor(int codIncor, int ced, string nombreC)
        {
            this.codigoIncorporacion = codIncor;
            this.cedula = ced;
            this.nombreCompleto = nombreC;
        }

        public clsDoctor(int codIncor, string nombreC, int ced, String padicpor, DateTime pfecadic)
        {
            this.codigoIncorporacion = codIncor;
            this.nombreCompleto = nombreC;
            this.cedula = ced;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsDoctor(int id, int codIncor, int ced, string nombreC, String pmodpor, DateTime pfecmod)
        {
            this.codigoIncorporacion = codIncor;
            this.cedula = ced;
            this.nombreCompleto = nombreC;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsDoctor(int id, int codIncor, int ced, string nombreC, String padicpor, DateTime pfecadic,
                         String pmodpor, DateTime pfecmod)
        {
            this.codigoIncorporacion = codIncor;
            this.cedula = ced;
            this.nombreCompleto = nombreC;
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
            datos = "Nombre Completo: " + this.nombreCompleto + "\n" +
                    "Cédula: " + this.cedula + "\n" +
                    "Código de Incorporación al Colegio de Médicos: " + this.codigoIncorporacion + "\n";
            return datos;
        }
        #endregion

        #region Métodos 
        public int Identificador
        {
            set { identificador = value;}
            get { return identificador; }
        }

        public int CodigoIncorporacion
        {
            set { codigoIncorporacion = value; }
            get { return codigoIncorporacion; }
        }

        public int Cedula
        {
            set { cedula = value; }
            get { return cedula; }
        }

        public string NombreCompleto
        {
            set { nombreCompleto = value.ToUpper(); }
            get { return nombreCompleto; }
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
