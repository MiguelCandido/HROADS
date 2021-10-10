USE SENAI_HROADS_MANHA
GO

INSERT INTO Classe(nomeClasse)
VALUES				('Barbaro'),('Monge'),('Cruzado'),('Demon Hunter'),('Necromante'),('Feiticeiro'),('Arcanista');
GO

INSERT INTO Personagem(idClasse,nomePersonagem,vidaMax,manaMax,dataUpdate,dataCriação)
VALUES				(1,'DeuBug', 100,80,CURRENT_TIMESTAMP,DATEFROMPARTS(2019,01,18)),(2,'BitBug', 70,100,CURRENT_TIMESTAMP,DATEFROMPARTS(2016,03,17)),(7,'Fer8', 75,60,CURRENT_TIMESTAMP,DATEFROMPARTS(2018,03,18)) ;
GO

INSERT INTO TipoHabilidade(nomeTipo)
VALUES				('Ataque'),('Defesa'),('Cura'),('Magia');
GO

INSERT INTO Habilidade(idTipoHab,nomeHabilidade,descricaoHabilidade)
VALUES				(1, 'Lança Mortal','habilidade de ataque, causa muito dano ao inimigo'),(2, 'Escudo Supremo','habilidade de defesa, aumenta sua resistência'),(3, 'Recuperar Vida','habilidade de cura, regenera sua vida ao usar');
GO

INSERT INTO Classe_Habilidade(idClasse,idHab)
VALUES				(1, 1),(1, 2),(2, 3),(2, 2), (3, 2), (4, 1), (6, 3);
GO

INSERT INTO tipoUsuario(tipo)
VALUES ('Administrador'),('Usuario')
GO

insert into Usuario(idTipo, email, senha)
values (1, 'adm@hroads.com','admin'), (2, 'teste@hroads.com', 'teste')

UPDATE Personagem
SET nomePersonagem = 'Fer7', dataUpdate = CURRENT_TIMESTAMP
WHERE idPersonagem = 3;

UPDATE Classe
SET nomeClasse = 'Necromancer'
WHERE idClasse = 5;