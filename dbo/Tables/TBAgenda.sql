CREATE TABLE [dbo].[TBAgenda] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Titulo]          VARCHAR (200) NULL,
    [DataDeCriacao]   DATETIME      NULL,
    [DataDeConclusao] DATETIME      NULL,
    [Percentual]      INT           NULL,
    [Prioridade]      VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

