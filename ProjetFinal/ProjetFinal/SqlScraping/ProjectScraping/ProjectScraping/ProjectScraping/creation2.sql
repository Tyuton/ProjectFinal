USE [master]
GO

/****** Object:  Database [ProjectScraping_Queries]    Script Date: 07/08/2017 15:21:12 ******/
CREATE DATABASE [ProjectScraping_Queries_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectScraping_Queries', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectScraping_Queries_2.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectScraping_Queries_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\ProjectScraping_Queries_2_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [ProjectScraping_Queries_2]
GO

CREATE TABLE [dbo].[Query](
	[QuieryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,	
	[Description] [nvarchar](max) NOT NULL,
	[DataExpiryDate] [date] NULL,
	[DataTimeStamp] [date] NULL,
	
 CONSTRAINT [PK_Query] PRIMARY KEY CLUSTERED 
(
	[QuieryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[Page](
	[PageId] [uniqueidentifier] NOT NULL,
	[QueryId] [uniqueidentifier] NOT NULL,	
	[URL] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Page]  WITH CHECK ADD  CONSTRAINT [FK_Page_Query] FOREIGN KEY([QueryId])
REFERENCES [dbo].[Query] ([QuieryId])
GO

ALTER TABLE [dbo].[Page] CHECK CONSTRAINT [FK_Page_Query]
GO

CREATE TABLE [dbo].[Selector](
	[SelectorId] [uniqueidentifier] NOT NULL,
	[PageId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_Selector] PRIMARY KEY CLUSTERED 
(
	[SelectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Selector]  WITH CHECK ADD  CONSTRAINT [FK_Selector_Page] FOREIGN KEY([PageId])
REFERENCES [dbo].[Page] ([PageId])
GO

ALTER TABLE [dbo].[Selector] CHECK CONSTRAINT [FK_Selector_Page]
GO

CREATE TABLE [dbo].[ResultsHeader](
	[ResultsHeaderId] [uniqueidentifier] NOT NULL,
	--[QuieryId] [uniqueidentifier] NOT NULL,
	[SelectorId] [uniqueidentifier] NOT NULL,
	[QuieryExecutionDate] [date] NOT NULL,
		
 CONSTRAINT [PK_ResultsHeader] PRIMARY KEY CLUSTERED 
(
	[ResultsHeaderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] --TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ResultsHeader]  WITH CHECK ADD  CONSTRAINT [FK_ResultsHeader_Selector] FOREIGN KEY([SelectorId])
REFERENCES [dbo].[Selector] ([SelectorId])
GO

ALTER TABLE [dbo].[ResultsHeader] CHECK CONSTRAINT [FK_ResultsHeader_Selector]
GO

CREATE TABLE [dbo].[ResultsDetails](
	[ResultsDetailsId] [uniqueidentifier] NOT NULL,
	[ResultsHeaderId] [uniqueidentifier] NOT NULL,	
	[Value] [nvarchar](max) NOT NULL,
		
 CONSTRAINT [PK_ResultsDetails] PRIMARY KEY CLUSTERED 
(
	[ResultsDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[ResultsDetails]  WITH CHECK ADD  CONSTRAINT [FK_ResultsDetails_ResultsHeader] FOREIGN KEY([ResultsHeaderId])
REFERENCES [dbo].[ResultsHeader] ([ResultsHeaderId])
GO

ALTER TABLE [dbo].[ResultsDetails] CHECK CONSTRAINT [FK_ResultsDetails_ResultsHeader]
GO
