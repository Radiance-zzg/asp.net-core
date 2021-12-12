USE [MyBlogCore]
GO

/****** Object:  Table [dbo].[UserType]    Script Date: 2021/12/12 19:28:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserType](
	[TypeName] [nvarchar](50) NULL,
	[Level] [int] NOT NULL,
	[CityId] [nvarchar](50) NULL,
	[Isdelete] [bit] NULL
) ON [PRIMARY]
GO


