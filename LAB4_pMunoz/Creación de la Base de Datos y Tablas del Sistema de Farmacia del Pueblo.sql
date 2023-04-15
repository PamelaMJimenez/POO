-- CREACI�N DE LA BASE DE DATOS.
CREATE DATABASE LABORATORIO;
USE LABORATORIO;

-- CREACI�N DE LAS TABLAS.

-- TABLA CLIENTES.
CREATE TABLE LAB_CLIENTES
(
 CLI_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 CLI_TIPO_ID Varchar(50) NOT NULL,
 CLI_IDENTIFICACION Varchar(15) NOT NULL,
 CLI_PRIMER_NOMBRE Varchar(25) NOT NULL,
 CLI_SEGUNDO_NOMBRE Varchar(25) NOT NULL,
 CLI_PRIMER_APELLIDO Varchar(25) NOT NULL,
 CLI_SEGUNDO_APELLIDO Varchar(25) NOT NULL,
 CLI_FECHA_NACIMIENTO DATETIME NOT NULL,
 CLI_PESO Numeric(5,2) NOT NULL,
 CLI_SEXO Varchar(1) NOT NULL,
 CLI_CELULAR Varchar(8) NOT NULL,
 CLI_CORREO Varchar(150) NOT NULL,
 CLI_ADICIONADO_POR Varchar(15) NOT NULL,
 CLI_FECHA_ADICION Datetime NOT NULL,
 CLI_MODIFICADO_POR Varchar(15) NULL,
 CLI_FECHA_MODIFICACION Datetime NULL
)
GO

-- LLAVE PRIMARIA.
ALTER TABLE LAB_CLIENTES ADD CONSTRAINT PK_LAB_CLIENTES PRIMARY KEY (CLI_ID)
GO

-- TABLA ALERGIAS.
CREATE TABLE LAB_ALERGIAS(
 ALE_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 ALE_ID_CLIENTE Int NOT NULL,
 ALE_ALERGIAS Varchar(200) NOT NULL,
 ALE_ADICIONADO_POR Varchar(15) NOT NULL,
 ALE_FECHA_ADICION Datetime NOT NULL,
 ALE_MODIFICADO_POR Varchar(15) NULL,
 ALE_FECHA_MODIFICACION Datetime NULL
)
GO

-- LLAVE PRIMARIA.
ALTER TABLE LAB_ALERGIAS ADD CONSTRAINT PK_LAB_ALERGIAS PRIMARY KEY (ALE_ID)
GO

-- TABLA DOCTOR.
CREATE TABLE LAB_DOCTOR(
 DOC_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 DOC_CODIGO_MED Int NOT NULL,
 DOC_NOMBRE Varchar(200) NOT NULL,
 DOC_IDENTIFICACION VARCHAR(15) NOT NULL,
 DOC_ADICIONADO_POR Varchar(15) NOT NULL,
 DOC_FECHA_ADICION Datetime NOT NULL,
 DOC_MODIFICADO_POR Varchar(15) NULL,
 DOC_FECHA_MODIFICACION Datetime NULL
)
GO

-- LLAVE PRIMARIA.
ALTER TABLE LAB_DOCTOR ADD CONSTRAINT PK_LAB_DOCTOR PRIMARY KEY (DOC_ID)
GO

-- TABLA HOJA CLINICA.
CREATE TABLE LAB_HOJA_CLINICA(
 HOC_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 HOC_ID_DOCTOR Int NOT NULL,
 HOC_ID_CLIENTE Int NOT NULL,
 HOC_FECHA_ATENCION DATETIME NOT NULL,
 HOC_SINTOMAS Varchar(250) NOT NULL,
 HOC_DIAGNOSTICO Varchar(250) NOT NULL,
 HOC_ADICIONADO_POR Varchar(15) NOT NULL,
 HOC_FECHA_ADICION Datetime NOT NULL,
 HOC_MODIFICADO_POR Varchar(15) NULL,
 HOC_FECHA_MODIFICACION Datetime NULL
)
GO

