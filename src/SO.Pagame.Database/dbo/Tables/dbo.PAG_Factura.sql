CREATE TABLE [dbo].[PAG_Factura] (
    [FacturaID]         INT              IDENTITY (1, 1) NOT NULL,
    [FacturaGUID]       UNIQUEIDENTIFIER CONSTRAINT [DF_PAG_Factura_FacturaGUID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [CodCliente]        VARCHAR (60)     NULL,
    [Fecha]             DATE             NOT NULL,
    [Numero]            VARCHAR (30)     NOT NULL,
    [Moneda]            CHAR (3)         NULL,
    [Descripcion]       VARCHAR (200)    NULL,
    [Impuestos]         MONEY            CONSTRAINT [DF_PAG_Factura_Impuestos] DEFAULT ((0)) NOT NULL,
    [Total]             MONEY            CONSTRAINT [DF_PAG_Factura_Total] DEFAULT ((0)) NOT NULL,
    [Nota]              VARCHAR (1000)   NULL,
    [Pagada]            BIT              CONSTRAINT [DF_PAG_Factura_Pagada] DEFAULT ((0)) NOT NULL,
    [FechaPagada]       DATETIME         NULL,
    [PagadaPasarela]    VARCHAR (30)     NULL,
    [PasarelaRespuesta] VARCHAR (1000)   NULL,
    CONSTRAINT [PK_PAG_Factura] PRIMARY KEY CLUSTERED ([FacturaID] ASC)
);

