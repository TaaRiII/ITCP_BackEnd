USE [master]
GO
/****** Object:  Database [ITCPDB]    Script Date: 11/11/2022 9:53:01 PM ******/
CREATE DATABASE [ITCPDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITCPDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ITCPDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ITCPDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ITCPDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ITCPDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITCPDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITCPDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITCPDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITCPDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITCPDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITCPDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITCPDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITCPDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITCPDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITCPDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITCPDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITCPDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITCPDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITCPDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITCPDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITCPDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ITCPDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITCPDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITCPDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITCPDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITCPDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITCPDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ITCPDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITCPDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ITCPDB] SET  MULTI_USER 
GO
ALTER DATABASE [ITCPDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITCPDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITCPDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITCPDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ITCPDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ITCPDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITCPDB', N'ON'
GO
ALTER DATABASE [ITCPDB] SET QUERY_STORE = OFF
GO
USE [ITCPDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/11/2022 9:53:01 PM ******/
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
/****** Object:  Table [dbo].[bussinessTypes]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bussinessTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_bussinessTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNumber] [bigint] NULL,
	[Email] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[companyContactPeople]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companyContactPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNumber] [bigint] NULL,
	[Nationality] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_companyContactPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departments]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNumber] [bigint] NULL,
	[Address] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fileUploads]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fileUploads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[BPP] [nvarchar](max) NULL,
	[PENCOM] [nvarchar](max) NULL,
	[ITF] [nvarchar](max) NULL,
	[NSITF] [nvarchar](max) NULL,
	[AUDITED] [nvarchar](max) NULL,
	[CAC] [nvarchar](max) NULL,
	[PC] [nvarchar](max) NULL,
	[CV] [nvarchar](max) NULL,
 CONSTRAINT [PK_fileUploads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genComInfos]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genComInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[PrimaryContactPersonName] [nvarchar](max) NULL,
	[PrimaryContactPersonMobile] [bigint] NULL,
	[TelPhone] [bigint] NULL,
	[Email] [nvarchar](max) NULL,
	[CoporateHeadQuater] [nvarchar](max) NULL,
	[State] [int] NULL,
	[OfficeLocation] [nvarchar](max) NULL,
	[RCNumber] [int] NULL,
	[NameOfCEO] [nvarchar](max) NULL,
	[CEOPhoneNo] [bigint] NULL,
	[CEOEmail] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_genComInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[managements]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[managements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[TechnicalSkill] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_managements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[serviceCategories]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[serviceCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_serviceCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shareholders]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shareholders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PerShares] [int] NULL,
	[ClientId] [int] NULL,
	[status] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
 CONSTRAINT [PK_shareholders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/11/2022 9:53:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[role] [nvarchar](max) NULL,
	[PhoneNo] [bigint] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[Email] [nvarchar](max) NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[Password] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Username] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221024175805_ITCPBackend', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221027191313_SecondMigration', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221027191842_thirdtime', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221028165453_FourthMigration', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221028184957_FifthMigration', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221107153813_sixth', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221110181421_Seventh', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221110181558_seventhagain', N'6.0.10')
GO
SET IDENTITY_INSERT [dbo].[bussinessTypes] ON 

INSERT [dbo].[bussinessTypes] ([Id], [Name], [ClientId], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'Sports', 1, 1, N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[bussinessTypes] ([Id], [Name], [ClientId], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (2, N'ALi', 3, 1, N'system', CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2), N'system', CAST(N'2022-11-10T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[bussinessTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'Client1', 300, N'client@gmail.com', N'client123', N'client123', N'client', 1, N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (2, N'Client1', 300, N'client@gmail.com', N'client123', N'client123', N'client', 1, N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2), N'system', CAST(N'2022-10-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (3, N'string', 0, N'string', N'string', N'string', N'string', 0, N'string', CAST(N'2022-11-10T17:52:50.4840000' AS DateTime2), N'string', CAST(N'2022-11-10T17:52:50.4840000' AS DateTime2))
INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (4, N'Ali Ahmad', 33005340, N'Ali@gmail.com', NULL, N'Ali123123', NULL, 0, N'System', CAST(N'2022-11-11T20:34:41.5093983' AS DateTime2), NULL, NULL)
INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (5, N'Ahmad Khan', 3345650, N'AhmadKhan@gmail.com', NULL, N'Ahmad123123', NULL, 0, N'System', CAST(N'2022-11-11T20:47:12.0689618' AS DateTime2), NULL, NULL)
INSERT [dbo].[clients] ([Id], [Name], [PhoneNumber], [Email], [Username], [Password], [Role], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (6, N'Hamid Khan', 323450, N'natiqbutt786@gmail.com', N'hamidkhan123', N'hamidkhan123', N'Client', 1, N'System', CAST(N'2022-11-11T21:27:35.1918808' AS DateTime2), N'Email Verification', CAST(N'2022-11-11T21:44:02.3370216' AS DateTime2))
SET IDENTITY_INSERT [dbo].[clients] OFF
GO
SET IDENTITY_INSERT [dbo].[genComInfos] ON 

INSERT [dbo].[genComInfos] ([Id], [Url], [PrimaryContactPersonName], [PrimaryContactPersonMobile], [TelPhone], [Email], [CoporateHeadQuater], [State], [OfficeLocation], [RCNumber], [NameOfCEO], [CEOPhoneNo], [CEOEmail], [ClientId], [status], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'xyz.com', N'Person1', 3000, 30390, N'info@xyz.com', N'ff', 2, N'Lahore', 2320, N'Ceo', 9870, N'ceo@xyz.com', 1, 1, N'system', CAST(N'2022-11-03T22:58:13.2706265' AS DateTime2), N'string', CAST(N'2022-11-03T17:55:48.3460000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[genComInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [role], [PhoneNo], [CreatedBy], [CreatedDate], [Email], [ModifyBy], [ModifyDate], [Password], [Status], [Username]) VALUES (1, N'Natiq', N'Naeem', 30000, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL)
INSERT [dbo].[Users] ([Id], [Name], [role], [PhoneNo], [CreatedBy], [CreatedDate], [Email], [ModifyBy], [ModifyDate], [Password], [Status], [Username]) VALUES (2, N'Naeem', N'Qadeer', 3111, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, 0, NULL)
INSERT [dbo].[Users] ([Id], [Name], [role], [PhoneNo], [CreatedBy], [CreatedDate], [Email], [ModifyBy], [ModifyDate], [Password], [Status], [Username]) VALUES (3, N'string', N'string', 0, N'string', CAST(N'2022-11-01T23:36:57.0114894' AS DateTime2), N'string', N'system', CAST(N'2022-11-01T18:36:23.5510000' AS DateTime2), N'string', 1, N'string')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_bussinessTypes_ClientId]    Script Date: 11/11/2022 9:53:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_bussinessTypes_ClientId] ON [dbo].[bussinessTypes]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bussinessTypes]  WITH CHECK ADD  CONSTRAINT [FK_bussinessTypes_clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[clients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bussinessTypes] CHECK CONSTRAINT [FK_bussinessTypes_clients_ClientId]
GO
USE [master]
GO
ALTER DATABASE [ITCPDB] SET  READ_WRITE 
GO
