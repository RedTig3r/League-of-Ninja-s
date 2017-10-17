
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2017 17:20:49
-- Generated from EDMX file: C:\Users\Barend\Source\Repos\League-of-Ninja-s\LeagueOfNinja\Model\MyEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LeagueOfNinja.Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Equipment_TypeOfEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipment] DROP CONSTRAINT [FK_Equipment_TypeOfEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_Inventory_Equipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventory] DROP CONSTRAINT [FK_Inventory_Equipment];
GO
IF OBJECT_ID(N'[dbo].[FK_Ninja_Inventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ninja] DROP CONSTRAINT [FK_Ninja_Inventory];
GO
IF OBJECT_ID(N'[dbo].[FK_Ninja_Shop]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ninja] DROP CONSTRAINT [FK_Ninja_Shop];
GO
IF OBJECT_ID(N'[dbo].[FK_Shop_Equipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shop] DROP CONSTRAINT [FK_Shop_Equipment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__RefactorLog]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__RefactorLog];
GO
IF OBJECT_ID(N'[dbo].[Equipment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipment];
GO
IF OBJECT_ID(N'[dbo].[Inventory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventory];
GO
IF OBJECT_ID(N'[dbo].[Ninja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ninja];
GO
IF OBJECT_ID(N'[dbo].[Shop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shop];
GO
IF OBJECT_ID(N'[dbo].[TypeOfEquipment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeOfEquipment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__RefactorLog'
CREATE TABLE [dbo].[C__RefactorLog] (
    [OperationKey] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [EquipmentId] int  NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Price] int  NULL,
    [Strength] int  NULL,
    [Intelligence] int  NULL,
    [Agility] int  NULL,
    [Type] nvarchar(50)  NOT NULL,
    [Shop_ShopId] int  NOT NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [InventoryId] int  NOT NULL,
    [EquipmentId] int  NULL
);
GO

-- Creating table 'Ninjas'
CREATE TABLE [dbo].[Ninjas] (
    [NinjaId] int  NOT NULL,
    [Name] nchar(50)  NULL,
    [Money] int  NULL,
    [ShopShopId] int  NOT NULL
);
GO

-- Creating table 'Shops'
CREATE TABLE [dbo].[Shops] (
    [ShopId] int  NOT NULL,
    [ShopName] nvarchar(50)  NOT NULL,
    [EquipmentId] int  NOT NULL
);
GO

-- Creating table 'TypeOfEquipments'
CREATE TABLE [dbo].[TypeOfEquipments] (
    [TypeOfEquipmentId] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'InventoryEquipment'
CREATE TABLE [dbo].[InventoryEquipment] (
    [Inventories_InventoryId] int  NOT NULL,
    [Equipments_EquipmentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OperationKey] in table 'C__RefactorLog'
ALTER TABLE [dbo].[C__RefactorLog]
ADD CONSTRAINT [PK_C__RefactorLog]
    PRIMARY KEY CLUSTERED ([OperationKey] ASC);
GO

-- Creating primary key on [EquipmentId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([EquipmentId] ASC);
GO

-- Creating primary key on [InventoryId] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([InventoryId] ASC);
GO

-- Creating primary key on [NinjaId] in table 'Ninjas'
ALTER TABLE [dbo].[Ninjas]
ADD CONSTRAINT [PK_Ninjas]
    PRIMARY KEY CLUSTERED ([NinjaId] ASC);
GO

-- Creating primary key on [ShopId] in table 'Shops'
ALTER TABLE [dbo].[Shops]
ADD CONSTRAINT [PK_Shops]
    PRIMARY KEY CLUSTERED ([ShopId] ASC);
GO

-- Creating primary key on [TypeOfEquipmentId] in table 'TypeOfEquipments'
ALTER TABLE [dbo].[TypeOfEquipments]
ADD CONSTRAINT [PK_TypeOfEquipments]
    PRIMARY KEY CLUSTERED ([TypeOfEquipmentId] ASC);
GO

-- Creating primary key on [Inventories_InventoryId], [Equipments_EquipmentId] in table 'InventoryEquipment'
ALTER TABLE [dbo].[InventoryEquipment]
ADD CONSTRAINT [PK_InventoryEquipment]
    PRIMARY KEY CLUSTERED ([Inventories_InventoryId], [Equipments_EquipmentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Type] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_Equipment_TypeOfEquipment]
    FOREIGN KEY ([Type])
    REFERENCES [dbo].[TypeOfEquipments]
        ([TypeOfEquipmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Equipment_TypeOfEquipment'
CREATE INDEX [IX_FK_Equipment_TypeOfEquipment]
ON [dbo].[Equipments]
    ([Type]);
GO

-- Creating foreign key on [NinjaId] in table 'Ninjas'
ALTER TABLE [dbo].[Ninjas]
ADD CONSTRAINT [FK_Ninja_Inventory]
    FOREIGN KEY ([NinjaId])
    REFERENCES [dbo].[Inventories]
        ([InventoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Inventories_InventoryId] in table 'InventoryEquipment'
ALTER TABLE [dbo].[InventoryEquipment]
ADD CONSTRAINT [FK_InventoryEquipment_Inventory]
    FOREIGN KEY ([Inventories_InventoryId])
    REFERENCES [dbo].[Inventories]
        ([InventoryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Equipments_EquipmentId] in table 'InventoryEquipment'
ALTER TABLE [dbo].[InventoryEquipment]
ADD CONSTRAINT [FK_InventoryEquipment_Equipment]
    FOREIGN KEY ([Equipments_EquipmentId])
    REFERENCES [dbo].[Equipments]
        ([EquipmentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InventoryEquipment_Equipment'
CREATE INDEX [IX_FK_InventoryEquipment_Equipment]
ON [dbo].[InventoryEquipment]
    ([Equipments_EquipmentId]);
GO

-- Creating foreign key on [Shop_ShopId] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_ShopEquipment]
    FOREIGN KEY ([Shop_ShopId])
    REFERENCES [dbo].[Shops]
        ([ShopId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopEquipment'
CREATE INDEX [IX_FK_ShopEquipment]
ON [dbo].[Equipments]
    ([Shop_ShopId]);
GO

-- Creating foreign key on [ShopShopId] in table 'Ninjas'
ALTER TABLE [dbo].[Ninjas]
ADD CONSTRAINT [FK_ShopNinja]
    FOREIGN KEY ([ShopShopId])
    REFERENCES [dbo].[Shops]
        ([ShopId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopNinja'
CREATE INDEX [IX_FK_ShopNinja]
ON [dbo].[Ninjas]
    ([ShopShopId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------