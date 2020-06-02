INSERT INTO TipoUsuarios (Titulo)
VALUES ('Comum'), ('Administrador');

INSERT INTO Usuarios (Email, Senha, IDTipoUsuario)
VALUES  ('catarina@email.com', '123', 1),
		('tadeu@email.com', '123', 1),
		('adm@adm.com', '123', 2);

INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento)
VALUES  ('Catarina', 'Strada', '21/02/2019'), 
		('Tadeu', 'Vitelli', '21/08/2001');