DROP TABLE Movimientos;
DROP TABLE Ataques;
DROP TABLE Lider_Siniestro;
DROP TABLE Rival;
DROP TABLE Datos;
DROP TABLE Fuerza_Tipos;
DROP TABLE Pokemon;
DROP TABLE Tipo;
CREATE TABLE Tipo(
tipo VARCHAR(20) PRIMARY KEY
);

CREATE TABLE Pokemon(
NatDex_number INT PRIMARY KEY,
Nombre VARCHAR(40) NOT NULL,
Tipo1 VARCHAR(20)NOT NULL REFERENCES Tipo(tipo),
Tipo2 VARCHAR(20) REFERENCES Tipo(tipo)
);

CREATE TABLE Ataques(
Id VARCHAR(6) PRIMARY KEY,
Nombre VARCHAR(30) NOT NULL,
Tipo VARCHAR(20) REFERENCES Tipo(tipo),
Danio INTEGER NOT NULL,
D_tipo VARCHAR(10),
PP INTEGER NOT NULL
);

CREATE TABLE Lider_Siniestro(
Id_l VARCHAR(3) PRIMARY KEY,
Pokemon INTEGER NOT NULL REFERENCES Pokemon(NatDex_number)ON DELETE CASCADE,
Apodo VARCHAR(40)
);

CREATE TABLE Rival(
Id_r VARCHAR(3) PRIMARY KEY,
Pokemon INTEGER NOT NULL REFERENCES Pokemon(NatDex_number),
Apodo VARCHAR(40)
);

CREATE TABLE Datos(
Id_datos VARCHAR(3) PRIMARY KEY,
hp INTEGER NOT NULL,
Ataque_fisico INTEGER NOT NULL,
Defensa_fisica INTEGER NOT NULL,
Ataque_especial INTEGER NOT NULL,
Defensa_especial INTEGER NOT NULL,
velocidad INTEGER NOT NULL,
peso INTEGER NOT NULL
);

CREATE TABLE Fuerza_Tipos(
T1 VARCHAR(20) NOT NULL REFERENCES Tipo(tipo)ON DELETE CASCADE,
T2 VARCHAR(20) NOT NULL REFERENCES Tipo(tipo)ON DELETE CASCADE,
Potenciador FLOAT NOT NULL,
CONSTRAINT Relacion PRIMARY KEY (T1, T2)
);

CREATE TABLE Movimientos(
Id_m VARCHAR(3) NOT NULL,
Id_a VARCHAR(6) NOT NULL REFERENCES Ataques(Id),
CONSTRAINT mov PRIMARY KEY (Id_m, Id_a)
);