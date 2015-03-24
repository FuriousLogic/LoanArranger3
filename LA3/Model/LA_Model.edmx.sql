
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/25/2013 16:52:50
-- Generated from EDMX file: C:\Users\Barry\Documents\Visual Studio 2012\LoanArranger3\LA3\Model\LA_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LoanArranger3_ef];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NOT NULL,
    [InvoiceNumber] int  NOT NULL,
    [NetValue] float  NOT NULL,
    [GrossValue] float  NOT NULL,
    [PaymentPeriod] int  NOT NULL,
    [PayMonthly] bit  NOT NULL,
    [Payment] float  NOT NULL,
    [LastChecked] datetime  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [NextPaymentDate] datetime  NOT NULL,
    [PrintedForm] bit  NOT NULL,
    [OldId] int  NOT NULL,
    [LockedByUser] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'AccountStatus'
CREATE TABLE [dbo].[AccountStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AccountStatusChanges'
CREATE TABLE [dbo].[AccountStatusChanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [AccountStatus_Id] int  NOT NULL,
    [Account_Id] int  NOT NULL
);
GO

-- Creating table 'Collectors'
CREATE TABLE [dbo].[Collectors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CollectorName] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [OldId] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Forename] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [PostCode] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [PreferredDay] int  NOT NULL,
    [Maxloan] int  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [Locked] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [LockedByUser] nvarchar(max)  NOT NULL,
    [Collector_Id] int  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [Amount] float  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [IsSundry] bit  NOT NULL,
    [PaidByAccountId] int  NOT NULL,
    [Account_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountStatus'
ALTER TABLE [dbo].[AccountStatus]
ADD CONSTRAINT [PK_AccountStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AccountStatusChanges'
ALTER TABLE [dbo].[AccountStatusChanges]
ADD CONSTRAINT [PK_AccountStatusChanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Collectors'
ALTER TABLE [dbo].[Collectors]
ADD CONSTRAINT [PK_Collectors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Collector_Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [FK_CollectorCustomer]
    FOREIGN KEY ([Collector_Id])
    REFERENCES [dbo].[Collectors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollectorCustomer'
CREATE INDEX [IX_FK_CollectorCustomer]
ON [dbo].[Customers]
    ([Collector_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_CustomerAccount]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAccount'
CREATE INDEX [IX_FK_CustomerAccount]
ON [dbo].[Accounts]
    ([Customer_Id]);
GO

-- Creating foreign key on [AccountStatus_Id] in table 'AccountStatusChanges'
ALTER TABLE [dbo].[AccountStatusChanges]
ADD CONSTRAINT [FK_AccountStatusAccountStatusChange]
    FOREIGN KEY ([AccountStatus_Id])
    REFERENCES [dbo].[AccountStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountStatusAccountStatusChange'
CREATE INDEX [IX_FK_AccountStatusAccountStatusChange]
ON [dbo].[AccountStatusChanges]
    ([AccountStatus_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'AccountStatusChanges'
ALTER TABLE [dbo].[AccountStatusChanges]
ADD CONSTRAINT [FK_AccountAccountStatusChange]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAccountStatusChange'
CREATE INDEX [IX_FK_AccountAccountStatusChange]
ON [dbo].[AccountStatusChanges]
    ([Account_Id]);
GO

-- Creating foreign key on [Account_Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_AccountPayment]
    FOREIGN KEY ([Account_Id])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountPayment'
CREATE INDEX [IX_FK_AccountPayment]
ON [dbo].[Payments]
    ([Account_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------