-- LLAVE PRIMARIA.
ALTER TABLE LAB_HOJA_CLINICA ADD CONSTRAINT PK_LAB_HOJA_CLINICA PRIMARY KEY (HOC_ID)
GO

-- TABLA RECETA.
CREATE TABLE LAB_RECETA(
 REC_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 REC_ID_HOJAC Int NOT NULL,
 REC_DESCRIPCION Varchar(250) NOT NULL,
 REC_DOSIS Varchar(100) NOT NULL,
 REC_ADICIONADO_POR Varchar(15) NOT NULL,
 REC_FECHA_ADICION Datetime NOT NULL,
 REC_MODIFICADO_POR Varchar(15) NULL,
 REC_FECHA_MODIFICACION Datetime NULL
)
GO

-- LLAVE PRIMARIA.
ALTER TABLE LAB_RECETA ADD CONSTRAINT PK_LAB_RECETA PRIMARY KEY (REC_ID)
GO

-- TABLA FARMACIA.
CREATE TABLE LAB_FARMACIA(
 FAR_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 FAR_CED_JURIDICA Int NOT NULL,
 FAR_NOMBRE Varchar(100) NOT NULL,
 FAR_TELEFONO Varchar(8) NOT NULL,
 FAR_CORREO Varchar(150) NOT NULL,
 FAR_ADICIONADO_POR Varchar(15) NOT NULL,
 FAR_FECHA_ADICION Datetime NOT NULL,
 FAR_MODIFICADO_POR Varchar(15) NULL,
 FAR_FECHA_MODIFICACION Datetime NULL
)
GO 

-- LLAVE PRIMARIA.
ALTER TABLE LAB_FARMACIA ADD CONSTRAINT PK_LAB_FARMACIA PRIMARY KEY (FAR_ID)
GO

-- TABLA DE USUARIO.
CREATE TABLE LAB_USUARIOS
(
 USU_ID Int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
 USU_USUARIO Varchar(15) NOT NULL,
 USU_CLAVE Varchar(10) NOT NULL,
 USU_ESTADO Varchar(1) NOT NULL,
 USU_ADICIONADO_POR Varchar(15) NOT NULL,
 USU_FECHA_ADICION Datetime NOT NULL,
 USU_MODIFICADO_POR Varchar(15) NULL,
 USU_FECHA_MODIFICACION Datetime NULL,
 CONSTRAINT CK_CR_USUARIOS_ESTADO CHECK (USU_ESTADO in ('A','I'))
)
GO

-- Add keys for table VT_USUARIOS

ALTER TABLE LAB_USUARIOS ADD CONSTRAINT PK_LAB_USUARIOS PRIMARY KEY (USU_ID)
GO

-- LLAVES FORANEAS 

-- LAB_ALERGIAS - LAB_CLIENTES
ALTER TABLE LAB_ALERGIAS ADD CONSTRAINT CLI_X_ALER FOREIGN KEY (ALE_ID_CLIENTE) REFERENCES LAB_CLIENTES (CLI_ID) ON UPDATE NO ACTION ON DELETE NO ACTION
GO

-- LAB_HOJA_CLINICA - LAB_DOCTOR
ALTER TABLE LAB_HOJA_CLINICA ADD CONSTRAINT DOC_X_HOC FOREIGN KEY (HOC_ID_DOCTOR) REFERENCES LAB_DOCTOR (DOC_ID) ON UPDATE NO ACTION ON DELETE NO ACTION
GO

-- LAB_HOJA_CLINICA - LAB_CLIENTES
ALTER TABLE LAB_HOJA_CLINICA ADD CONSTRAINT CLI_X_HOC FOREIGN KEY (HOC_ID_CLIENTE) REFERENCES LAB_CLIENTES (CLI_ID) ON UPDATE NO ACTION ON DELETE NO ACTION
GO

-- LAB_RECETA - LAB_HOJA_CLINICA
ALTER TABLE LAB_RECETA ADD CONSTRAINT HOC_X_REC FOREIGN KEY (REC_ID_HOJAC) REFERENCES LAB_HOJA_CLINICA (HOC_ID) ON UPDATE NO ACTION ON DELETE NO ACTION
GO