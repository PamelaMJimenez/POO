using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsHojaClinica
    {
        #region Atributos
        private int identificador, idDoctor, idCliente;
        private DateTime fechaAtencion;
        private string sintomas, diagnostico;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsHojaClinica()
        {
            this.identificador = 0;
            this.idDoctor = 0;
            this.idCliente = 0;
            this.fechaAtencion = DateTime.Now;
            this.sintomas = "";
            this.diagnostico = "";
            this.adicionadoPor = "";
            this.fechaAdicion = DateTime.Now;
            this.modificadorPor = "";
            this.fechaModificacion = DateTime.Now;
        }

        public clsHojaClinica(int doc, int cli, DateTime fchAten, string sint, string diag)
        {
            this.idDoctor = doc;
            this.idCliente = cli;
            this.fechaAtencion = fchAten;
            this.sintomas = sint;
            this.diagnostico = diag;
        }

        public clsHojaClinica(int doc, int cli, DateTime fchAten, string sint, string diag, String padicpor, DateTime pfecadic)
        {
            this.idDoctor = doc;
            this.idCliente = cli;
            this.fechaAtencion = fchAten;
            this.sintomas = sint;
            this.diagnostico = diag;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsHojaClinica(int id, int doc, int cli, DateTime fchAten, string sint, string diag, String pmodpor, DateTime pfecmod)
        {
            this.idDoctor = doc;
            this.idCliente = cli;
            this.fechaAtencion = fchAten;
            this.sintomas = sint;
            this.diagnostico = diag;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsHojaClinica(int doc, int cli, DateTime fchAten, string sint, string diag, String padicpor, DateTime pfecadic, String pmodpor,
                              DateTime pfecmod)
        {
            this.idDoctor = doc;
            this.idCliente = cli;
            this.fechaAtencion = fchAten;
            this.sintomas = sint;
            this.diagnostico = diag;
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
            datos = "Doctor: " + this.idDoctor + "\n" +
                    "Cliente: " + this.idCliente + "\n" +
                    "Fecha de Atención: " + this.fechaAtencion + "\n" +
                    "Síntomas: " + this.sintomas + "\n" +
                    "Diagnóstico: " + this.diagnostico + "\n"; 
            return datos;
        }
        #endregion

        #region Métodos 
        public int Identificador
        {
            set { identificador = value; }
            get { return identificador; }
        }

        public int IdDoctor
        {
            set { idDoctor = value; }
            get { return idDoctor; }
        }

        public int IdCliente
        {
            set { idCliente = value; }
            get { return idCliente; }
        }

        public DateTime FechaAtencion
        {
            set { fechaAtencion = value; }
            get { return fechaAtencion; }
        }

        public string Sintomas
        {
            set { sintomas = value.ToUpper(); }
            get { return sintomas; }
        }

        public string Diagnostico
        {
            set { diagnostico = value.ToUpper(); }
            get { return diagnostico; }
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
