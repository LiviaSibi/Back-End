-- DQL LINGUAGEM DE CONSULTA DE DADOS 

-- Define o banco de dados que será utilizado
USE InLock_Games_M;

--Listar todos os usuários;
SELECT * FROM Usuario;

--Listar todos os estúdios; 
SELECT * FROM Estudio;

--Listar todos os jogos; 
SELECT * FROM Jogo;


--SELECT Jogo.IdJogo, Jogo.DataLancamento, Jogo.Descricao, Jogo.NomeJogo, Jogo.Valor, Estudio.NomeEstudio from Jogo 
--inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
--Listar todos os jogos e seus respectivos estúdios; 
 SELECT Jogo.IdJogo, Jogo.NomeJogo,Estudio.NomeEstudio from Jogo 
inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
 --Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência; 
 SELECT * FROM Estudio;

 --Buscar um usuário por email e senha; 
 SELECT Usuario.Email , Usuario.Senha from Usuario;

 --Buscar um jogo por IdJogo; 
SELECT * FROM Jogo
WHERE IdJogo = 3;

 --Buscar um estúdio por IdEstudio; 
 SELECT * FROM Estudio
 WHERE IdEstudio = 2;


