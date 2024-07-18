CREATE TABLE [dbo].[Users] (
    [Id]             INT          NOT NULL,
    [Name]           NCHAR (10)   NOT NULL,
    [Password]       NCHAR (10)   NOT NULL,
    [EmailConfirmed] BIT          DEFAULT ((0)) NOT NULL,
    [Email]          VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

