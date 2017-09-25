
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/25/2017 09:12:40
-- Generated from EDMX file: F:\Git\Repos\ProjectFinal\ProjetFinal\DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBWebScraping];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Pages_dbo_Queries_Query_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pages] DROP CONSTRAINT [FK_dbo_Pages_dbo_Queries_Query_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ResultsDetails_dbo_ResultsHeaders_ResultsHeader_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultsDetails] DROP CONSTRAINT [FK_dbo_ResultsDetails_dbo_ResultsHeaders_ResultsHeader_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_ResultsHeaders_dbo_Selectors_Selector_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResultsHeaders] DROP CONSTRAINT [FK_dbo_ResultsHeaders_dbo_Selectors_Selector_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Selectors_dbo_Pages_Page_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Selectors] DROP CONSTRAINT [FK_dbo_Selectors_dbo_Pages_Page_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pages];
GO
IF OBJECT_ID(N'[dbo].[Queries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Queries];
GO
IF OBJECT_ID(N'[dbo].[ResultsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResultsDetails];
GO
IF OBJECT_ID(N'[dbo].[ResultsHeaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResultsHeaders];
GO
IF OBJECT_ID(N'[dbo].[Selectors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Selectors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pages'
CREATE TABLE [dbo].[Pages] (
    [Id] uniqueidentifier  NOT NULL,
    [URL] nvarchar(max)  NULL,
    [Query_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'Queries'
CREATE TABLE [dbo].[Queries] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [DataExpiryDate] datetime  NULL,
    [DataTimeStamp] datetime  NULL
);
GO

-- Creating table 'ResultsDetails'
CREATE TABLE [dbo].[ResultsDetails] (
    [Id] uniqueidentifier  NOT NULL,
    [Value] nvarchar(max)  NULL,
    [ResultsHeader_Id] uniqueidentifier  NOT NULL,
    [CLEF] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ResultsHeaders'
CREATE TABLE [dbo].[ResultsHeaders] (
    [Id] uniqueidentifier  NOT NULL,
    [QueryExecutionDate] datetime  NOT NULL,
    [Selector_Id] uniqueidentifier  NULL
);
GO

-- Creating table 'Selectors'
CREATE TABLE [dbo].[Selectors] (
    [Id] uniqueidentifier  NOT NULL,
    [Value] nvarchar(max)  NULL,
    [Page_Id] uniqueidentifier  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [PK_Pages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Queries'
ALTER TABLE [dbo].[Queries]
ADD CONSTRAINT [PK_Queries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResultsDetails'
ALTER TABLE [dbo].[ResultsDetails]
ADD CONSTRAINT [PK_ResultsDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResultsHeaders'
ALTER TABLE [dbo].[ResultsHeaders]
ADD CONSTRAINT [PK_ResultsHeaders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Selectors'
ALTER TABLE [dbo].[Selectors]
ADD CONSTRAINT [PK_Selectors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Query_Id] in table 'Pages'
ALTER TABLE [dbo].[Pages]
ADD CONSTRAINT [FK_dbo_Pages_dbo_Queries_Query_Id]
    FOREIGN KEY ([Query_Id])
    REFERENCES [dbo].[Queries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Pages_dbo_Queries_Query_Id'
CREATE INDEX [IX_FK_dbo_Pages_dbo_Queries_Query_Id]
ON [dbo].[Pages]
    ([Query_Id]);
GO

-- Creating foreign key on [Page_Id] in table 'Selectors'
ALTER TABLE [dbo].[Selectors]
ADD CONSTRAINT [FK_dbo_Selectors_dbo_Pages_Page_Id]
    FOREIGN KEY ([Page_Id])
    REFERENCES [dbo].[Pages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Selectors_dbo_Pages_Page_Id'
CREATE INDEX [IX_FK_dbo_Selectors_dbo_Pages_Page_Id]
ON [dbo].[Selectors]
    ([Page_Id]);
GO

-- Creating foreign key on [ResultsHeader_Id] in table 'ResultsDetails'
ALTER TABLE [dbo].[ResultsDetails]
ADD CONSTRAINT [FK_dbo_ResultsDetails_dbo_ResultsHeaders_ResultsHeader_Id]
    FOREIGN KEY ([ResultsHeader_Id])
    REFERENCES [dbo].[ResultsHeaders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ResultsDetails_dbo_ResultsHeaders_ResultsHeader_Id'
CREATE INDEX [IX_FK_dbo_ResultsDetails_dbo_ResultsHeaders_ResultsHeader_Id]
ON [dbo].[ResultsDetails]
    ([ResultsHeader_Id]);
GO

-- Creating foreign key on [Selector_Id] in table 'ResultsHeaders'
ALTER TABLE [dbo].[ResultsHeaders]
ADD CONSTRAINT [FK_dbo_ResultsHeaders_dbo_Selectors_Selector_Id]
    FOREIGN KEY ([Selector_Id])
    REFERENCES [dbo].[Selectors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_ResultsHeaders_dbo_Selectors_Selector_Id'
CREATE INDEX [IX_FK_dbo_ResultsHeaders_dbo_Selectors_Selector_Id]
ON [dbo].[ResultsHeaders]
    ([Selector_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------