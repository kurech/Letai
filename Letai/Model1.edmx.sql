
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/22/2021 10:49:57
-- Generated from EDMX file: C:\Users\ranel\source\repos\Letai\Letai\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\RANEL\ONEDRIVE\днйслемрш\LETAI.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StaffSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StaffSet];
GO
IF OBJECT_ID(N'[dbo].[ClientsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientsSet];
GO
IF OBJECT_ID(N'[dbo].[HistorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HistorySet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StaffSet'
CREATE TABLE [dbo].[StaffSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClientsSet'
CREATE TABLE [dbo].[ClientsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Passport] nvarchar(max)  NOT NULL,
    [Service] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HistorySet'
CREATE TABLE [dbo].[HistorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdStaff] nvarchar(max)  NOT NULL,
    [Happened] nvarchar(max)  NOT NULL,
    [IdClient] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StaffSet'
ALTER TABLE [dbo].[StaffSet]
ADD CONSTRAINT [PK_StaffSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClientsSet'
ALTER TABLE [dbo].[ClientsSet]
ADD CONSTRAINT [PK_ClientsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HistorySet'
ALTER TABLE [dbo].[HistorySet]
ADD CONSTRAINT [PK_HistorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------