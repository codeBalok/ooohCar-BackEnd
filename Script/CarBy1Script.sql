USE [master]
GO
/****** Object:  Database [CarBy1]    Script Date: 7/5/2020 3:36:16 PM ******/
CREATE DATABASE [CarBy1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarBy1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarBy1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarBy1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CarBy1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CarBy1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarBy1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarBy1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarBy1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarBy1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarBy1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarBy1] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarBy1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CarBy1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarBy1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarBy1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarBy1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarBy1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarBy1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarBy1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarBy1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarBy1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CarBy1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarBy1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarBy1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarBy1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarBy1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarBy1] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CarBy1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarBy1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarBy1] SET  MULTI_USER 
GO
ALTER DATABASE [CarBy1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarBy1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarBy1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarBy1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarBy1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarBy1] SET QUERY_STORE = OFF
GO
USE [CarBy1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CarBy1]
GO
/****** Object:  Table [dbo].[BodyType]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BodyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_BodyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colour]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Colour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[VehicleId] [int] NULL,
	[UserId] [int] NULL,
	[UserType] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cylinders]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Cylinders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](250) NULL,
	[VehicaleId] [nchar](10) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EngineDescription]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngineDescription](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_EngineDescription] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EngineSize]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngineSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Engine Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelEconomy]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelEconomy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Fuel Economy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelType]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_FuelType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ModelId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Make]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Make](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[LogoImage] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Make] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[YearId] [int] NOT NULL,
	[MakeId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelColour]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelColour](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModelId] [int] NULL,
	[ColourId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ModelColour] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 2) NULL,
	[VehicleId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transmission]    Script Date: 7/5/2020 3:36:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transmission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Transmission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 7/5/2020 3:36:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Odometers] [nvarchar](250) NOT NULL,
	[BodyTypeId] [int] NOT NULL,
	[VIN] [nvarchar](250) NULL,
	[ModelId] [int] NULL,
	[PriceId] [int] NULL,
	[CategoryId] [int] NULL,
	[RegistrationPlate] [nvarchar](250) NULL,
	[VehicalTypeId] [int] NULL,
	[LocationId] [int] NULL,
	[FuelTypeId] [int] NULL,
	[TransmissionId] [int] NULL,
	[CylindersId] [int] NULL,
	[FuelEconomyId] [int] NULL,
	[EngineDescriptionId] [int] NULL,
	[EngineSizeId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType]    Script Date: 7/5/2020 3:36:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Year]    Script Date: 7/5/2020 3:36:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Year](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Year] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BodyType] ON 
GO
INSERT [dbo].[BodyType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Bus', 1, 1, CAST(N'2020-07-05T02:22:16.693' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BodyType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'Cab Chassis', 1, 1, CAST(N'2020-07-05T02:22:38.507' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BodyType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Convertible', 1, 1, CAST(N'2020-07-05T02:22:58.150' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BodyType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'SUV', 1, 1, CAST(N'2020-07-05T02:23:22.177' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BodyType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'Sedan', 1, 1, CAST(N'2020-07-05T02:23:29.617' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[BodyType] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Luxury', 1, 1, CAST(N'2020-07-05T03:41:33.200' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Cylinders] ON 
GO
INSERT [dbo].[Cylinders] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'1', 1, 1, CAST(N'2020-07-05T04:02:22.340' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cylinders] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'2', 1, 1, CAST(N'2020-07-05T04:02:25.003' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cylinders] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'3', 1, 1, CAST(N'2020-07-05T04:02:27.317' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cylinders] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'4', 1, 1, CAST(N'2020-07-05T04:02:30.067' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Cylinders] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'5', 1, 1, CAST(N'2020-07-05T04:02:35.240' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Cylinders] OFF
GO
SET IDENTITY_INSERT [dbo].[EngineDescription] ON 
GO
INSERT [dbo].[EngineDescription] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'1.4T', 1, 1, CAST(N'2020-07-05T04:04:15.950' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[EngineDescription] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'1.5i', 1, 1, CAST(N'2020-07-05T04:04:40.200' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[EngineDescription] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'1.5T', 1, 1, CAST(N'2020-07-05T04:04:55.493' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[EngineDescription] OFF
GO
SET IDENTITY_INSERT [dbo].[EngineSize] ON 
GO
INSERT [dbo].[EngineSize] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'1000cc', 1, 1, CAST(N'2020-07-05T04:09:02.760' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[EngineSize] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'1020cc', 1, 1, CAST(N'2020-07-05T04:09:12.440' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[EngineSize] OFF
GO
SET IDENTITY_INSERT [dbo].[FuelEconomy] ON 
GO
INSERT [dbo].[FuelEconomy] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'4L/100km or less', 1, 1, CAST(N'2020-07-05T03:51:17.680' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelEconomy] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'4L/100km or less', 1, 1, CAST(N'2020-07-05T03:51:27.970' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelEconomy] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'5L/100km or less', 1, 1, CAST(N'2020-07-05T03:51:58.063' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelEconomy] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'7L/100km or less', 1, 1, CAST(N'2020-07-05T03:52:03.237' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelEconomy] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'9L/100km or less', 1, 1, CAST(N'2020-07-05T03:52:11.873' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[FuelEconomy] OFF
GO
SET IDENTITY_INSERT [dbo].[FuelType] ON 
GO
INSERT [dbo].[FuelType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Petrol', 1, 1, CAST(N'2020-07-05T03:47:22.490' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'Diesel', 1, 1, CAST(N'2020-07-05T03:48:08.760' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[FuelType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'LPG', 1, 1, CAST(N'2020-07-05T03:48:17.967' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[FuelType] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 
GO
INSERT [dbo].[Location] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'ACT', 1, 1, CAST(N'2020-07-05T02:16:22.997' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Location] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'New South Wale', 1, 1, CAST(N'2020-07-05T02:16:37.623' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Location] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Northern Territory', 1, 1, CAST(N'2020-07-05T02:17:00.860' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Location] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'South Australia', 1, 1, CAST(N'2020-07-05T02:18:04.690' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Make] ON 
GO
INSERT [dbo].[Make] ([Id], [Name], [LogoImage], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Audi', N'', 1, 1, CAST(N'2020-07-05T01:57:09.657' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Make] ([Id], [Name], [LogoImage], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'BMW', N'', 1, 1, CAST(N'2020-07-05T02:01:54.580' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Make] ([Id], [Name], [LogoImage], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Honda', N'', 1, 1, CAST(N'2020-07-05T02:02:02.660' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Make] ([Id], [Name], [LogoImage], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'TATA', N'', 1, 1, CAST(N'2020-07-05T02:02:11.237' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Make] ([Id], [Name], [LogoImage], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'Nissan', N'', 1, 1, CAST(N'2020-07-05T02:03:17.160' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Make] OFF
GO
SET IDENTITY_INSERT [dbo].[Model] ON 
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Sedan', 5, 2, 1, 1, CAST(N'2020-07-05T03:18:41.157' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'A1', 5, 1, 1, 1, CAST(N'2020-07-05T03:22:52.820' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'A2', 5, 1, 1, 1, CAST(N'2020-07-05T03:23:54.790' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'A3', 5, 1, 1, 1, CAST(N'2020-07-05T03:24:01.257' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'A4', 5, 1, 1, 1, CAST(N'2020-07-05T03:24:06.467' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (6, N'A5', 5, 1, 1, 1, CAST(N'2020-07-05T03:24:12.037' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (7, N'1 Series', 5, 2, 1, 1, CAST(N'2020-07-05T03:25:35.140' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (8, N'2 Series', 5, 2, 1, 1, CAST(N'2020-07-05T03:25:44.173' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (9, N'3 Series', 5, 2, 1, 1, CAST(N'2020-07-05T03:25:53.123' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (10, N'4 Series', 5, 2, 1, 1, CAST(N'2020-07-05T03:26:02.953' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (11, N'i20', 5, 3, 1, 1, CAST(N'2020-07-05T03:27:18.520' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (12, N'i10', 5, 3, 1, 1, CAST(N'2020-07-05T03:27:31.527' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (13, N'i30', 5, 3, 1, 1, CAST(N'2020-07-05T03:27:42.477' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Model] ([Id], [Name], [YearId], [MakeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (14, N'i40', 5, 3, 1, 1, CAST(N'2020-07-05T03:27:49.630' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
SET IDENTITY_INSERT [dbo].[Transmission] ON 
GO
INSERT [dbo].[Transmission] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'AMT', 1, 1, CAST(N'2020-07-05T04:01:27.593' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Transmission] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'Automatic', 1, 1, CAST(N'2020-07-05T04:01:40.753' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Transmission] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Manual', 1, 1, CAST(N'2020-07-05T04:01:59.830' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Transmission] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'LAMBORGHINI', N'400', 5, N'ABCDEFG123', 2, NULL, 1, N'ABCD1111', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-07-05T04:10:47.533' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'FERRARI RED CAR', N'400', 5, N'ABCDEFG123', 7, NULL, 1, N'ABCD1111', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-07-05T04:11:46.570' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'VOLKSWAGEN SCIROCCO 2016', N'400', 5, N'ABCDEFG123', 7, NULL, 1, N'ABCD1111', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-07-05T04:12:11.747' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'PORSCHE CAYEN LAST', N'400', 5, N'ABCDEFG123', 4, NULL, 1, N'ABCD1111', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-07-05T04:12:30.777' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'LEXUS GS F', N'400', 5, N'ABCDEFG123', 11, NULL, 1, N'ABCD1111', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, CAST(N'2020-07-05T04:13:33.920' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vehicle] ([Id], [Name], [Odometers], [BodyTypeId], [VIN], [ModelId], [PriceId], [CategoryId], [RegistrationPlate], [VehicalTypeId], [LocationId], [FuelTypeId], [TransmissionId], [CylindersId], [FuelEconomyId], [EngineDescriptionId], [EngineSizeId], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (6, N'BMW E46 M3 DISKI SERIE', N'400', 5, N'ABCDEFG123', 11, NULL, 1, N'ABCD1111', 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, CAST(N'2020-07-05T04:14:30.380' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType] ON 
GO
INSERT [dbo].[VehicleType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'New Car', 1, 1, CAST(N'2020-07-05T02:14:00.633' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[VehicleType] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'Old Car', 1, 1, CAST(N'2020-07-05T02:14:07.270' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[VehicleType] OFF
GO
SET IDENTITY_INSERT [dbo].[Year] ON 
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'2015', 1, 1, CAST(N'2020-07-05T02:11:06.890' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'2016', 1, 1, CAST(N'2020-07-05T02:11:10.587' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'2017', 1, 1, CAST(N'2020-07-05T02:11:15.257' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'2018', 1, 1, CAST(N'2020-07-05T02:11:20.660' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (5, N'2019', 1, 1, CAST(N'2020-07-05T02:11:23.163' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Year] ([Id], [Name], [IsActive], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (6, N'2020', 1, 1, CAST(N'2020-07-05T02:11:27.290' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Year] OFF
GO
/****** Object:  Index [IX_Images_ModelId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Images_ModelId] ON [dbo].[Images]
(
	[ModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Model_MakeId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Model_MakeId] ON [dbo].[Model]
(
	[MakeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Model_YearId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Model_YearId] ON [dbo].[Model]
(
	[YearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModelColour_ColourId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModelColour_ColourId] ON [dbo].[ModelColour]
(
	[ColourId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ModelColour_ModelId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_ModelColour_ModelId] ON [dbo].[ModelColour]
(
	[ModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Price_VehicleId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Price_VehicleId] ON [dbo].[Price]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_BodyTypeId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_BodyTypeId] ON [dbo].[Vehicle]
(
	[BodyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_CategoryId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_CategoryId] ON [dbo].[Vehicle]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_CylindersId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_CylindersId] ON [dbo].[Vehicle]
(
	[CylindersId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_EngineDescriptionId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_EngineDescriptionId] ON [dbo].[Vehicle]
(
	[EngineDescriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_EngineSizeId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_EngineSizeId] ON [dbo].[Vehicle]
(
	[EngineSizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_FuelEconomyId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_FuelEconomyId] ON [dbo].[Vehicle]
(
	[FuelEconomyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_FuelTypeId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_FuelTypeId] ON [dbo].[Vehicle]
(
	[FuelTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_LocationId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_LocationId] ON [dbo].[Vehicle]
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_TransmissionId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_TransmissionId] ON [dbo].[Vehicle]
(
	[TransmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_VehicalTypeId]    Script Date: 7/5/2020 3:36:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_VehicalTypeId] ON [dbo].[Vehicle]
(
	[VehicalTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_ModelId]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Make_Id] FOREIGN KEY([MakeId])
REFERENCES [dbo].[Make] ([Id])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Make_Id]
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Year_Id] FOREIGN KEY([YearId])
REFERENCES [dbo].[Year] ([Id])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Year_Id]
GO
ALTER TABLE [dbo].[ModelColour]  WITH CHECK ADD  CONSTRAINT [FK_ModelColour_Colour] FOREIGN KEY([ColourId])
REFERENCES [dbo].[Colour] ([Id])
GO
ALTER TABLE [dbo].[ModelColour] CHECK CONSTRAINT [FK_ModelColour_Colour]
GO
ALTER TABLE [dbo].[ModelColour]  WITH CHECK ADD  CONSTRAINT [FK_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
GO
ALTER TABLE [dbo].[ModelColour] CHECK CONSTRAINT [FK_ModelId]
GO
ALTER TABLE [dbo].[Price]  WITH CHECK ADD  CONSTRAINT [FK_Price] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle] ([Id])
GO
ALTER TABLE [dbo].[Price] CHECK CONSTRAINT [FK_Price]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Body_Type] FOREIGN KEY([BodyTypeId])
REFERENCES [dbo].[BodyType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Body_Type]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Category_Id] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Category_Id]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Cylinders] FOREIGN KEY([CylindersId])
REFERENCES [dbo].[Cylinders] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Cylinders]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Engin_Description] FOREIGN KEY([EngineDescriptionId])
REFERENCES [dbo].[EngineDescription] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Engin_Description]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Engine_Size] FOREIGN KEY([EngineSizeId])
REFERENCES [dbo].[EngineSize] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Engine_Size]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Fuel_Economy] FOREIGN KEY([FuelEconomyId])
REFERENCES [dbo].[FuelEconomy] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Fuel_Economy]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Fuel_Type] FOREIGN KEY([FuelTypeId])
REFERENCES [dbo].[FuelType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Fuel_Type]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Location]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Transmission] FOREIGN KEY([TransmissionId])
REFERENCES [dbo].[Transmission] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Transmission]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_ModelId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Type] FOREIGN KEY([VehicalTypeId])
REFERENCES [dbo].[VehicleType] ([Id])
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Type]
GO
USE [master]
GO
ALTER DATABASE [CarBy1] SET  READ_WRITE 
GO
