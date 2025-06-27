
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Negocio')
BEGIN
    CREATE DATABASE Negocio;
END
GO

USE Negocio;
GO

IF OBJECT_ID('Usuarios', 'U') IS NULL
BEGIN
    CREATE TABLE Usuarios (
        IdUsuarios INT IDENTITY PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Apellido NVARCHAR(100) NOT NULL,
        Login NVARCHAR(50) NOT NULL,
        Descripcion NVARCHAR(255) NULL,
        FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
        DNI NVARCHAR(50) NOT NULL,
        Area VARCHAR(50) DEFAULT 'Sin Área',
        FechaNacimiento DATE NULL,
        Celular VARCHAR(20) DEFAULT '0000000000',
        Nivel INT DEFAULT 0,
        Contraseña NVARCHAR(100) NOT NULL
    );
END
GO

IF OBJECT_ID('Auditoria', 'U') IS NULL
BEGIN
    CREATE TABLE Auditoria (
        IdAuditoria INT IDENTITY PRIMARY KEY,
        Fecha DATETIME NOT NULL,
        TiempoDeUso INT NOT NULL,
        IdUsuarios INT NOT NULL FOREIGN KEY REFERENCES Usuarios(IdUsuarios),
        NombreUsuario NVARCHAR(200) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Login = 'admin')
BEGIN
    INSERT INTO Usuarios (Nombre, Apellido, Login, Descripcion, FechaRegistro, DNI, Area, FechaNacimiento, Celular, Nivel, Contraseña)
    VALUES ('admin', 'admin', 'admin', 'Registrado desde el sistema', '2025-06-06T17:34:13.890', '25346789', 'adminsupremo', '2025-06-26', '1234567', 1, 'admin');
END
GO

IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE Login = 'octifakiani')
BEGIN
    INSERT INTO Usuarios (Nombre, Apellido, Login, Descripcion, FechaRegistro, DNI, Area, FechaNacimiento, Celular, Nivel, Contraseña)
    VALUES ('octavio', 'fakiani', 'octifakiani', 'Registrado desde el sistema', '2025-06-26T20:35:16.903', '44970369', 'Producción', '2003-11-18', '3512294285', 0, '44970369');
END
GO