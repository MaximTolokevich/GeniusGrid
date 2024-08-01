CREATE TABLE [dbo].[TaskItem] (
    [Id]          VARCHAR (36)   NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [AssignedBy]  VARCHAR (36)   NOT NULL,
    [AssignetTo]  VARCHAR (36)   NULL,
    [DateFrom]    DATETIME2 (7)  NULL,
    [DateTo]      DATETIME2 (7)  NULL,
    [Created]     DATETIME2 (7)  NOT NULL,
    [Updated]     DATETIME2 (7)  NULL,
    [Complited]   DATETIME2 (7)  NULL,
    [TreeId]      VARCHAR (36)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

