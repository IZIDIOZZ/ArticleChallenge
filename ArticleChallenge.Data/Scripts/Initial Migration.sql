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

CREATE TABLE [Articles] (
    [ArticleId] uniqueidentifier NOT NULL,
    [Author] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [Content] nvarchar(max) NULL,
    [PublishDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [LikeArticle] (
    [LikeArticleId] uniqueidentifier NOT NULL,
    [ArticleId] uniqueidentifier NOT NULL,
    [UserIdLiked] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_LikeArticle] PRIMARY KEY ([LikeArticleId]),
    CONSTRAINT [FK_LikeArticle_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [Articles] ([ArticleId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_LikeArticle_ArticleId] ON [LikeArticle] ([ArticleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211127170245_Initial', N'5.0.12');
GO

COMMIT;
GO

