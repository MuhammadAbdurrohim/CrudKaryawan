CREATE TABLE [dbo].[KaryawanModel] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [Nama]   NVARCHAR(MAX) NOT NULL,
    [Alamat] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [PK_KaryawanModel] PRIMARY KEY CLUSTERED ([Id] ASC)
);

