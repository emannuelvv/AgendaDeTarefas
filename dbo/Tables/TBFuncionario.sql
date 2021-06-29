CREATE TABLE [dbo].[TBFuncionario] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Nome]           VARCHAR (200) NULL,
    [DataNascimento] DATETIME      NULL,
    [Salario]        DECIMAL (18)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

