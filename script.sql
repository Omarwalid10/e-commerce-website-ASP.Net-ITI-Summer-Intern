USE [master]
GO
/****** Object:  Database [Market_Place]    Script Date: 9/5/2023 7:11:53 PM ******/
CREATE DATABASE [Market_Place]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Market_Place', FILENAME = N'F:\SQL\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Market_Place.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Market_Place_log', FILENAME = N'F:\SQL\MSSQL15.MSSQLSERVER01\MSSQL\DATA\Market_Place_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Market_Place] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Market_Place].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Market_Place] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Market_Place] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Market_Place] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Market_Place] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Market_Place] SET ARITHABORT OFF 
GO
ALTER DATABASE [Market_Place] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Market_Place] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Market_Place] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Market_Place] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Market_Place] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Market_Place] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Market_Place] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Market_Place] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Market_Place] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Market_Place] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Market_Place] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Market_Place] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Market_Place] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Market_Place] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Market_Place] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Market_Place] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Market_Place] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Market_Place] SET RECOVERY FULL 
GO
ALTER DATABASE [Market_Place] SET  MULTI_USER 
GO
ALTER DATABASE [Market_Place] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Market_Place] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Market_Place] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Market_Place] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Market_Place] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Market_Place] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Market_Place', N'ON'
GO
ALTER DATABASE [Market_Place] SET QUERY_STORE = OFF
GO
USE [Market_Place]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[ordersId] [int] NOT NULL,
	[productsId] [int] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[ordersId] ASC,
	[productsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[price] [int] NOT NULL,
	[image] [nvarchar](max) NOT NULL,
	[sellerId] [int] NOT NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sellers]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sellers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_sellers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 9/5/2023 7:11:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[passward] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230830125446_intial6', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230831144846_intial7', N'7.0.10')
GO
SET IDENTITY_INSERT [dbo].[products] ON 

INSERT [dbo].[products] ([Id], [name], [price], [image], [sellerId]) VALUES (36, N'chair', 40, N'f5044764-861e-4e94-ab98-ff9126ac5cddproduct-2.png', 13)
INSERT [dbo].[products] ([Id], [name], [price], [image], [sellerId]) VALUES (37, N'desh', 55, N'a481e5fa-0df7-4168-8452-7eb57831a25fbowl-3.png', 13)
INSERT [dbo].[products] ([Id], [name], [price], [image], [sellerId]) VALUES (38, N'chair', 500, N'588b4378-d226-41ba-a6c8-d10c643b4e82product-3.png', 15)
INSERT [dbo].[products] ([Id], [name], [price], [image], [sellerId]) VALUES (39, N'chair', 6000, N'7a0265fe-0a96-41c9-8903-30c39d0bde44img-grid-3.jpg', 15)
SET IDENTITY_INSERT [dbo].[products] OFF
GO
SET IDENTITY_INSERT [dbo].[sellers] ON 

INSERT [dbo].[sellers] ([Id], [Name], [Email], [password]) VALUES (11, N'Omar Walid', N'omar@gmail.com', N'1234')
INSERT [dbo].[sellers] ([Id], [Name], [Email], [password]) VALUES (12, N'mo salah', N'mo@gmail.com', N'1234')
INSERT [dbo].[sellers] ([Id], [Name], [Email], [password]) VALUES (13, N'messi', N'messi@gmail.com', N'1234')
INSERT [dbo].[sellers] ([Id], [Name], [Email], [password]) VALUES (14, N'Gemy', N'Gemy@gmail.com', N'1234')
INSERT [dbo].[sellers] ([Id], [Name], [Email], [password]) VALUES (15, N'mohamed', N'mohamed@gmail.com', N'1234')
SET IDENTITY_INSERT [dbo].[sellers] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([Id], [Name], [Email], [passward]) VALUES (1, N'Omar ', N'Omar@gmail.com', N'11111')
INSERT [dbo].[users] ([Id], [Name], [Email], [passward]) VALUES (2, N'Omar ', N'Omar1@gmail.com', N'1234')
SET IDENTITY_INSERT [dbo].[users] OFF
GO
/****** Object:  Index [IX_OrderProduct_productsId]    Script Date: 9/5/2023 7:11:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_productsId] ON [dbo].[OrderProduct]
(
	[productsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_orders_userId]    Script Date: 9/5/2023 7:11:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_orders_userId] ON [dbo].[orders]
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_products_sellerId]    Script Date: 9/5/2023 7:11:53 PM ******/
CREATE NONCLUSTERED INDEX [IX_products_sellerId] ON [dbo].[products]
(
	[sellerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_orders_ordersId] FOREIGN KEY([ordersId])
REFERENCES [dbo].[orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_orders_ordersId]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_products_productsId] FOREIGN KEY([productsId])
REFERENCES [dbo].[products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_products_productsId]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_users_userId] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_users_userId]
GO
ALTER TABLE [dbo].[products]  WITH CHECK ADD  CONSTRAINT [FK_products_sellers_sellerId] FOREIGN KEY([sellerId])
REFERENCES [dbo].[sellers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[products] CHECK CONSTRAINT [FK_products_sellers_sellerId]
GO
USE [master]
GO
ALTER DATABASE [Market_Place] SET  READ_WRITE 
GO
