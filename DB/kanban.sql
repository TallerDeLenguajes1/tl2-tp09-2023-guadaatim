--
-- File generated with SQLiteStudio v3.4.4 on sáb. nov. 11 19:41:35 2023
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Tablero
CREATE TABLE IF NOT EXISTS Tablero (id INTEGER PRIMARY KEY NOT NULL, id_usuario_propietario REFERENCES Usuario (id) NOT NULL, nombre TEXT (100) NOT NULL, descripcion TEXT (250));
INSERT INTO Tablero (id, id_usuario_propietario, nombre, descripcion) VALUES (1, 1, 'tablero1', 'gsgsgs');

-- Table: Tarea
CREATE TABLE IF NOT EXISTS Tarea (id INTEGER PRIMARY KEY NOT NULL, id_tablero INTEGER REFERENCES Tablero (id) NOT NULL, nombre TEXT (150) NOT NULL, estado INTEGER NOT NULL, descripcion TEXT (300), color TEXT, id_usuario_asignado INTEGER);
INSERT INTO Tarea (id, id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (1, 1, 'tarea 1', 1, 'primera tarea', 'azul', 1);
INSERT INTO Tarea (id, id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (2, 1, 'tarea 2', 1, 'segunda tarea', 'verde', 2);
INSERT INTO Tarea (id, id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (3, 1, 'tarea 2', 1, 'segunda tarea', 'verde', 1);

-- Table: Usuario
CREATE TABLE IF NOT EXISTS Usuario (id INTEGER PRIMARY KEY NOT NULL, nombre_de_usuario TEXT (100) NOT NULL);
INSERT INTO Usuario (id, nombre_de_usuario) VALUES (1, 'cambiando nombre usuario');
INSERT INTO Usuario (id, nombre_de_usuario) VALUES (2, 'fafafa');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
