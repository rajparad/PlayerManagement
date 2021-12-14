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

CREATE TABLE [Teams] (
    [teamID] int NOT NULL IDENTITY,
    [teamName] nvarchar(max) NULL,
    [managerName] int NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([teamID])
);
GO

CREATE TABLE [Players] (
    [playerID] int NOT NULL IDENTITY,
    [playerName] nvarchar(max) NULL,
    [playerAge] int NOT NULL,
    [teamId] int NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([playerID]),
    CONSTRAINT [FK_Players_Teams_teamId] FOREIGN KEY ([teamId]) REFERENCES [Teams] ([teamID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Players_teamId] ON [Players] ([teamId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210817041827_DKR_Final_DB_Init', N'5.0.9');
GO

COMMIT;
GO

