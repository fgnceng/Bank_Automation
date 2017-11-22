USE [master]
GO
/****** Object:  Database [BANK]    Script Date: 25.8.2016 15:46:40 ******/
CREATE DATABASE [BANK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BANK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BANK.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BANK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BANK_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BANK] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BANK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BANK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BANK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BANK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BANK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BANK] SET ARITHABORT OFF 
GO
ALTER DATABASE [BANK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BANK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BANK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BANK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BANK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BANK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BANK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BANK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BANK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BANK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BANK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BANK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BANK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BANK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BANK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BANK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BANK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BANK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BANK] SET  MULTI_USER 
GO
ALTER DATABASE [BANK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BANK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BANK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BANK] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BANK] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BANK]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[CustomerID] [nvarchar](50) NOT NULL,
	[Balance] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BankStatement]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankStatement](
	[Rank] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[OperationTypeNo] [int] NOT NULL,
	[TheAmountofMoney] [int] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BankStatement] PRIMARY KEY CLUSTERED 
(
	[Rank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Telephone] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OperationType]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationType](
	[OperationTypeNo] [int] NOT NULL,
	[Comment] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OperationType] PRIMARY KEY CLUSTERED 
(
	[OperationTypeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[Username] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Personnel] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transfer]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfer](
	[Rank] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [nvarchar](50) NOT NULL,
	[ReceiveID] [nvarchar](50) NOT NULL,
	[Date] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Transfer] PRIMARY KEY CLUSTERED 
(
	[Rank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[CustomerRegister]    Script Date: 25.8.2016 15:46:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CustomerRegister](
@CustomerID nvarchar(50),
@Name nvarchar(50),
@Surname nvarchar(50),
@Address nvarchar(150),
@Telephone nvarchar(11),
@Email nvarchar(50) 
)
as
insert into Customer(CustomerID,Name,Surname,Address,Telephone,Email)
values (@CustomerID,@Name,@Surname,@Address,@Telephone,@email)
GO
USE [master]
GO
ALTER DATABASE [BANK] SET  READ_WRITE 
GO
