USE [master]
GO
/****** Object:  Database [MovieDB]    Script Date: 8/18/2023 11:18:31 PM ******/
CREATE DATABASE [MovieDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\MovieDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\MovieDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MovieDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieDB] SET  MULTI_USER 
GO
ALTER DATABASE [MovieDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MovieDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieDB', N'ON'
GO
ALTER DATABASE [MovieDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [MovieDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MovieDB]
GO
/****** Object:  User [dev]    Script Date: 8/18/2023 11:18:31 PM ******/
CREATE USER [dev] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dev]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[active] [bit] NOT NULL,
	[role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[address] [nvarchar](200) NULL,
	[gender] [char](1) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerBankAccount]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerBankAccount](
	[accountNo] [nvarchar](100) NOT NULL,
	[bankRoute] [bigint] NOT NULL,
	[accountName] [nvarchar](100) NOT NULL,
	[bankName] [nvarchar](200) NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_CustomerBankAccount] PRIMARY KEY CLUSTERED 
(
	[accountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDeliveryDTO]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDeliveryDTO](
	[customerId] [int] NULL,
	[customerSubscriptionId] [int] NULL,
	[firstName] [nvarchar](100) NULL,
	[lastName] [nvarchar](100) NULL,
	[gender] [nchar](10) NULL,
	[DVDCatalogId] [int] NULL,
	[title] [nvarchar](100) NULL,
	[status] [nchar](10) NULL,
	[rank] [int] NULL,
	[code] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerSubscription]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSubscription](
	[customerId] [int] NOT NULL,
	[subscriptId] [int] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CustomerSubscription] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVDCatalog]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDCatalog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[description] [nvarchar](1000) NULL,
	[genre] [nvarchar](200) NULL,
	[language] [nvarchar](50) NULL,
	[noDisk] [int] NOT NULL,
	[stockQty] [int] NOT NULL,
	[releasedDate] [date] NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_DVDCatalog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVDCopy]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDCopy](
	[status] [nchar](10) NULL,
	[code] [nvarchar](100) NOT NULL,
	[DVDCatalogId] [int] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DVDCopy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVDStatus]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVDStatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[deliveredDate] [date] NULL,
	[returnedDate] [date] NULL,
	[customerSubscriptionId] [int] NULL,
	[DVDCode] [nvarchar](100) NULL,
	[DVDCatalogId] [int] NULL,
 CONSTRAINT [PK_DVDStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[amount] [money] NULL,
	[paymentDate] [date] NULL,
	[paymentType] [int] NULL,
	[customerSubscriptionId] [int] NOT NULL,
	[billingAddress] [nvarchar](200) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestedDVD]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestedDVD](
	[title] [nvarchar](100) NULL,
	[submissionDate] [date] NOT NULL,
	[id] [int] NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_RequestedDVD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscription]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscription](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[atHomeDVD] [int] NOT NULL,
	[noDVDPerMonth] [int] NOT NULL,
	[price] [money] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[isDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Watchlist]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Watchlist](
	[rank] [int] NULL,
	[DVDCatalogId] [int] NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_Watchlist_1] PRIMARY KEY CLUSTERED 
