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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114093033_initial'
)
BEGIN
    CREATE TABLE [Authors] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114093033_initial'
)
BEGIN
    CREATE TABLE [Books] (
        [BookId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [PublishDate] date NOT NULL,
        [BasePrice] decimal(18,2) NOT NULL,
        [AuthorId] int NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
        CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114093033_initial'
)
BEGIN
    CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114093033_initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260114093033_initial', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114115223_SeedAuthors'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
        SET IDENTITY_INSERT [Authors] ON;
    EXEC(N'INSERT INTO [Authors] ([Id], [FirstName], [LastName])
    VALUES (1, N''Ronja'', N''Levi''),
    (2, N''Rita'', N''Olsson''),
    (3, N''Sofia'', N''Smith''),
    (4, N''Ursula'', N''Levin''),
    (5, N''Harry'', N''Howey''),
    (6, N''Isabelle'', N''Allie'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'FirstName', N'LastName') AND [object_id] = OBJECT_ID(N'[Authors]'))
        SET IDENTITY_INSERT [Authors] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260114115223_SeedAuthors'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260114115223_SeedAuthors', N'9.0.0');
END;

COMMIT;
GO

