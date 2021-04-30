USE [PIC_SAS_PC_DEV]
GO

/****** Object:  Table [dbo].[ajuda]    Script Date: 30/04/2021 17:09:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ajuda](
	[id] [int] IDENTITY(100,1) NOT NULL,
	[descricao] [varchar](240) NULL,
	[palavras_chave] [varchar](160) NULL,
	[tipo_ajuda] [char](1) NULL,
	[texto] [text] NULL,
	[status] [char](1) NOT NULL,
 CONSTRAINT [PK_ajuda] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ajuda] ADD  DEFAULT ('A') FOR [status]
GO


