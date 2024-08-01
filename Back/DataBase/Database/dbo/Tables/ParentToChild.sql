CREATE TABLE [dbo].[ParentToChild] (
    [Id]       INT          NOT NULL,
    [ParentId] VARCHAR (36) NULL,
    [ChildId]  VARCHAR (36) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ParentToChild_Parent] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[TaskItem] ([Id]),
    CONSTRAINT [FK_ParentToChild_Child] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[TaskItem] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ParentToChild_Column]
    ON [dbo].[ParentToChild]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentToChild_Column_1]
    ON [dbo].[ParentToChild]([ChildId] ASC);

