USE [master]
GO
/****** Object:  Database [Gutuphane]    Script Date: 20.06.2022 02:35:23 ******/
CREATE DATABASE [Gutuphane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gutuphane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Gutuphane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gutuphane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Gutuphane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Gutuphane] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gutuphane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gutuphane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gutuphane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gutuphane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gutuphane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gutuphane] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gutuphane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gutuphane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gutuphane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gutuphane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gutuphane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gutuphane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gutuphane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gutuphane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gutuphane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gutuphane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gutuphane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gutuphane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gutuphane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gutuphane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gutuphane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gutuphane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gutuphane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gutuphane] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gutuphane] SET  MULTI_USER 
GO
ALTER DATABASE [Gutuphane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gutuphane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gutuphane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gutuphane] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gutuphane] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gutuphane] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Gutuphane] SET QUERY_STORE = OFF
GO
USE [Gutuphane]
GO
/****** Object:  Table [dbo].[AlinanKitaplar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlinanKitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[Yazar] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AlinanKitaplar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BegenilenKitaplar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BegenilenKitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[YazarAdi] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BegenilenKitaplar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BegenilmeyenKitaplar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BegenilmeyenKitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[YazarAdi] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BegenilmeyenKitaplar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chapterlar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chapterlar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Yazar] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
	[ChapterSayisi] [int] NOT NULL,
	[Baslik] [varchar](50) NOT NULL,
	[Chapter] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Chapterlar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiketler]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiketler](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[YazarAdi] [varchar](50) NOT NULL,
	[KitapTuru] [varchar](50) NOT NULL,
	[Etiketler] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Ilgiler] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kitaplar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitaplar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
	[KitapTuru] [varchar](50) NOT NULL,
	[KitapKonusu] [varchar](max) NOT NULL,
	[KapakFotografi] [varchar](300) NULL,
	[Etiketler] [varchar](100) NULL,
	[Durum] [varchar](50) NOT NULL,
	[OkunmaSayisi] [bigint] NOT NULL,
	[Fiyat] [money] NOT NULL,
 CONSTRAINT [PK_Kitaplar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitapYorumlari]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitapYorumlari](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[YazarAdi] [varchar](50) NOT NULL,
	[KitapAdi] [varchar](50) NOT NULL,
	[Yorum] [varchar](max) NOT NULL,
 CONSTRAINT [PK_KitapYorumlari] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[E-Posta] [nvarchar](50) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
	[Soyadi] [nvarchar](50) NOT NULL,
	[Dogum Tarihi] [date] NOT NULL,
	[No] [bigint] NOT NULL,
	[Kayit Tarihi] [date] NOT NULL,
	[Yetki] [nvarchar](50) NOT NULL,
	[Para] [money] NOT NULL,
	[Fotograf] [varchar](300) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Takip]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Takip](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NOT NULL,
	[YazarAdi] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Takip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[KullaniciBilgileri]    Script Date: 20.06.2022 02:35:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[KullaniciBilgileri] @user varchar(50)
as
select * from Kullanicilar where KullaniciAdi = @user
GO
USE [master]
GO
ALTER DATABASE [Gutuphane] SET  READ_WRITE 
GO
