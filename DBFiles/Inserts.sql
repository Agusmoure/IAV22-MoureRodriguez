--TIPOS
	INSERT INTO Tipo VALUES ('Siniestro');
	INSERT INTO Tipo VALUES ('Roca');
	INSERT INTO Tipo VALUES ('Lucha');
	INSERT INTO Tipo VALUES ('Psiquico');
	INSERT INTO Tipo VALUES ('Normal');
	INSERT INTO Tipo VALUES ('Fantasma');
--SINIESTRO
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Psiquico',2);
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Roca',1);
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Normal',1);
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Fantasma',2);
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Lucha',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Siniestro','Siniestro',0.5);
--ROCA
	INSERT INTO Fuerza_Tipos VALUES('Roca','Psiquico',1);
	INSERT INTO Fuerza_Tipos VALUES('Roca','Roca',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Roca','Normal',1);
	INSERT INTO Fuerza_Tipos VALUES('Roca','Fantasma',1);
	INSERT INTO Fuerza_Tipos VALUES('Roca','Lucha',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Roca','Siniestro',1);
--LUCHA
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Psiquico',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Roca',2);
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Normal',2);
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Fantasma',0);
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Lucha',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Lucha','Siniestro',2);
--NORMAL
	INSERT INTO Fuerza_Tipos VALUES('Normal','Psiquico',1);
	INSERT INTO Fuerza_Tipos VALUES('Normal','Roca',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Normal','Normal',1);
	INSERT INTO Fuerza_Tipos VALUES('Normal','Fantasma',0);
	INSERT INTO Fuerza_Tipos VALUES('Normal','Lucha',1);
	INSERT INTO Fuerza_Tipos VALUES('Normal','Siniestro',1);
--FANTASMA
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Psiquico',2);
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Roca',1);
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Normal',0);
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Fantasma',2);
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Lucha',1);
	INSERT INTO Fuerza_Tipos VALUES('Fantasma','Siniestro',0.5);
--PSIQUICO
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Psiquico',0.5);
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Roca',1);
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Normal',1);
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Fantasma',1);
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Lucha',2);
	INSERT INTO Fuerza_Tipos VALUES('Psiquico','Siniestro',0);
--FIN TIPOS
-- POKEMON EXISTENTES
	INSERT INTO Pokemon VALUES(197,'Umbreon','Siniestro',NULL);
	INSERT INTO Pokemon VALUES(248,'Tyranitar','Roca','Siniestro');
	INSERT INTO Pokemon VALUES(196,'Espeon','Psiquico',NULL);
	INSERT INTO Pokemon VALUES(766,'Passimian','Lucha',NULL);
--FIN POKEMON EXISTENTES
--POKEMONS LIDER GIMNASIO
	INSERT INTO Lider_Siniestro VALUES('LS1',197,'Maia');
	INSERT INTO Lider_Siniestro VALUES('LS2',248,'Rod');
--FIN POKEMONS LIDER GIMNASIO
--POKEMONS DEL RIVAL
INSERT INTO Rival VALUES('R1',196,'Espeon');
INSERT INTO Rival VALUES('R2',766,'Monito');
--FIN POKEMONS DEL RIVAL

--DATOS
INSERT INTO Datos VALUES('LS1',394,251,350,240,394,251,27);
INSERT INTO Datos VALUES('LS2',404,403,350,317,328,243,202);
INSERT INTO Datos VALUES('R1',334,251,240,394,317,350,26);
INSERT INTO Datos VALUES('R2',404,372,306,196,240,284,83);
--FIN DATOS

--ATAQUES
	--SINIESTRO
		INSERT INTO Ataques VALUES('MT0100','Golpe bajo','Siniestro',70,'Fisico',15);
		INSERT INTO Ataques VALUES('MT0097','Pulso umbrio','Siniestro',80,'Especial',20);
		INSERT INTO Ataques VALUES('MT0095','Alarido','Siniestro',55,'Especial',15);
		INSERT INTO Ataques VALUES('MT0101','Triturar','Siniestro',80,'Fisico',15);
	--ROCA
		INSERT INTO Ataques VALUES('MT0102','Tumba rocas','Roca',60,'Fisico',25);
		INSERT INTO Ataques VALUES('MT0048','Avalancha','Roca',75,'Fisico',10);
	--PSIQUICO
		INSERT INTO Ataques VALUES('MT0029','Psiquico','Psiquico',90,'Especial',10);
		INSERT INTO Ataques VALUES('MT0103','Psicocorte','Psiquico',70,'Fisico',20);
	--LUCHA
		INSERT INTO Ataques VALUES('MT0104','Golpe karate','Lucha',50,'Fisico',20);
		INSERT INTO Ataques VALUES('MT0105','Tajo Cruzado','Lucha',100,'Fisico',10);
	-- NORMAL
		INSERT INTO Ataques VALUES('MO0001','Corte','Normal',50,'Fisico',30);
		INSERT INTO Ataques VALUES('MT0001','Megapunio','Normal',80,'Fisico',20);
		INSERT INTO Ataques VALUES('MT0106','Araniazo','Normal',40,'Fisico',40);
	--Fantasma
		INSERT INTO Ataques Values('MT0030','Bola sombra','Fantasma',80,'Especial',20);
--MOVIMIENTOS
	INSERT INTO Movimientos VALUES('LS1','MT0100');
	INSERT INTO Movimientos VALUES('LS1','MT0097');
	INSERT INTO Movimientos VALUES('LS1','MT0030');
	INSERT INTO Movimientos VALUES('LS1','MT0029');
	INSERT INTO Movimientos VALUES('LS2','MT0095');
	INSERT INTO Movimientos VALUES('LS2','MT0101');
	INSERT INTO Movimientos VALUES('LS2','MT0102');
	INSERT INTO Movimientos VALUES('LS2','MT0048');
	INSERT INTO Movimientos VALUES('R1','MT0029');
	INSERT INTO Movimientos VALUES('R1','MT0103');
	INSERT INTO Movimientos VALUES('R1','MT0106');
	INSERT INTO Movimientos VALUES('R1','MT0030');
	INSERT INTO Movimientos VALUES('R2','MT0104');
	INSERT INTO Movimientos VALUES('R2','MT0105');
	INSERT INTO Movimientos VALUES('R2','MT0001');
	INSERT INTO Movimientos VALUES('R2','MO0001');