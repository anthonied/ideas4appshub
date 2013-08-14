USE [master]
GO
/****** Object:  Database [ideas4apps]    Script Date: 8/14/2013 3:55:23 PM ******/
CREATE DATABASE [ideas4apps]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ideas4apps', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER_2\MSSQL\DATA\ideas4apps.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ideas4apps_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER_2\MSSQL\DATA\ideas4apps_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ideas4apps] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ideas4apps].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ideas4apps] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ideas4apps] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ideas4apps] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ideas4apps] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ideas4apps] SET ARITHABORT OFF 
GO
ALTER DATABASE [ideas4apps] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ideas4apps] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ideas4apps] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ideas4apps] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ideas4apps] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ideas4apps] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ideas4apps] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ideas4apps] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ideas4apps] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ideas4apps] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ideas4apps] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ideas4apps] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ideas4apps] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ideas4apps] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ideas4apps] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ideas4apps] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ideas4apps] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ideas4apps] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ideas4apps] SET RECOVERY FULL 
GO
ALTER DATABASE [ideas4apps] SET  MULTI_USER 
GO
ALTER DATABASE [ideas4apps] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ideas4apps] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ideas4apps] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ideas4apps] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ideas4apps', N'ON'
GO
USE [ideas4apps]
GO
/****** Object:  Table [dbo].[business]    Script Date: 8/14/2013 3:55:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[business](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[description] [varchar](50) NULL,
	[telephone_number] [varchar](15) NULL,
	[last_update] [datetime] NULL,
	[status] [varchar](50) NULL,
	[business_hours] [varchar](50) NULL,
	[tags] [varchar](50) NULL,
	[weburl] [varchar](50) NULL,
	[photo] [image] NULL,
	[category] [varchar](50) NULL,
	[active] [bit] NULL,
	[address1] [varchar](50) NULL,
	[address2] [varchar](50) NULL,
	[address3] [varchar](50) NULL,
	[postal_code] [varchar](50) NULL,
	[gps] [varchar](50) NULL,
 CONSTRAINT [PK_business] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [ideas4apps] SET  READ_WRITE 
GO
