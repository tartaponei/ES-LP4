CREATE TABLE [dbo].[Aluno]
(
	[Matricula] INT NOT NULL PRIMARY KEY, 
    [Nome] NCHAR(50) NULL, 
    [DataNascimento] DATETIME NULL, 
    [Sexo] NCHAR(1) NULL
)
