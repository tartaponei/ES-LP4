CREATE TABLE [dbo].[Professor]
(
	[Matricula] INT NOT NULL PRIMARY KEY, 
    [Nome] NCHAR(50) NULL, 
    [DtNascimento] DATETIME NULL, 
    [Sexo] NCHAR(1) NULL, 
    [Formação] NCHAR(50) NULL
)
