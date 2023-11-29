-- Crear la base de datos
CREATE DATABASE Conferencias;

-- Usar la base de datos
USE ConferenciasBD;

-- Crear la tabla Participantes
CREATE TABLE Participantes (
    ID_Participante INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    Email VARCHAR(50),
    UsuarioTwitter VARCHAR(50),
    Avatar VARCHAR(MAX),
    Ocupacion VARCHAR(50),
    AceptoTerminos BIT
);

-- Crear la tabla Conferencias 
CREATE TABLE Conferencias (
    ID_Conferencia INT PRIMARY KEY IDENTITY(1,1),
    Horario DATETIME,
    TituloConferencia VARCHAR(100),
    Conferencista VARCHAR(50),
    Registro VARCHAR(MAX)
);

-- Crear la tabla Asistencia 
CREATE TABLE Asistencia (
    ID_Asistencia INT PRIMARY KEY IDENTITY(1,1),
    ID_Participante INT,
    ID_Conferencia INT,
    ConfirmacionAsistencia BIT,
    FOREIGN KEY (ID_Participante) REFERENCES Participantes(ID_Participante),
    FOREIGN KEY (ID_Conferencia) REFERENCES Conferencias(ID_Conferencia)
);
