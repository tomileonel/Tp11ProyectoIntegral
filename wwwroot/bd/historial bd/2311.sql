USE [master]
GO
/****** Object:  Database [TP11Integral]    Script Date: 23/11/2023 15:20:03 ******/
CREATE DATABASE [TP11Integral]
 CONTAINMENT = NONE
 ON  PRIMARY 

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TP11Integral].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TP11Integral] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TP11Integral] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TP11Integral] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TP11Integral] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TP11Integral] SET ARITHABORT OFF 
GO
ALTER DATABASE [TP11Integral] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TP11Integral] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TP11Integral] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TP11Integral] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TP11Integral] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TP11Integral] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TP11Integral] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TP11Integral] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TP11Integral] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TP11Integral] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TP11Integral] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TP11Integral] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TP11Integral] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TP11Integral] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TP11Integral] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TP11Integral] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TP11Integral] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TP11Integral] SET RECOVERY FULL 
GO
ALTER DATABASE [TP11Integral] SET  MULTI_USER 
GO
ALTER DATABASE [TP11Integral] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TP11Integral] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TP11Integral] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TP11Integral] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TP11Integral] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TP11Integral', N'ON'
GO
ALTER DATABASE [TP11Integral] SET QUERY_STORE = OFF
GO
USE [TP11Integral]
GO
/****** Object:  User [alumno]    Script Date: 23/11/2023 15:20:03 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Anio] [int] NOT NULL,
	[Mes] [int] NOT NULL,
	[Semana] [int] NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDCasa] [int] NOT NULL,
	[FechaOperacion] [date] NOT NULL,
 CONSTRAINT [PK_Alquiler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Casa]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Casa](
	[IDCasa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_casa] [varchar](50) NOT NULL,
	[Direccion_casa] [varchar](50) NOT NULL,
	[Precio] [real] NOT NULL,
	[Pileta] [bit] NOT NULL,
	[Parrila] [bit] NOT NULL,
	[Cantidad_ambientes] [int] NOT NULL,
	[Balcon] [bit] NOT NULL,
	[FotoCasa] [text] NOT NULL,
 CONSTRAINT [PK_CasaAAlquilar] PRIMARY KEY CLUSTERED 
(
	[IDCasa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorito]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorito](
	[IDFavoritos] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDCasa] [int] NOT NULL,
 CONSTRAINT [PK_Favorito] PRIMARY KEY CLUSTERED 
(
	[IDFavoritos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_usuario] [varchar](50) NOT NULL,
	[Apellido_usuario] [varchar](50) NOT NULL,
	[Telefono] [int] NULL,
	[Email] [varchar](50) NOT NULL,
	[Contrasena] [varchar](50) NOT NULL,
	[FotoDePerfil] [varchar](200) NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Casa] ON 

INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (5, N'Beach house', N'Brasil', 70000, 1, 1, 3, 1, N'https://www.abdesignstudioinc.com/hs-fs/hubfs/Modern_Beach_House_Montecito_Hero@2x.jpg?width=1920&name=Modern_Beach_House_Montecito_Hero@2x.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (6, N'Avellaneda', N'Argentina', 32000, 0, 0, 2, 0, N'https://www.estilosdeco.com/wp-content/uploads/2019/02/depto-pequeno-dormitorio-altillo-8-750x500.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (7, N'Palermo', N'Argentina', 40000, 0, 0, 1, 1, N'https://static1.sosiva451.com/59809921/7b2673cb-f13b-4c0e-9eb8-9aa34bf0ebbf_u_small.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (8, N'Relax', N'Argentina', 80000, 0, 1, 4, 1, N'https://imgar.zonapropcdn.com/avisos/1/00/52/09/20/73/720x532/1875914455.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (9, N'Burro', N'Chile', 60000, 0, 1, 3, 0, N'https://imgar.zonapropcdn.com/avisos/1/00/50/54/43/58/720x532/1878863146.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (10, N'Lux', N'USA', 200000, 1, 1, 4, 1, N'https://e00-expansion.uecdn.es/assets/multimedia/imagenes/2020/02/28/15828903346234.jpg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (11, N'The House', N'Argentina', 70000, 1, 0, 2, 0, N'https://plus.unsplash.com/premium_photo-1661883982941-50af7720a6ff?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Y2FzYSUyMG1pbGxvbmFyaWF8ZW58MHx8MHx8fDA%3D')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (12, N'Bosque', N'Brasil', 120000, 1, 1, 3, 1, N'https://www.lavanguardia.com/files/og_thumbnail/uploads/2021/11/19/61978d663043b.jpeg')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (13, N'Calm', N'Chile', 50000, 0, 1, 2, 0, N'https://hips.hearstapps.com/hmg-prod/images/casa-estilo-farmhouse-con-jardin9-1591015349.jpg?crop=1xw:0.8439609902475619xh;center,top&resize=1200:*')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (14, N'Family', N'Argentina', 90000, 0, 1, 1, 1, N'https://www.casaya.com.ar/promos/promo-1/promo_1_card.webp')
INSERT [dbo].[Casa] ([IDCasa], [Nombre_casa], [Direccion_casa], [Precio], [Pileta], [Parrila], [Cantidad_ambientes], [Balcon], [FotoCasa]) VALUES (15, N'Beauty', N'USA', 30000, 0, 0, 1, 1, N'https://i.pinimg.com/originals/e8/e6/da/e8e6da6de57945b807ea43df4a7c0d22.jpg')
SET IDENTITY_INSERT [dbo].[Casa] OFF
GO
SET IDENTITY_INSERT [dbo].[Registro] ON 

INSERT [dbo].[Registro] ([IDUsuario], [Nombre_usuario], [Apellido_usuario], [Telefono], [Email], [Contrasena], [FotoDePerfil]) VALUES (3, N'juan', N'perez', NULL, N'tomi@gmail.com', N'asda', NULL)
INSERT [dbo].[Registro] ([IDUsuario], [Nombre_usuario], [Apellido_usuario], [Telefono], [Email], [Contrasena], [FotoDePerfil]) VALUES (4, N'juan', N'perez', NULL, N'tomi@gmail.com', N'sdada', NULL)
INSERT [dbo].[Registro] ([IDUsuario], [Nombre_usuario], [Apellido_usuario], [Telefono], [Email], [Contrasena], [FotoDePerfil]) VALUES (5, N'juan', N'perez', NULL, N'tomi@gmail.com', N'dsad', NULL)
INSERT [dbo].[Registro] ([IDUsuario], [Nombre_usuario], [Apellido_usuario], [Telefono], [Email], [Contrasena], [FotoDePerfil]) VALUES (6, N'ads', N'a', NULL, N'asd@adsd', N'sad', NULL)
INSERT [dbo].[Registro] ([IDUsuario], [Nombre_usuario], [Apellido_usuario], [Telefono], [Email], [Contrasena], [FotoDePerfil]) VALUES (7, N'raian', N'hu', NULL, N'raian@raian', N'hola', NULL)
SET IDENTITY_INSERT [dbo].[Registro] OFF
GO
ALTER TABLE [dbo].[Favorito]  WITH CHECK ADD  CONSTRAINT [FK_Favorito_CasaAAlquilar] FOREIGN KEY([IDCasa])
REFERENCES [dbo].[Casa] ([IDCasa])
GO
ALTER TABLE [dbo].[Favorito] CHECK CONSTRAINT [FK_Favorito_CasaAAlquilar]
GO
/****** Object:  StoredProcedure [dbo].[CantidadAmbientes]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CantidadAmbientes]
@cantAmbientes int
	AS
	BEGIN
		SELECT * FROM Casa WHERE Cantidad_ambientes = @cantAmbientes
	END

GO
/****** Object:  StoredProcedure [dbo].[EditarPerfil]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarPerfil]
@nombreU Varchar(50),
@apellidoU Varchar(50),
@gmail VARCHAR(50),
@contrasena VARCHAR(50),
@telefono Int,
@foto varchar (200)
AS
	BEGIN
UPDATE Registro
SET Nombre_usuario = @nombreU, Apellido_usuario = @apellidoU,Telefono = @telefono, FotoDePerfil = @foto
Where Email = @gmail
	END 

GO
/****** Object:  StoredProcedure [dbo].[GuardarFavoritos]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarFavoritos]
@IdUser int,
@IdCasa int
	AS
	BEGIN 
		INSERT INTO Favorito (IDUsuario, IDCasa) VALUES (@IdUser, @IdCasa) 
	END 

GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
 @gmail VARCHAR(50),
 @contrasena VARCHAR(50)
	AS
	BEGIN
		Select * from Registro R where R.Email = @gmail and R.Contrasena = @contrasena
	END 

GO
/****** Object:  StoredProcedure [dbo].[ObtenerSemanasDisponibles]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerSemanasDisponibles]
@IdCasa int,
@mes int,
@anio int
	AS
	BEGIN
		SELECT Semana FROM Alquiler WHERE IDCasa = @IdCasa AND Mes = @mes AND Anio = @anio
	END 

GO
/****** Object:  StoredProcedure [dbo].[Registrarte]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Registrarte]
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
/****** Object:  StoredProcedure [dbo].[Reservar]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Reservar]
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
/****** Object:  StoredProcedure [dbo].[TraerCasas]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCasas]
	AS
	BEGIN
		SELECT * FROM Casa
	END 

GO
/****** Object:  StoredProcedure [dbo].[VerFavoritos]    Script Date: 23/11/2023 15:20:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerFavoritos]
@IdUser int
	AS 
	BEGIN
		SELECT * FROM Favorito WHERE IDUsuario = @IdUser
	END 

GO
USE [master]
GO
ALTER DATABASE [TP11Integral] SET  READ_WRITE 
GO
