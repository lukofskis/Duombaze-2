#@(#) script.ddl

DROP TABLE IF EXISTS priskirtas;
DROP TABLE IF EXISTS teikia;
DROP TABLE IF EXISTS SALES;
DROP TABLE IF EXISTS PASLAUGOS;
DROP TABLE IF EXISTS KLIENTAS;
DROP TABLE IF EXISTS INVENTORIUS;
DROP TABLE IF EXISTS DARBUOTOJAS;
DROP TABLE IF EXISTS AMOKEJIMAS;
DROP TABLE IF EXISTS SPORTO_SALE;
DROP TABLE IF EXISTS NARYSTE;
DROP TABLE IF EXISTS DARBAS;
DROP TABLE IF EXISTS SalesTipas;
DROP TABLE IF EXISTS Pozicija;
DROP TABLE IF EXISTS PaslaugosTipas;
DROP TABLE IF EXISTS NarystesLygis;
DROP TABLE IF EXISTS Lytis;
DROP TABLE IF EXISTS Miestai;
CREATE TABLE Miestai
(
	id int NOT NULL AUTO_INCREMENT,
	pavadinimas varchar (255),
	PRIMARY KEY(id)
);

CREATE TABLE Lytis
(
	id_Lytis integer,
	name char (7) NOT NULL,
	PRIMARY KEY(id_Lytis)
);
INSERT INTO Lytis(id_Lytis, name) VALUES(1, 'Vyras');
INSERT INTO Lytis(id_Lytis, name) VALUES(2, 'Moteris');

CREATE TABLE NarystesLygis
(
	id_NarystesLygis integer,
	name char (8) NOT NULL,
	PRIMARY KEY(id_NarystesLygis)
);
INSERT INTO NarystesLygis(id_NarystesLygis, name) VALUES(1, 'Silver');
INSERT INTO NarystesLygis(id_NarystesLygis, name) VALUES(2, 'Gold');
INSERT INTO NarystesLygis(id_NarystesLygis, name) VALUES(3, 'Platinum');

CREATE TABLE PaslaugosTipas
(
	id_PaslaugosTipas integer,
	name char (8) NOT NULL,
	PRIMARY KEY(id_PaslaugosTipas)
);
INSERT INTO PaslaugosTipas(id_PaslaugosTipas, name) VALUES(1, 'Baseinas');
INSERT INTO PaslaugosTipas(id_PaslaugosTipas, name) VALUES(2, 'Pirtis');
INSERT INTO PaslaugosTipas(id_PaslaugosTipas, name) VALUES(3, 'Masazai');

CREATE TABLE Pozicija
(
	id_Pozicija integer,
	name char (14) NOT NULL,
	PRIMARY KEY(id_Pozicija)
);
INSERT INTO Pozicija(id_Pozicija, name) VALUES(1, 'Administracija');
INSERT INTO Pozicija(id_Pozicija, name) VALUES(2, 'Valytojas');
INSERT INTO Pozicija(id_Pozicija, name) VALUES(3, 'Treneris');

CREATE TABLE SalesTipas
(
	id_SalesTipas integer,
	name char (15) NOT NULL,
	PRIMARY KEY(id_SalesTipas)
);
INSERT INTO SalesTipas(id_SalesTipas, name) VALUES(1, 'Trx');
INSERT INTO SalesTipas(id_SalesTipas, name) VALUES(2, 'Kalanetika');
INSERT INTO SalesTipas(id_SalesTipas, name) VALUES(3, 'KunoDizainas');
INSERT INTO SalesTipas(id_SalesTipas, name) VALUES(4, 'BallsWorkout');
INSERT INTO SalesTipas(id_SalesTipas, name) VALUES(5, 'ResistanceBand ');

CREATE TABLE DARBAS
(
	id int NOT NULL AUTO_INCREMENT,
	darboValandos date,
	sumoketa float,
	pozicija integer,
	PRIMARY KEY(id),
	FOREIGN KEY(pozicija) REFERENCES Pozicija (id_Pozicija)
);

