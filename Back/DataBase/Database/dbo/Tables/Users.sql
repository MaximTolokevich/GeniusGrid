CREATE TABLE [dbo].[Users] (
    [Id]             VARCHAR(36)          NOT NULL,
    [Name]           NVARCHAR(50)   NOT NULL,
    [Password]       NVARCHAR(50)   NOT NULL,
    [EmailConfirmed] BIT          DEFAULT ((0)) NOT NULL,
    [Email]          NVARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

