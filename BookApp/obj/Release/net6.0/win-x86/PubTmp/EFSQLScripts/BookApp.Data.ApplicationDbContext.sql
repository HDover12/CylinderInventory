IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014155244_AddToDatabase')
BEGIN
    CREATE TABLE [CylinderInventory] (
        [Id] int NOT NULL IDENTITY,
        [CylinderId] nvarchar(max) NOT NULL,
        [Components] nvarchar(max) NOT NULL,
        [Concentration] int NOT NULL,
        [Unit] nvarchar(max) NOT NULL,
        [CreatedDateTime] datetime2 NOT NULL,
        CONSTRAINT [PK_CylinderInventory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014155244_AddToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221014155244_AddToDatabase', N'6.0.10');
END;
GO

COMMIT;
GO

