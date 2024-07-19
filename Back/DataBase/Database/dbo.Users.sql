CREATE TABLE [dbo].[Users] (
    [Id]             VARCHAR(36)          NOT NULL,
    [Name]           NCHAR (50)   NOT NULL,
    [Password]       NCHAR (50)   NOT NULL,
    [EmailConfirmed] BIT          DEFAULT ((0)) NOT NULL,
    [Email]          VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

