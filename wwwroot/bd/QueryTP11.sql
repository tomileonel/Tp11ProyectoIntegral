--SP de iniciar sesion (gmail, contrase�a) 
CREATE PROCEDURE IniciarSesion
 @gmail VARCHAR(50),
 @contrasena VARCHAR(50)
	AS
	BEGIN
		Select * from Registro R where R.Email = @gmail and R.Contrasena = @contrasena
	END 
	GO

EXEC IniciarSesion
--SP de registrarte (nombre usuario,apellido usuario, contrase�a,gmail)
CREATE PROCEDURE Registrarte
@nombreU Varchar(50),
@apellidoU Varchar(50),
@gmail VARCHAR(50),
@contrasena VARCHAR(50)
	AS
	BEGIN
	Insert into Registro
	(Nombre_usuario,Apellido_usuario,Email,Contrasena)
	Values
	(@nombreU,@apellidoU,@gmail,@contrasena)
		
	END 
	GO

EXEC Registrarte
--SP de editar perfil (todo menos id 6 campos)
alter PROCEDURE EditarPerfil
@nombreU Varchar(50),
@apellidoU Varchar(50),
@gmail VARCHAR(50),
@contrasena VARCHAR(50),
@telefono Int,
@foto varchar (200)
AS
	BEGIN
UPDATE Registro
SET Nombre_usuario = @nombreU, Apellido_usuario = @apellidoU,Telefono = @telefono, FotoDePerfil = @foto Contrasena = @contrasena
Where Email = @gmail
	END 
	GO

EXEC EditarPerfil 

--BuscarCasa(todo de casa)
CREATE PROCEDURE BuscarCasa
@direccion Varchar(50),
@precio Real,
@pileta bit,
@parrilla bit,
@CantidadAmbientes int,
@bacon bit
AS
BEGIN


IF @direccion IS NOT NULL
BEGIN
	SET @direccion = '%' + @direccion + '%';
END

SELECT *
FROM Casa
WHERE
	 (Direccion_casa LIKE @direccion)
	AND (Cantidad_ambientes IS NULL OR Cantidad_ambientes >= @CantidadAmbientes)
	AND (Precio IS NULL OR Precio >= @precio)
	AND (Pileta Is null or Pileta = @pileta)
	AND (Parrila  Is null or Parrila = @parrilla)
	AND (Balcon is null or Balcon = @bacon)

END
GO

EXEC BuscarCasa

--TraerCasas
CREATE PROCEDURE TraerCasas
	AS
	BEGIN
		SELECT * FROM Casa
	END 
	GO
EXEC TraerCasas

--Traer una sola casa(IdCasa)
CREATE PROCEDURE TraerUnaCasa
@idCasa int
	AS
	BEGIN
		SELECT * FROM Casa WHERE IdCasa = @idCasa
	END
	GO
EXEC TraerUnaCasa

--ObtenerSemanasDisponibles(idCasa,a�o,mes)
Create PROCEDURE ObtenerSemanasDisponibles
@IdCasa int,
@mes int,
@anio int
	AS
	BEGIN
		SELECT Semana FROM Alquiler WHERE IDCasa = @IdCasa AND Mes = @mes AND Anio = @anio
	END 
	GO
EXEC ObtenerSemanasDisponibles


--Reservar(idCasa,idUsuario,a�o,mes,semana)
Create PROCEDURE Reservar
@IdUser int,
@IdCasa int,
@anio int,
@mes int,
@semana int
	AS
	BEGIN 
		INSERT INTO Alquiler(Anio,Mes,IDUsuario,IDCasa,Semana) VALUES (@anio, @mes,@IdUser,@IdCasa,@semana) 
	END 
	GO
EXEC Reservar


--ObtenerSemanasDisponibles(idCasa, anio, mes, semana)
ALTER PROCEDURE ObtenerSemanasDisponibles
@IdCasa int,
@mes int,
@anio int
	AS
	BEGIN
		SELECT Semana FROM Alquiler WHERE IDCasa = @IdCasa AND Mes = @mes AND Anio = @anio
	END 
	GO
EXEC ObtenerSemanasDisponibles




--GuardarFavoritos(idUsuario,idCasa)
ALTER PROCEDURE GuardarFavoritos
@IdUser int,
@IdCasa int
	AS
	BEGIN 
		INSERT INTO Favorito (IDUsuario, IDCasa) VALUES (@IdUser, @IdCasa) 
	END 
	GO
EXEC GuardarFavoritos

--SacarDeFavoritos
	Create PROCEDURE SacarDeFavoritos
@IdUser int,
@IdCasa int
	AS
	BEGIN 
		Delete from Favorito where IDUsuario = @IdUser and IDCasa = @IdCasa
	END 
	GO
EXEC SacarDeFavoritos

CREATE PROCEDURE EsFavorito
    @IDUsuario INT,
    @IdCasa INT
AS
BEGIN
    DECLARE @EsFavorito BIT;

    SELECT @EsFavorito = CASE WHEN EXISTS (
        SELECT 1
        FROM Favorito
        WHERE IDUsuario = @IDUsuario AND IDCasa = @IdCasa
    ) THEN 1 ELSE 0 END;

    SELECT @EsFavorito AS EsFavorito;
END

--VerFavoritos(idUsuario)
ALTER PROCEDURE VerFavoritos
@IdUser int
	AS 
	BEGIN
		SELECT * FROM Favorito WHERE IDUsuario = @IdUser
		
	END 
	GO
EXEC VerFavoritos


--FiltroPileta(pileta)
CREATE PROCEDURE TienePileta
@Pileta bit
	AS
	BEGIN
		SELECT * FROM Casa WHERE Pileta = @Pileta
	END 
	GO
EXEC TienePileta

CREATE PROCEDURE TieneParrilla
@Parrilla bit
	AS
	BEGIN
		SELECT * FROM Casa WHERE Parrilla = @Parrilla
	END 
	GO
EXEC TieneParrilla

CREATE PROCEDURE TieneBalcon
@Balcon bit
	AS
	BEGIN
		SELECT * FROM Casa WHERE Balcon = @Balcon
	END 
	GO
EXEC TieneBalcon

CREATE PROCEDURE CantidadAmbientes
@cantAmbientes int
	AS
	BEGIN
		SELECT * FROM Casa WHERE Cantidad_ambientes = @cantAmbientes
	END
	GO
EXEC CantidadAmbientes
