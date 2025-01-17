USE [master]
GO
/****** Object:  Database [Test]    Script Date: 10/10/2022 06:15:02 PM ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/10/2022 06:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IDCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IDCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 10/10/2022 06:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IDProducto] [int] IDENTITY(1,1) NOT NULL,
	[IDCategoria] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Precio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IDProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IDCategoria], [Codigo], [Nombre], [Estado]) VALUES (1, N'TEC', N'TECLADO', 1)
INSERT [dbo].[Categoria] ([IDCategoria], [Codigo], [Nombre], [Estado]) VALUES (2, N'MOU', N'MOUSE', 1)
INSERT [dbo].[Categoria] ([IDCategoria], [Codigo], [Nombre], [Estado]) VALUES (3, N'COM', N'COMPUTADORA', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IDProducto], [IDCategoria], [Nombre], [Precio]) VALUES (1, 1, N'TECLADO XYZ', CAST(35.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([IDProducto], [IDCategoria], [Nombre], [Precio]) VALUES (2, 2, N'MOUSE PHP 254', CAST(75.00 AS Decimal(18, 2)))
INSERT [dbo].[Producto] ([IDProducto], [IDCategoria], [Nombre], [Precio]) VALUES (3, 3, N'PC GAMER XYZ', CAST(2546.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
/****** Object:  StoredProcedure [dbo].[Categoria_Listar]    Script Date: 10/10/2022 06:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Categoria_Listar]
(
	@idEstado int
)
as
begin
	select *
	from Categoria
	where Estado = @idEstado
end
GO
/****** Object:  StoredProcedure [dbo].[Producto_Listar]    Script Date: 10/10/2022 06:15:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Producto_Listar]
as
begin
	select *
	from Producto
end
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
-----------Probar que funcione corectamente los SP
-----------Por buenas practicas, abré otra pestaña.
use Test;

exec Categoria_Listar 1
exec Producto_Listar

--Categoria_Listar se edito

--Procedimiento almacenado del 3 y medio
create procedure Producto_Agregar
(
	@IDCategoria int,
	@Nombre varchar(50),
	@Precio decimal (12, 2)
)
as
begin
	INSERT INTO [dbo].[Producto]
		([IDCategoria]
		,[Nombre]
		,[Precio])
	VALUES
		(@IDCategoria
		,@Nombre
		,@Precio)
end

--Probando Sp
select * from Producto;