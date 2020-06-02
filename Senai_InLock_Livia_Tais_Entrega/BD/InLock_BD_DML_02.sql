-- Define o banco de dados que será utilizado - DML
USE InLock_Games_M;
GO

-- Insere dados na tabela 

INSERT INTO TipoUsuario	(Titulo)
VALUES				('Administrador')
					,('Cliente' );
GO

INSERT INTO Usuario	(Email, Senha, IdTipoUsuario)
VALUES				('admin@admin.com' ,'admin' , 1)
					,('cliente@cliente.com','cliente' , 2);
GO

INSERT INTO Estudio	(NomeEstudio)
VALUES				 ('Blizzard' )
					,('Rockstar Studios')
					,('Square Enix');
GO

INSERT INTO Jogo	(NomeJogo, DataLancamento, Descricao, IdEstudio , Valor)
VALUES				 ('Diablo3' , '15/05/2012' , 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', 1 , 99)
					,('Red Dead Redemption II' , '26/10/2018' , 'jogo eletrônico de ação-aventura western' , 2 ,  120);
GO