CREATE TABLE NARYSTE
(
	id int NOT NULL AUTO_INCREMENT,
	planoPradzia date,
	planoPabaiga date,
	kaina float,
	narystesLygis integer,
	PRIMARY KEY(id),
	FOREIGN KEY(narystesLygis) REFERENCES NarystesLygis (id_NarystesLygis)
);

CREATE TABLE SPORTO_SALE
(
	id int NOT NULL AUTO_INCREMENT,
	adresas varchar (255),
	maksimalusLankytojusk int,
	pavadinimas varchar (255),
	darboLaikoPradzia date,
	darboLaikoPabaiga date,
	telefonoNumeris varchar (255),
	elPastas varchar (255),
	intenetineSvetaine varchar (255),
	fk_Miestaiid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT yra FOREIGN KEY(fk_Miestaiid) REFERENCES Miestai (id)
);

CREATE TABLE AMOKEJIMAS
(
	id int NOT NULL AUTO_INCREMENT,
	mokejimoData date,
	kaina float,
	fk_NARYSTEid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT apmokama FOREIGN KEY(fk_NARYSTEid) REFERENCES NARYSTE (id)
);

CREATE TABLE DARBUOTOJAS
(
	id int NOT NULL AUTO_INCREMENT,
	vardas varchar (255),
	pavarde varchar (255),
	telNumeris varchar (255),
	lytis integer,
	fk_SPORTO_SALEid int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(lytis) REFERENCES Lytis (id_Lytis),
	CONSTRAINT dirba FOREIGN KEY(fk_SPORTO_SALEid) REFERENCES SPORTO_SALE (id)
);

CREATE TABLE INVENTORIUS
(
	id int NOT NULL AUTO_INCREMENT,
	pastatymas date,
	kiekis int,
	kaina float,
	pavadinimai varchar (255),
	fk_SPORTO_SALEid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT priklauso FOREIGN KEY(fk_SPORTO_SALEid) REFERENCES SPORTO_SALE (id)
);

CREATE TABLE KLIENTAS
(
	id int NOT NULL AUTO_INCREMENT,
	vardas varchar (255),
	pavarde varchar (255),
	amzius int,
	telefononr varchar (255),
	fk_NARYSTEid int NOT NULL,
	PRIMARY KEY(id),
	CONSTRAINT suteikiama FOREIGN KEY(fk_NARYSTEid) REFERENCES NARYSTE (id)
);

CREATE TABLE PASLAUGOS
(
	id int NOT NULL AUTO_INCREMENT,
	kaina float,
	paslaugosTipas integer,
	fk_SPORTO_SALEid int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(paslaugosTipas) REFERENCES PaslaugosTipas (id_PaslaugosTipas),
	CONSTRAINT suteikiamos FOREIGN KEY(fk_SPORTO_SALEid) REFERENCES SPORTO_SALE (id)
);

CREATE TABLE SALES
(
	id int NOT NULL AUTO_INCREMENT,
	pavadinimas varchar (255),
	irengta date,
	tipas integer,
	fk_SPORTO_SALEid int NOT NULL,
	PRIMARY KEY(id),
	FOREIGN KEY(tipas) REFERENCES SalesTipas (id_SalesTipas),
	CONSTRAINT turi FOREIGN KEY(fk_SPORTO_SALEid) REFERENCES SPORTO_SALE (id)
);

CREATE TABLE teikia
(
	fk_NARYSTEid int,
	fk_SPORTO_SALEid int,
	PRIMARY KEY(fk_NARYSTEid, fk_SPORTO_SALEid),
	CONSTRAINT teikia FOREIGN KEY(fk_NARYSTEid) REFERENCES NARYSTE (id)
);

CREATE TABLE priskirtas
(
	fk_DARBASid int,
	fk_DARBUOTOJASid int,
	PRIMARY KEY(fk_DARBASid, fk_DARBUOTOJASid),
	CONSTRAINT priskirtas FOREIGN KEY(fk_DARBASid) REFERENCES DARBAS (id)
);
