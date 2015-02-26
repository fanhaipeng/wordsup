
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2015 20:54:00
-- Generated from EDMX file: E:\work\WordsUp\WordsUpWeb\WordsUpWeb\Models\WordsUpModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WordsUpDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_WordReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_WordReview];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewSet] DROP CONSTRAINT [FK_ReviewUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[WordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WordSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ReviewSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReviewSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'WordSet'
CREATE TABLE [dbo].[WordSet] (
    [WordId] int IDENTITY(1,1) NOT NULL,
    [WordContent] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReviewSet'
CREATE TABLE [dbo].[ReviewSet] (
    [ReviewId] int IDENTITY(1,1) NOT NULL,
    [WordId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Count] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [WordId] in table 'WordSet'
ALTER TABLE [dbo].[WordSet]
ADD CONSTRAINT [PK_WordSet]
    PRIMARY KEY CLUSTERED ([WordId] ASC);
GO

-- Creating primary key on [UserId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ReviewId] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [PK_ReviewSet]
    PRIMARY KEY CLUSTERED ([ReviewId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WordId] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [FK_WordReview]
    FOREIGN KEY ([WordId])
    REFERENCES [dbo].[WordSet]
        ([WordId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WordReview'
CREATE INDEX [IX_FK_WordReview]
ON [dbo].[ReviewSet]
    ([WordId]);
GO

-- Creating foreign key on [UserId] in table 'ReviewSet'
ALTER TABLE [dbo].[ReviewSet]
ADD CONSTRAINT [FK_ReviewUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewUser'
CREATE INDEX [IX_FK_ReviewUser]
ON [dbo].[ReviewSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------