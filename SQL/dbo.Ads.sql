CREATE TABLE [dbo].[Ads] (
    [Id]            INT            NOT NULL,
    [Name]          VARCHAR(50)  NOT NULL,
    [UserId]        INT            NULL,
    [Description]   VARCHAR(MAX) NULL,
    [Picture]       VARCHAR(150) NULL,
    [Price]         MONEY          NULL,
    [CategoryId]    SMALLINT       NULL,
    [SubcategoryId] SMALLINT       NULL,
    [CreationDate]  DATETIME       NULL,
    [LocationId]    SMALLINT       NULL,
    [TypeId]        SMALLINT       NULL,
    [ConditionId]   SMALLINT       NULL,
    CONSTRAINT [FK_Ads_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_Ads_Conditions] FOREIGN KEY ([ConditionId]) REFERENCES [dbo].[Conditions] ([Id]),
    CONSTRAINT [FK_Ads_Locations] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Locations] ([Id]),
    CONSTRAINT [FK_Ads_Types] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[Types] ([Id]),
    CONSTRAINT [FK_Ads_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);