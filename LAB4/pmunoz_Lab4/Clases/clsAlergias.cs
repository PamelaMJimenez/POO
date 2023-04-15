using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsAlergias
    {
        #region Atributos
        private int identificador, idCliente;
        private string alergia;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsAlergias()
        {
            this.identificador = 0;
            this.idCliente = 0;
            this.alergia = "";
            this.adicionadoPor = "";
            this.fechaAdicion = DateTime.Now;
            this.modificadorPor = "";
            this.fechaModificacion = DateTime.Now;
        }

        public clsAlergias(int idCli, string aler)
        {
            this.idCliente = idCli;
            this.alergia = aler;
        }

        public clsAlergias(int idCli, string aler, String padicpor, DateTime pfecadic)
        {
            this.idCliente = idCli;
            this.alergia = aler;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsAlergias(int id, int idCli, string aler, String pmodpor, DateTime pfecmod)
        {
            this.idCliente = idCli;
            this.alergia = aler;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsAlergias(int id, int idCli, string aler, String padicpor, DateTime pfecadic,
                           String pmodpor, DateTime pfecmod)
        {
            this.idCliente = idCli;
            this.alergia = aler;
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
            datos = "Identificador del Cliente: " + this.idCliente + "\n" + 
                    "Alergias: " + this.alergia + "\n";
            return datos;
        }
        #endregion

        #region Métodos
        public int Identificador
        {
            set { this.identificador = value; }
            get { return this.identificador; }
        }

        public int IdCliente
        {
            set { this.idCliente = value; }
            get { return this.idCliente; }
        }

        public string Alergia
        {
            set { this.alergia = value.ToUpper(); }
            get { return this.alergia; }
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
