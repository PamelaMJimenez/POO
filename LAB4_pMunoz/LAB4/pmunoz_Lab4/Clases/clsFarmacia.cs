using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsFarmacia
    {
        #region Atributos
        private int identificador;
        private string cedulaJuridica, nombre, telefono, correoElectronico;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsFarmacia()
        {
            this.identificador = 0;
            this.cedulaJuridica = "";
            this.nombre = "";
            this.telefono = "";
            this.correoElectronico = "";
            this.adicionadoPor = "";
            this.fechaAdicion = DateTime.Now;
            this.modificadorPor = "";
            this.fechaModificacion = DateTime.Now;
        }

        public clsFarmacia(string cedJuri, string nom, string tel, string correo)
        {
            this.cedulaJuridica = cedJuri;
            this.nombre = nom;
            this.telefono = tel;
            this.correoElectronico = correo;
        }

        public clsFarmacia(string cedJuri, string nom, string tel, string correo, String padicpor, DateTime pfecadic)
        {
            this.cedulaJuridica = cedJuri;
            this.nombre = nom;
            this.telefono = tel;
            this.correoElectronico = correo;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsFarmacia(int id, string cedJuri, string nom, string tel, string correo, String pmodpor, DateTime pfecmod)
        {
            this.cedulaJuridica = cedJuri;
            this.nombre = nom;
            this.telefono = tel;
            this.correoElectronico = correo;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsFarmacia(string cedJuri, string nom, string tel, string correo, String padicpor, DateTime pfecadic,
                           String pmodpor, DateTime pfecmod)
        {
            this.cedulaJuridica = cedJuri;
            this.nombre = nom;
            this.telefono = tel;
            this.correoElectronico = correo;
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
            datos = "Cédula Jurídica: " + this.cedulaJuridica + "\n" +
                    "Nombre: " + this.nombre + "\n" +
                    "Teléfono: " + this.telefono + "\n" +
                    "Correo Electrónico: " + this.correoElectronico + "\n";
            return datos;
        }
        #endregion

        #region Métodos
        public int Identificador
        {
            set { identificador = value; }
            get { return identificador; }
        }

        public string CedulaJuridica
        {
            set { cedulaJuridica = value.ToUpper(); }
            get { return cedulaJuridica; }
        }

        public string Nombre
        {
            set { nombre = value.ToUpper(); }
            get { return nombre; }
        }  

        public string Telefono
        {
            set { telefono = value.ToUpper(); }
            get { return telefono; }
        }

        public string CorreoElectronico
        {
            set { correoElectronico = value.ToUpper(); }
            get { return correoElectronico; }
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
