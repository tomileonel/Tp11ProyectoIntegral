--SP de iniciar sesion (gmail, contraseña) 
CREATE PROCEDURE IniciarSesion
 @gmail VARCHAR(50),
 @contraseña VARCHAR(50)
	AS
	BEGIN
		Select * from Registro R where R.Email = @gmail and R.Contraseña = @contraseña
	END 
	GO

EXEC IniciarSesion
--SP de registrarte (nombre usuario,apellido usuario, contraseña,gmail)
CREATE PROCEDURE Registrarte
@nombreU Varchar(50),
@apellidoU Varchar(50),
@gmail VARCHAR(50),
@contraseña VARCHAR(50)
	AS
	BEGIN
	Insert into Registro
	(Nombre_usuario,Apellido_usuario,Email,Contraseña)
	Values
	(@nombreU,@apellidoU,@gmail,@contraseña)
		
	END 
	GO

EXEC Registrarte
--SP de editar perfil (todo menos id 6 campos)
CREATE PROCEDURE EditarPerfil
@nombreU Varchar(50),
@apellidoU Varchar(50),
@gmail VARCHAR(50),
@contraseña VARCHAR(50),
@telefono Int,
@fotoPerfil varchar(200)
	AS
	BEGIN
UPDATE Registro
SET Nombre_usuario = @nombreU, Apellido_usuario = @apellidoU,Telefono = @telefono, FotoDePerfil = @fotoPerfil
Where Email = @gmail
	END 
	GO

EXEC EditarPerfil 

--BuscarCasa(todo de casa)
CREATE PROCEDURE BuscarCasa
@nombreCasa Varchar(50),
@direccion Varchar(50),
@precio Real,
@pileta bit,
@parrilla bit,
@CantidadAmbientes int,
@bacon bit
AS
BEGIN

IF @nombreCasa IS NOT NULL
BEGIN
	SET @nombreCasa = '%' + @nombreCasa + '%';
END

IF @direccion IS NOT NULL
BEGIN
	SET @direccion = '%' + @direccion + '%';
END

SELECT *
FROM Casa
WHERE
	(Nombre_casa LIKE @nombreCasa)
	AND (Direccion_casa LIKE @direccion)
	AND (Cantidad_ambientes IS NULL OR Cantidad_ambientes >= @CantidadAmbientes)
	AND (Precio IS NULL OR Precio >= @precio)
	AND (Pileta = @pileta)
	AND (Parrila = @parrilla)
	AND (Balcon = @bacon)

END
GO

EXEC BuscarCasa

--ObtenerSemanasDisponibles(idCasa,año,mes)
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


--Reservar(idCasa,idUsuario,año,mes,semana)
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