(
	[DVDCatalogId] ASC,
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([email], [password], [active], [role]) VALUES (N'admin@mail.com', N'123', 1, N'admin')
GO
INSERT [dbo].[Account] ([email], [password], [active], [role]) VALUES (N'chan@mail.com', N'123', 1, N'user')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([id], [firstName], [lastName], [address], [gender], [email]) VALUES (5, N'sokha', N'chan', N'', N'M', N'chan@mail.com')
GO
INSERT [dbo].[Customer] ([id], [firstName], [lastName], [address], [gender], [email]) VALUES (7, N'admin', N'sos', NULL, N'M', N'admin@mail.com')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerSubscription] ON 
GO
INSERT [dbo].[CustomerSubscription] ([customerId], [subscriptId], [startDate], [endDate], [id]) VALUES (5, 6, CAST(N'2023-08-12' AS Date), CAST(N'2023-09-05' AS Date), 12)
GO
SET IDENTITY_INSERT [dbo].[CustomerSubscription] OFF
GO
SET IDENTITY_INSERT [dbo].[DVDCatalog] ON 
GO
INSERT [dbo].[DVDCatalog] ([id], [title], [description], [genre], [language], [noDisk], [stockQty], [releasedDate], [isDeleted]) VALUES (3, N'Heart of Stone', N'Gal Gadot returns to Netflix for another action flick after scoring big with 2021''s Red Notice, where she matched wits and fists with Ryan Reynolds and Dwayne Johnson. In Heart of Stone, Gadot takes center stage as part of a covert international peacekeeping agency tasked with stopping a hacker from getting hold of a dangerous weapon. Jamie Dornan and Alia Bhatt co-star with director Tom Harper (The Aeronauts, "Peaky Blinders") at the helm.', N'Action, Crime, Thriller', N'English', 3, 10, CAST(N'2023-08-11' AS Date), 0)
GO
INSERT [dbo].[DVDCatalog] ([id], [title], [description], [genre], [language], [noDisk], [stockQty], [releasedDate], [isDeleted]) VALUES (4, N'hsd', N'sd', N'hd', N'fgd', 3, 43, CAST(N'2023-08-24' AS Date), 1)
GO
INSERT [dbo].[DVDCatalog] ([id], [title], [description], [genre], [language], [noDisk], [stockQty], [releasedDate], [isDeleted]) VALUES (5, N'Red, White & Royal Blue', N'Thwoorp your fans for Prime Video daring to make a same-sex rom-com that ventures into the White House and imports a Royal to make it an international incident. Plus Uma Thurman as the President! The secret weapon here could be director/co-writer Matthew López; he cut his teeth writing for Aaron Sorkin, who knows how to walk and talk.', N'Comedy, Romance', N'English', 1, 15, CAST(N'2023-08-11' AS Date), 0)
GO
INSERT [dbo].[DVDCatalog] ([id], [title], [description], [genre], [language], [noDisk], [stockQty], [releasedDate], [isDeleted]) VALUES (6, N'The Pod Generation', N'A couple are about to become the ultimate detached parents, raising their unborn child in an artificial womb that exists outside the body. Emilia Clarke and Chiwetel Ejiofor star in this sci-fi comedy that premiered at Sundance earlier this year.', N'Sci-fi, Comedy, Romance', N'English', 2, 5, CAST(N'2023-08-10' AS Date), 0)
GO
INSERT [dbo].[DVDCatalog] ([id], [title], [description], [genre], [language], [noDisk], [stockQty], [releasedDate], [isDeleted]) VALUES (7, N'The Last Voyage of the Demeter', N'Bram Stoker’s seminal "Dracula" has seen its fair amount of film adaptations over the years, but even the biggest goths may have forgotten about the book''s single chapter that details the Transylvanian monster''s passage from the Carpathian mountains to London. ''The Last Voyage of the Demeter'' plans to jog our memories with this film that seems to take its inspiration from shows like "The Terror" and Ridley Scott''s Alien. Director André Øvredal''s impeccable genre track record (Troll Hunter, The Autopsy of Jane Doe) has us excited to watch this cast of characters meet their doom.', N'Horror', N'English', 1, 15, CAST(N'2023-08-11' AS Date), 0)
GO
SET IDENTITY_INSERT [dbo].[DVDCatalog] OFF
GO
SET IDENTITY_INSERT [dbo].[DVDCopy] ON 
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'O         ', N'2', 3, 0, 3)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'1', 3, 1, 4)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'O         ', N'3', 3, 0, 5)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'4', 3, 0, 6)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'5', 3, 0, 7)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'6', 3, 0, 8)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'7', 3, 0, 9)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'8', 3, 0, 10)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'9', 3, 0, 11)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'O         ', N'10', 3, 0, 12)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'O         ', N'11', 3, 0, 13)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'1', 5, 0, 14)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'12', 5, 0, 15)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'13', 5, 0, 16)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'14', 5, 0, 17)
GO
INSERT [dbo].[DVDCopy] ([status], [code], [DVDCatalogId], [isDeleted], [id]) VALUES (N'A         ', N'15', 5, 0, 18)
GO
SET IDENTITY_INSERT [dbo].[DVDCopy] OFF
GO
SET IDENTITY_INSERT [dbo].[DVDStatus] ON 
GO
INSERT [dbo].[DVDStatus] ([id], [deliveredDate], [returnedDate], [customerSubscriptionId], [DVDCode], [DVDCatalogId]) VALUES (2, CAST(N'2023-08-17' AS Date), CAST(N'2023-08-18' AS Date), 12, N'10', 3)
GO
INSERT [dbo].[DVDStatus] ([id], [deliveredDate], [returnedDate], [customerSubscriptionId], [DVDCode], [DVDCatalogId]) VALUES (6, CAST(N'2023-08-18' AS Date), NULL, 12, N'3', 3)
GO
SET IDENTITY_INSERT [dbo].[DVDStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 
GO
INSERT [dbo].[Payment] ([amount], [paymentDate], [paymentType], [customerSubscriptionId], [billingAddress], [id]) VALUES (3.0000, CAST(N'2023-08-12' AS Date), 1, 12, N'sfsdf', 3)
GO
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentType] ON 
GO
INSERT [dbo].[PaymentType] ([id], [description]) VALUES (1, N'B')
GO
SET IDENTITY_INSERT [dbo].[PaymentType] OFF
GO
INSERT [dbo].[RequestedDVD] ([title], [submissionDate], [id], [customerId]) VALUES (N'sdf', CAST(N'2023-08-19' AS Date), 0, 5)
GO
SET IDENTITY_INSERT [dbo].[Subscription] ON 
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (1, 34, 23, 4.0000, N'lida', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (2, 3, 3, 3.0000, N'sokha', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (3, 3, 3, 3.0000, N'Lida mao', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (4, 3, 3, 3.0000, N'Lida mao', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (5, 3, 33, 3.0000, N'Lida maossss', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (6, 4, 6, 15.0000, N'Platina', 0)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (7, 3, 3, 3.0000, N'asdf', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (8, 3, 3, 3.0000, N'asdf', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (9, 3, 5, 13.0000, N'Gold', 0)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (10, 2, 4, 11.0000, N'Silver', 0)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (11, 0, 0, 0.0000, N'sd', 1)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (12, 1, 3, 9.0000, N'Bronze', 0)
GO
INSERT [dbo].[Subscription] ([id], [atHomeDVD], [noDVDPerMonth], [price], [name], [isDeleted]) VALUES (13, 1, 2, 7.0000, N'Basic', 0)
GO
SET IDENTITY_INSERT [dbo].[Subscription] OFF
GO
INSERT [dbo].[Watchlist] ([rank], [DVDCatalogId], [customerId]) VALUES (1, 3, 5)
GO
INSERT [dbo].[Watchlist] ([rank], [DVDCatalogId], [customerId]) VALUES (1, 5, 5)
GO
INSERT [dbo].[Watchlist] ([rank], [DVDCatalogId], [customerId]) VALUES (1, 6, 5)
GO
INSERT [dbo].[Watchlist] ([rank], [DVDCatalogId], [customerId]) VALUES (1, 7, 5)
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Account] FOREIGN KEY([email])
REFERENCES [dbo].[Account] ([email])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Account]
GO
ALTER TABLE [dbo].[CustomerBankAccount]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBankAccount_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[CustomerBankAccount] CHECK CONSTRAINT [FK_CustomerBankAccount_Customer]
GO
ALTER TABLE [dbo].[CustomerSubscription]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSubscription_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[CustomerSubscription] CHECK CONSTRAINT [FK_CustomerSubscription_Customer]
GO
ALTER TABLE [dbo].[CustomerSubscription]  WITH CHECK ADD  CONSTRAINT [FK_CustomerSubscription_Subscription] FOREIGN KEY([subscriptId])
REFERENCES [dbo].[Subscription] ([id])
GO
ALTER TABLE [dbo].[CustomerSubscription] CHECK CONSTRAINT [FK_CustomerSubscription_Subscription]
GO
ALTER TABLE [dbo].[DVDCopy]  WITH CHECK ADD  CONSTRAINT [FK_DVDCopy_DVDCatalog] FOREIGN KEY([DVDCatalogId])
REFERENCES [dbo].[DVDCatalog] ([id])
GO
ALTER TABLE [dbo].[DVDCopy] CHECK CONSTRAINT [FK_DVDCopy_DVDCatalog]
GO
ALTER TABLE [dbo].[DVDStatus]  WITH CHECK ADD  CONSTRAINT [FK_DVDStatus_CustomerSubscription] FOREIGN KEY([customerSubscriptionId])
REFERENCES [dbo].[CustomerSubscription] ([id])
GO
ALTER TABLE [dbo].[DVDStatus] CHECK CONSTRAINT [FK_DVDStatus_CustomerSubscription]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_CustomerSubscription] FOREIGN KEY([customerSubscriptionId])
REFERENCES [dbo].[CustomerSubscription] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_CustomerSubscription]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([paymentType])
REFERENCES [dbo].[PaymentType] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
GO
ALTER TABLE [dbo].[RequestedDVD]  WITH CHECK ADD  CONSTRAINT [FK_RequestedDVD_Customer] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[RequestedDVD] CHECK CONSTRAINT [FK_RequestedDVD_Customer]
GO
ALTER TABLE [dbo].[Watchlist]  WITH CHECK ADD  CONSTRAINT [FK_Watchlist_DVDCatalog] FOREIGN KEY([DVDCatalogId])
REFERENCES [dbo].[DVDCatalog] ([id])
GO
ALTER TABLE [dbo].[Watchlist] CHECK CONSTRAINT [FK_Watchlist_DVDCatalog]
GO
/****** Object:  StoredProcedure [dbo].[GetValidCustomerDelivery]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 

CREATE PROCEDURE [dbo].[GetValidCustomerDelivery]
AS
BEGIN
select * from (
select ROW_NUMBER() over (partition by c.customerid,w.DVDCatalogId order by w.rank ) as row, c.customerId,c.id as customerSubscriptionId,cust.firstName,cust.lastName,cust.gender
,w.DVDCatalogId,cat.title,cop.status ,w.rank,cop.code
from CustomerSubscription c 
join Subscription s on c.subscriptId=s.id
join Customer cust on c.customerId=cust.id
left join Watchlist w on cust.id=w.customerId
left join DVDCatalog cat on w.DVDCatalogId=cat.id
left join DVDCopy cop on  cat.id = cop.DVDCatalogId and cop.isDeleted=0 and cop.status='A'
left join DVDStatus sts on c.id=sts.customerSubscriptionId and sts.DVDCatalogId=w.DVDCatalogId
		and sts.deliveredDate is not null and sts.returnedDate is null
where GETDATE() >= c.startDate and GETDATE() <= c.endDate
and 
atHomeDVD > (select count(*) from DVDStatus where customerSubscriptionId=c.id and returnedDate is not null)
and
noDVDPerMonth > (select count(*) from DVDStatus where customerSubscriptionId=c.id and deliveredDate is not null)
and cop.code is not null
and sts.id is null
group by c.customerId,c.id,cust.firstName,cust.lastName,cust.gender,
w.DVDCatalogId,cat.title,cop.status ,w.rank,cop.code
having w.rank <= 5 ) as q
where row=1

END
GO
/****** Object:  StoredProcedure [dbo].[TestStoreProc]    Script Date: 8/18/2023 11:18:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[TestStoreProc] 
AS
BEGIN
select id, firstName,lastName from Customer 
END
GO
USE [master]
GO
ALTER DATABASE [MovieDB] SET  READ_WRITE 
GO
