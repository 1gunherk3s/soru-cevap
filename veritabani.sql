USE [master]
GO
/****** Object:  Database [SoruCevap]    Script Date: 25.09.2024 16:11:27 ******/
CREATE DATABASE [SoruCevap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoruCevao', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SoruCevao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoruCevao_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SoruCevao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SoruCevap] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoruCevap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoruCevap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoruCevap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoruCevap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoruCevap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoruCevap] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoruCevap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoruCevap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoruCevap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoruCevap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoruCevap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoruCevap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoruCevap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoruCevap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoruCevap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoruCevap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoruCevap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoruCevap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoruCevap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoruCevap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoruCevap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoruCevap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoruCevap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoruCevap] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SoruCevap] SET  MULTI_USER 
GO
ALTER DATABASE [SoruCevap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoruCevap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoruCevap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoruCevap] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoruCevap] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoruCevap] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SoruCevap] SET QUERY_STORE = ON
GO
ALTER DATABASE [SoruCevap] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SoruCevap]
GO
/****** Object:  Table [dbo].[tblcevap]    Script Date: 25.09.2024 16:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblcevap](
	[CevapID] [int] IDENTITY(1,1) NOT NULL,
	[CevapA] [varchar](30) NULL,
	[CevapB] [varchar](30) NULL,
	[CevapC] [varchar](30) NULL,
	[CevapD] [varchar](30) NULL,
	[DogruCevap] [varchar](30) NULL,
 CONSTRAINT [PK_tblcevap_1] PRIMARY KEY CLUSTERED 
(
	[CevapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblsoru]    Script Date: 25.09.2024 16:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblsoru](
	[SoruID] [int] IDENTITY(1,1) NOT NULL,
	[Soru] [varchar](100) NULL,
	[Kullanildi] [bit] NULL,
 CONSTRAINT [PK_tblsoru] PRIMARY KEY CLUSTERED 
(
	[SoruID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblcevap]  WITH CHECK ADD  CONSTRAINT [FK_tblcevap_tblsoru] FOREIGN KEY([CevapID])
REFERENCES [dbo].[tblsoru] ([SoruID])
GO
ALTER TABLE [dbo].[tblcevap] CHECK CONSTRAINT [FK_tblcevap_tblsoru]
GO
USE [master]
GO
ALTER DATABASE [SoruCevap] SET  READ_WRITE 
GO
