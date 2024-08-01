CREATE TABLE [dbo].[ChildToParent] (
    [Id]       VARCHAR (36) NOT NULL,
    [ChildId]  VARCHAR (36) NULL,
    [ParentId] VARCHAR (36) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChildToParent_To_TaskItem] FOREIGN KEY ([ChildId]) REFERENCES [dbo].[TaskItem] ([Id]),
    CONSTRAINT [FK_ParentToChild_To_TaskItem] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[TaskItem] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ChildToParent_Child]
    ON [dbo].[ChildToParent]([ChildId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ChildToParent_Parent]
    ON [dbo].[ChildToParent]([ParentId] ASC);

