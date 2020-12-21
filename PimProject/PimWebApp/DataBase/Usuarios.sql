USE [PasswordCRUD]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/20/2020 9:23:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [nchar](500) NOT NULL,
	[NombreUsuario] [nchar](30) NULL,
	[Correo] [nchar](50) NOT NULL,
	[Contraseña] [nchar](30) NOT NULL,
	[Nota] [nchar](50) NULL,
	[ID_Categoria] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


