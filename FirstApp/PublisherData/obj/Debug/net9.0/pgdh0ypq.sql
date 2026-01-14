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
CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [PublishDate] date NOT NULL,
    [BasePrice] decimal(18,2) NOT NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260114093033_initial', N'9.0.0');

COMMIT;
GO

