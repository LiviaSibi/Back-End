-- Cria o banco de dados - DDL
CREATE DATABASE InLock_Games_M;
GO

-- Define o banco de dados que será utilizado
USE InLock_Games_M;
GO

-- Cria a tabela Estudios
CREATE TABLE Estudio(
	IdEstudio	 INT PRIMARY KEY IDENTITY
	,NomeEstudio VARCHAR (255) NOT NULL UNIQUE
);
GO

CREATE TABLE Jogo(
	  IdJogo INT PRIMARY KEY IDENTITY
	, NomeJogo VARCHAR (255) NOT NULL UNIQUE
	, Descricao VARCHAR (255) NOT NULL 
	, DataLancamento DATE
	, Valor FLOAT 
	,IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
);
GO

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo VARCHAR (255) NOT NULL 
);
GO

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY
	,Email		VARCHAR (255) NOT NULL UNIQUE
	,Senha		VARCHAR (255) NOT NULL 
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);
GO


