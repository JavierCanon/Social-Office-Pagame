CREATE TABLE [dbo].[PAG_Usuario] (
    [UsuarioID]      INT              IDENTITY (1, 1) NOT NULL,
    [UsuarioGUID]    UNIQUEIDENTIFIER CONSTRAINT [DF_PAG_Usuario_UsuarioGUID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [CodCliente]     VARCHAR (60)     NOT NULL,
    [Email]          VARCHAR (120)    NOT NULL,
    [Password]       VARCHAR (1000)   NULL,
    [EmailValidado]  BIT              CONSTRAINT [DF_PAG_Usuario_EmailValidado] DEFAULT ((0)) NOT NULL,
    [UltimoLogin]    DATETIME         NULL,
    [LoginRedSocial] VARCHAR (60)     NULL,
    CONSTRAINT [PK_PAG_Usuario] PRIMARY KEY CLUSTERED ([UsuarioID] ASC)
);

