CREATE DATABASE Reto;
USE Reto;

/* Creando la tabla usuario */

CREATE TABLE usuario (
  UsuarioId INT IDENTITY(1,1) NOT NULL,
  Nombres VARCHAR(50) NOT NULL,
  Apellidos VARCHAR(50) NOT NULL,
  Edad INT NOT NULL,
  Telefono INT NOT NULL


);


/* CREANDO PROCEDIMIENTO ALMACENADOS TIPO CRUD*/

CREATE PROCEDURE usp_insert_user
(
  @Nombres VARCHAR(50),
  @Apellidos VARCHAR(50),
  @Edad INT,
  @Telefono INT
)
AS
BEGIN
  INSERT INTO usuario (Nombres, Apellidos,	Edad, Telefono)
  VALUES (@Nombres, @Apellidos, @Edad, @Telefono);
END;


CREATE PROCEDURE usp_select_user
AS
BEGIN
  SELECT *
  FROM usuario;
END;

CREATE PROCEDURE usp_get_user
(
  @UsuarioId INT
)
AS
BEGIN
  SELECT *
  FROM usuario
  WHERE UsuarioId = @UsuarioId;
END;


CREATE PROCEDURE usp_update_user
(
  @UsuarioId INT,
  @Nombres VARCHAR(50),
  @Apellidos VARCHAR(50),
  @Edad INT,
  @Telefono INT

)
AS
BEGIN
  UPDATE usuario
  SET Nombres = @Nombres, Apellidos = @Apellidos, Edad = @Edad, Telefono = @Telefono
  WHERE UsuarioId = @UsuarioId;
END;

CREATE PROCEDURE usp_delete_user
(
  @UsuarioId INT
)
AS
BEGIN
  DELETE FROM usuario
  WHERE UsuarioId = @UsuarioId;
END;


/* UTILIZAMOS EL COMANDO EXEC PARA EJECUTAR LOS PROCEDIMIENTOS ALMACENADOS */

EXEC usp_insert_user 'John Alex', 'Perez Arteaga', 25, 914856721;

EXEC usp_select_user;

EXEC usp_update_user 1, 'Jay Alex', 'Perez', 28, 914751725;

EXEC usp_delete_user 1;
