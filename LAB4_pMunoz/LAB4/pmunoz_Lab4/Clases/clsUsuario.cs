using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsUsuario
    {
        #region Atributos
        private int identificador;
        private string usuario, clave, estado;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsUsuario()
        {
            this.identificador = 0;
            this.usuario = "";
            this.clave = "";
        }

        public clsUsuario(string usuario, string clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        public clsUsuario(String usu, String cla, String pest, String padicpor, DateTime pfecadic)
        {
            this.usuario = usu;
            this.clave = cla;
            this.estado = pest;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsUsuario(int id, String usu, String cla, String pest, String pmodpor, DateTime pfecmod)
        {
            this.usuario = usu;
            this.clave = cla;
            this.estado = pest;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsUsuario(String usu, String cla, String pest, String padicpor, DateTime pfecadic,
                               String pmodpor, DateTime pfecmod)
        {
            this.usuario = usu;
            this.clave = cla;
            this.estado = pest;
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
            datos = "Usuario: " + this.usuario + "\n" + "Clave: " + this.clave + "\n";
            return datos;
        }
        #endregion

        #region Métodos
        public int Identificador
        {
            set { this.identificador = value; }
            get { return this.identificador; }
        }

        public string Usuario
        {
            set { this.usuario = value.ToUpper(); }
            get { return this.usuario; }
        }

        public string Clave
        {
            set { this.clave = value.ToUpper(); }
            get { return this.clave; }
        }

        public String Estado
        {
            set { estado = value; }
            get { return estado; }
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
