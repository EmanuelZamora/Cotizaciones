CREATE DATABASE CONCESIONARIA

USE CONCESIONARIA

CREATE TABLE Clientes (
IdCliente INT PRIMARY KEY IDENTITY(1,1),
Nombre NVARCHAR(100),
Apellido NVARCHAR(100),
Email NVARCHAR(100),
Telefono NVARCHAR(20)
)

CREATE TABLE Vehiculo (
Id_Vehiculo INT PRIMARY KEY IDENTITY(1,1),
Marca NVARCHAR(25),
Modelo INT,
Anio INT,
Precio DECIMAL(10, 2),
Stock INT
)

CREATE TABLE Reserva (
Id_Reserva INT PRIMARY KEY IDENTITY(1,1),
Fecha_Reserva DATETIME,
Estado NVARCHAR(1),
IdCliente INT,
Id_Vehiculo INT,
CONSTRAINT FK_Reserva_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
CONSTRAINT FK_Vehiculos FOREIGN KEY (Id_Vehiculo) REFERENCES Vehiculo(Id_Vehiculo)
)

CREATE TABLE Credito (
Id_Credito INT PRIMARY KEY IDENTITY(1,1),
Monto DECIMAL(10,2),
Plazo DATETIME,
Tasa_Interes DECIMAL(10,2),
IdCliente INT,
CONSTRAINT FK_Credito_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
)

CREATE TABLE Seguro (
Id_Seguro INT PRIMARY KEY IDENTITY(1,1),
Tipo NVARCHAR(25),
Costo DECIMAL(10,2),
Cobertura NVARCHAR(100),
IdCliente INT,
Id_Vehiculo INT,
CONSTRAINT FK_Seguro_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
CONSTRAINT FK_Seguro_Vehiculo FOREIGN KEY (Id_Vehiculo) REFERENCES Vehiculo(Id_Vehiculo)
)

CREATE TABLE Bancos (
    IdBanco INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100)
)

CREATE TABLE Aseguradoras (
    IdAseguradora INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100)
)

CREATE TABLE Cotizaciones (
IdCotizacion INT PRIMARY KEY IDENTITY(1,1),
IdCliente INT,
IdVehiculo INT,
IdBanco INT NULL,
IdAseguradora INT NULL,
Fecha DATE,
Estado NVARCHAR(50),
CONSTRAINT FK_Cotizacion_Cliente FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
CONSTRAINT FK_Cotizacion_Vehiculo FOREIGN KEY (IdVehiculo) REFERENCES Vehiculo(Id_Vehiculo),
CONSTRAINT FK_Cotizacion_Banco FOREIGN KEY (IdBanco) REFERENCES Bancos(IdBanco),
CONSTRAINT FK_Cotizacion_Aseguradora FOREIGN KEY (IdAseguradora) REFERENCES Aseguradoras(IdAseguradora)
)
