CREATE TABLE [dbo].[Attachment] (
    [Id]          VARCHAR (36)   NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Type]        NVARCHAR (50)  NOT NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [TaskItemId]  VARCHAR (36)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attachment_To_TaskItem] FOREIGN KEY ([TaskItemId]) REFERENCES [dbo].[TaskItem] ([Id])
);

