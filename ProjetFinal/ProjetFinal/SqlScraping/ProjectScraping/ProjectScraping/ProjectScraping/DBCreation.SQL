USE [master]
GO

/****** Object:  Database [ProjectScraping_Queries]    Script Date: 07/08/2017 14:44:10 ******/
CREATE DATABASE [ProjectScraping_Queries]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectScraping_Queries', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectScraping_Queries.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectScraping_Queries_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectScraping_Queries_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [ProjectScraping_Queries]
GO

CREATE TABLE [dbo].[Query](
	[QuieryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DataTableId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,	
	[DataExpiryDate] [date] NULL,
	[DataTimeStamp] [date] NULL,
	[SelectorId] [nvarchar](max) NOT NULL,
	[FiledId] [int] NOT NULL,
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[QuieryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Page](
	[URLId] [uniqueidentifier] NOT NULL,
	[QueryId] [uniqueidentifier] NOT NULL,
	[SelectorId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[URLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Field](
	[FieldId] [uniqueidentifier] NOT NULL,
	[QueryId] [uniqueidentifier] NOT NULL,
	[NameValue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




