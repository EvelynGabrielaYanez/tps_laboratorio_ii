USE [master]
GO
/****** Object:  Database [TPFinal_EvelynYanez]    Script Date: 21/11/2021 19:37:47 ******/
CREATE DATABASE [TPFinal_EvelynYanez]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPFinal_EvelynYanez', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TPFinal_EvelynYanez.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TPFinal_EvelynYanez_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TPFinal_EvelynYanez_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPFinal_EvelynYanez].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET  MULTI_USER 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET QUERY_STORE = OFF
GO
USE [TPFinal_EvelynYanez]
GO
/****** Object:  Table [dbo].[asistencias]    Script Date: 21/11/2021 19:37:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asistencias](
	[fecha] [datetime] NOT NULL,
	[dniUsuario] [int] NOT NULL,
	[grupo] [int] NOT NULL,
	[presente] [int] NOT NULL,
 CONSTRAINT [PK_asistencias] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC,
	[dniUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[delitos]    Script Date: 21/11/2021 19:37:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[delitos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dni] [int] NOT NULL,
	[tipo] [int] NOT NULL,
 CONSTRAINT [PK_delitos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[turnos]    Script Date: 21/11/2021 19:37:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[turnos](
	[turno] [int] NULL,
	[estado] [bit] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_turnos] PRIMARY KEY CLUSTERED 
(
	[fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 21/11/2021 19:37:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[dni] [int] NOT NULL,
	[nombre] [nchar](45) NOT NULL,
	[apellido] [nchar](45) NOT NULL,
	[telefono] [int] NOT NULL,
	[grupo] [int] NOT NULL,
	[denunciasRegistradas] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[asistencias] ([fecha], [dniUsuario], [grupo], [presente]) VALUES (CAST(N'2021-11-18T00:00:00.000' AS DateTime), 37429123, 3, 1)
INSERT [dbo].[asistencias] ([fecha], [dniUsuario], [grupo], [presente]) VALUES (CAST(N'2021-11-18T00:00:00.000' AS DateTime), 40429777, 3, 0)
INSERT [dbo].[asistencias] ([fecha], [dniUsuario], [grupo], [presente]) VALUES (CAST(N'2021-11-19T00:00:00.000' AS DateTime), 31429766, 4, 1)
INSERT [dbo].[asistencias] ([fecha], [dniUsuario], [grupo], [presente]) VALUES (CAST(N'2021-11-19T00:00:00.000' AS DateTime), 39429112, 4, 3)
GO
SET IDENTITY_INSERT [dbo].[delitos] ON 

INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (7, 31429766, 0)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (8, 34429765, 0)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (9, 34429765, 2)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (10, 39429767, 2)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (11, 36429768, 0)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (12, 36429768, 1)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (13, 39429112, 0)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (14, 39429112, 1)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (15, 37429444, 0)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (16, 37429444, 1)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (17, 37429444, 2)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (18, 37429123, 1)
INSERT [dbo].[delitos] ([id], [dni], [tipo]) VALUES (19, 40429777, 0)
SET IDENTITY_INSERT [dbo].[delitos] OFF
GO
INSERT [dbo].[turnos] ([turno], [estado], [fecha]) VALUES (3, 1, CAST(N'2021-11-18' AS Date))
INSERT [dbo].[turnos] ([turno], [estado], [fecha]) VALUES (4, 1, CAST(N'2021-11-19' AS Date))
INSERT [dbo].[turnos] ([turno], [estado], [fecha]) VALUES (NULL, 1, CAST(N'2021-11-20' AS Date))
INSERT [dbo].[turnos] ([turno], [estado], [fecha]) VALUES (NULL, 0, CAST(N'2021-11-21' AS Date))
GO
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (31429766, N'nombreUsuario1                               ', N'apellidoUsuario1                             ', 1566429774, 4, 2, CAST(N'2021-07-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (34429765, N'nombreUsuario2                               ', N'apellidoUsuario2                             ', 1566439685, 1, 1, CAST(N'2021-08-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (36429768, N'nombreUsuario4                               ', N'apellidoUsuario4                             ', 1578423714, 2, 10, CAST(N'2021-04-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (37429123, N'nombreUsuario4                               ', N'apellidoUsuario4                             ', 1578423714, 3, 10, CAST(N'2021-11-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (37429444, N'nombreUsuario4                               ', N'apellidoUsuario4                             ', 1578423714, 0, 10, CAST(N'2021-09-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (39429112, N'nombreUsuario4                               ', N'apellidoUsuario4                             ', 1578423714, 4, 10, CAST(N'2021-05-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (39429767, N'nombreUsuario3                               ', N'apellidoUsuario3                             ', 1566439685, 2, 5, CAST(N'2021-09-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[usuarios] ([dni], [nombre], [apellido], [telefono], [grupo], [denunciasRegistradas], [fechaIngreso], [activo]) VALUES (40429777, N'juan                                         ', N'perez                                        ', 1177536789, 3, 5, CAST(N'2021-11-18T00:00:00.000' AS DateTime), 1)
GO
ALTER TABLE [dbo].[asistencias]  WITH CHECK ADD  CONSTRAINT [FK_asistencias_usuarios] FOREIGN KEY([dniUsuario])
REFERENCES [dbo].[usuarios] ([dni])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[asistencias] CHECK CONSTRAINT [FK_asistencias_usuarios]
GO
ALTER TABLE [dbo].[delitos]  WITH CHECK ADD  CONSTRAINT [FK_delitos_usuarios] FOREIGN KEY([dni])
REFERENCES [dbo].[usuarios] ([dni])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[delitos] CHECK CONSTRAINT [FK_delitos_usuarios]
GO
USE [master]
GO
ALTER DATABASE [TPFinal_EvelynYanez] SET  READ_WRITE 
GO
