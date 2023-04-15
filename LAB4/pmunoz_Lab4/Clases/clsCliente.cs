using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMunoz_Lab3.Clases
{
    public class clsCliente
    {
        #region Atributos
        private int identificador;
        private string tipoIdentificacion, pNombre, sNombre, pApellido, sApellido, 
                       numIdentificacion, alergias, celular, correoElectronico, sexo;
        private DateTime fechaNacimiento;
        private decimal peso;
        private DateTime fechaAdicion, fechaModificacion;
        private String adicionadoPor, modificadorPor;
        #endregion

        #region Constructores
        public clsCliente()
        {
            this.identificador = 0;
            this.tipoIdentificacion = "";
            this.numIdentificacion = "";
            this.pNombre = "";
            this.sNombre = "";
            this.pApellido = "";
            this.sApellido = "";
            this.celular = "";
            this.correoElectronico = "";
            this.fechaNacimiento = DateTime.Now;
            this.peso = 0;
            this.sexo = "";
            this.adicionadoPor = "";
            this.fechaAdicion = DateTime.Now;
            this.modificadorPor = "";
            this.fechaModificacion = DateTime.Now;
        }

        public clsCliente(String tId, String numId, String pNom, String sNom, String pAp, 
                          String sAp, DateTime fNa, decimal peso, string sexo, String celu, 
                          String correo)
        {
            this.tipoIdentificacion = tId;
            this.numIdentificacion = numId;
            this.pNombre = pNom;
            this.sNombre = sNom;
            this.pApellido = pAp;
            this.sApellido = sAp; 
            this.fechaNacimiento = fNa;
            this.peso = peso;
            this.sexo = sexo;
            this.celular = celu;
            this.correoElectronico = correo;
            
        }

        public clsCliente(String tId, String numId, String pNom, String sNom, String pAp,
                          String sAp, DateTime fNa, decimal peso, string sexo, String celu,
                          String correo, String padicpor, DateTime pfecadic)
        {
            this.tipoIdentificacion = tId;
            this.numIdentificacion = numId;
            this.pNombre = pNom;
            this.sNombre = sNom;
            this.pApellido = pAp;
            this.sApellido = sAp;
            this.fechaNacimiento = fNa;
            this.peso = peso;
            this.sexo = sexo;
            this.celular = celu;
            this.correoElectronico = correo;
            this.adicionadoPor = padicpor;
            this.fechaAdicion = pfecadic;
        }

        public clsCliente(int id, String tId, String numId, String pNom, String sNom, String pAp,
                          String sAp, DateTime fNa, decimal peso, string sexo, String celu,
                          String correo, String pmodpor, DateTime pfecmod)
        {
            this.tipoIdentificacion = tId;
            this.numIdentificacion = numId;
            this.pNombre = pNom;
            this.sNombre = sNom;
            this.pApellido = pAp;
            this.sApellido = sAp;
            this.fechaNacimiento = fNa;
            this.peso = peso;
            this.sexo = sexo;
            this.celular = celu;
            this.correoElectronico = correo;
            this.modificadorPor = pmodpor;
            this.fechaModificacion = pfecmod;
        }

        public clsCliente(int id, String tId, String numId, String pNom, String sNom, String pAp,
                          String sAp, DateTime fNa, decimal peso, string sexo, String celu,
                          String correo, String padicpor, DateTime pfecadic, String pmodpor, 
                          DateTime pfecmod)
        {
            this.tipoIdentificacion = tId;
            this.numIdentificacion = numId;
            this.pNombre = pNom;
            this.sNombre = sNom;
            this.pApellido = pAp;
            this.sApellido = sAp;
            this.fechaNacimiento = fNa;
            this.peso = peso;
            this.sexo = sexo;
            this.celular = celu;
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
            datos = "Nombre Completo: " + this.pNombre + " " + this.sNombre + " " + this.pApellido + " " + this.sApellido + "\n" +
                    "Tipo de Identificación: " + this.tipoIdentificacion + "\n" +
                    "Número Identificación: " + this.numIdentificacion + "\n" +
                    "Fecha de Nacimiento: " + this.fechaNacimiento + "\n" +
                    "Peso: " + this.peso + "\n" +
                    "Sexo: " + this.sexo + "\n" +
                    "Alergías: " + this.alergias + "\n" +
                    "Teléfono Celular: " + this.celular + "\n" +
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

        public string TipoIdentificacion
        {
            set { tipoIdentificacion = value.ToUpper(); }
            get { return tipoIdentificacion; }
        }

        public string PNombre
        {
            set { pNombre = value.ToUpper(); }
            get { return pNombre; }
        }

        public string SNombre
        {
            set { sNombre = value.ToUpper();}
            get { return sNombre; }
        }

        public string PApellido
        {
            set { pApellido = value.ToUpper(); }
            get { return pApellido; }
        }

        public string SApellido
        {
            set { sApellido = value.ToUpper(); }
            get { return sApellido; }
        }

        public string NumIdentificacion
        {
            set { numIdentificacion = value.ToUpper(); }
            get { return numIdentificacion;}
        }

        public string Alergias
        {
            set { alergias = value.ToUpper();}
            get { return alergias; }
        }

        public string Celular
        {
            set { celular = value.ToUpper();}
            get { return celular; }
        }

        public string CorreoElectronico
        {
            set { correoElectronico = value.ToUpper(); }
            get { return correoElectronico; }
        }

        public DateTime FechaNacimiento
        {
            set { fechaNacimiento = value; }
            get { return fechaNacimiento;}
        }

        public decimal Peso
        {
            set { peso = value; }
            get { return peso; }
        }

        public string Sexo
        {
            set { sexo = value; }
            get { return sexo; }
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
