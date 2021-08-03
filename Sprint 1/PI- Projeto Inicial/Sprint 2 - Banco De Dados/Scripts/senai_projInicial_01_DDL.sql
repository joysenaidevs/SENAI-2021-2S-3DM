-- DDL

CREATE DATABASE projInicial;

USE projInicial;

-- nome que deve estar nos script : senai_projInicial_01_DDL.sql

CREATE TABLE tipoUsuarios
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nome				VARCHAR (200) UNIQUE NOT NULL -- DIZ QUE O VALOR É UNICO, PARA NAO CADASTRAR DADOS REPETIDOS (UNIQUE)
);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuarios (idTipoUsuario) -- (idTipoUsuario) VOU INFORMAR A COLUNA A QUE FAÇO REFERENCIA
	,nome				VARCHAR (200) NOT NULL
	,email				VARCHAR (200) UNIQUE NOT NULL
	,senha				VARCHAR (200) NOT NULL
);
GO

CREATE TABLE salas
(
	idSala			INT PRIMARY KEY IDENTITY
	,idUsuario		INT FOREIGN KEY REFERENCES usuarios (idUsuario)	-- (idUsuario) Coluna a que faço referencia
	,andar			VARCHAR (200) NOT NULL
	,nome			VARCHAR (200) NOT NULL
	,metragem		CHAR (10)NOT NULL

);
GO

CREATE TABLE equipamentos
(
	idEquipamento			INT PRIMARY KEY IDENTITY
	,idUsuario				INT FOREIGN KEY REFERENCES usuarios (idUsuario)
	,marca					VARCHAR (200) NOT NULL
	,tipo					VARCHAR (200) NOT NULL
	,numeroDeSerie			CHAR (20) NOT NULL
	,descricao				VARCHAR (200) NOT NULL
	,numeroDoPatrimonio		INT NOT NULL
	,situacao				VARCHAR (200) NOT NULL
);

