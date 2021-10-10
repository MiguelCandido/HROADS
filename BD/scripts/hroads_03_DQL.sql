USE SENAI_HROADS_MANHA
GO

--Selecionar todos os personagens
SELECT * FROM Personagem

--Selecionar todos as classes;
SELECT * FROM Classe

--Selecionar somente o nome das classes;
SELECT nomeClasse FROM Classe

--Selecionar todas as habilidades;
SELECT * FROM Habilidade

--Realizar a contagem de quantas habilidades estão cadastradas;
SELECT COUNT(idHab) AS 'Número de Habilidades' FROM Habilidade

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHab FROM Habilidade ORDER BY idHab ASC;

--Selecionar todos os tipos de habilidades;
SELECT * FROM TipoHabilidade

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT Habilidade.idHab AS 'ID da Habilidade', Habilidade.nomeHabilidade AS 'nome da Habilidade', TipoHabilidade.nomeTipo AS 'Tipo da Habilidade' FROM Habilidade
JOIN TipoHabilidade ON Habilidade.idTipoHab = TipoHabilidade.idTipoHab

--Selecionar todos os personagens e suas respectivas classes
SELECT Personagem.idPersonagem AS 'ID do personagem',Personagem.nomePersonagem AS 'Nome do personagem', Classe.nomeClasse AS 'Classe do personagem', Personagem.vidaMax AS 'HP do personagem',Personagem.manaMax AS 'MP do personagem',Personagem.dataCriação AS 'Data de criação do personagem',Personagem.dataUpdate  AS 'Última modificação do personagem' FROM Personagem
JOIN Classe on Personagem.idClasse = Classe.idClasse

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens)
SELECT Personagem.*, Classe.nomeClasse FROM Personagem
RIGHT JOIN Classe ON Personagem.idClasse = Classe.idClasse

--Selecionar todas as classes e suas respectivas habilidades
SELECT Classe.*, Habilidade.nomeHabilidade FROM Classe
LEFT JOIN Classe_Habilidade ON Classe.idClasse = Classe_Habilidade.idClasse
LEFT JOIN Habilidade ON Classe_Habilidade.idHab = Habilidade.idHab


--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência)
SELECT Habilidade.*, Classe.nomeClasse FROM Habilidade
LEFT JOIN Classe_Habilidade ON Habilidade.idHab = Classe_Habilidade.idHab
LEFT JOIN Classe ON Classe_Habilidade.idClasse = Classe.idClasse

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT Habilidade.*, Classe.nomeClasse FROM Habilidade
RIGHT JOIN Classe_Habilidade ON Habilidade.idHab = Classe_Habilidade.idHab
RIGHT JOIN Classe ON Classe_Habilidade.idClasse = Classe.idClasse
ORDER BY idHab ASC