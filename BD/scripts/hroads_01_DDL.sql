CREATE DATABASE SENAI_HROADS_MANHA
GO

USE SENAI_HROADS_MANHA
GO


CREATE TABLE Classe (
	idClasse tinyint primary key identity (1,1),
	nomeClasse varchar(50),
)
GO

CREATE TABLE Personagem (
	idPersonagem tinyint primary key identity (1,1),
	idClasse tinyint foreign key references Classe (idClasse), 
	nomePersonagem varchar(30),
	vidaMax smallint,
	manaMax smallint,
	dataUpdate Date,
	dataCriação Date,
)
GO

CREATE TABLE TipoHabilidade(
	idTipoHab tinyint primary key identity (1,1),
	nomeTipo varchar(50),
)
GO

CREATE TABLE Habilidade(
	idHab tinyint primary key identity (1,1), 
	idTipoHab tinyint foreign key references TipoHabilidade (idTipoHab),
	nomeHabilidade varchar(50),
	descricaoHabilidade varchar(200),
)
GO

CREATE TABLE Classe_Habilidade(
	idClasse_Habilidade tinyint primary key identity (1,1), 
	idClasse tinyint foreign key references Classe (idClasse),
	idHab tinyint foreign key references Habilidade (idHab)
)
GO