USE [SKU]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 23-09-2020 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[PromotionTypeId] [bigint] NOT NULL,
	[Rate] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Promotion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PromotionDetails]    Script Date: 23-09-2020 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PromotionId] [bigint] NULL,
	[SkuId] [bigint] NULL,
	[Quantity] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PromotionDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PromotionType]    Script Date: 23-09-2020 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PromotionType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PromotionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sku]    Script Date: 23-09-2020 23:57:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sku](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
	[UnitPrice] [money] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Sku] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([Id], [Name], [PromotionTypeId], [Rate], [IsActive]) VALUES (1, N'Buy 3 A for 130', 1, 130.0000, 1)
INSERT [dbo].[Promotion] ([Id], [Name], [PromotionTypeId], [Rate], [IsActive]) VALUES (2, N'Buy 2 B for 45', 1, 45.0000, 1)
INSERT [dbo].[Promotion] ([Id], [Name], [PromotionTypeId], [Rate], [IsActive]) VALUES (3, N'Buy C and D for 30', 2, 30.0000, 1)
SET IDENTITY_INSERT [dbo].[Promotion] OFF
GO
SET IDENTITY_INSERT [dbo].[PromotionDetails] ON 

INSERT [dbo].[PromotionDetails] ([Id], [PromotionId], [SkuId], [Quantity], [IsActive]) VALUES (1, 1, 1, 3, 1)
INSERT [dbo].[PromotionDetails] ([Id], [PromotionId], [SkuId], [Quantity], [IsActive]) VALUES (2, 2, 2, 2, 1)
INSERT [dbo].[PromotionDetails] ([Id], [PromotionId], [SkuId], [Quantity], [IsActive]) VALUES (3, 3, 3, 1, 1)
INSERT [dbo].[PromotionDetails] ([Id], [PromotionId], [SkuId], [Quantity], [IsActive]) VALUES (4, 3, 4, 1, 1)
SET IDENTITY_INSERT [dbo].[PromotionDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PromotionType] ON 

INSERT [dbo].[PromotionType] ([Id], [Name], [IsActive]) VALUES (1, N'N Items', 1)
INSERT [dbo].[PromotionType] ([Id], [Name], [IsActive]) VALUES (2, N'Combo', 1)
INSERT [dbo].[PromotionType] ([Id], [Name], [IsActive]) VALUES (3, N'% of Unit Price', 1)
SET IDENTITY_INSERT [dbo].[PromotionType] OFF
GO
SET IDENTITY_INSERT [dbo].[Sku] ON 

INSERT [dbo].[Sku] ([Id], [Name], [UnitPrice], [IsActive]) VALUES (1, N'A', 50.0000, 1)
INSERT [dbo].[Sku] ([Id], [Name], [UnitPrice], [IsActive]) VALUES (2, N'B', 30.0000, 1)
INSERT [dbo].[Sku] ([Id], [Name], [UnitPrice], [IsActive]) VALUES (3, N'C', 20.0000, 1)
INSERT [dbo].[Sku] ([Id], [Name], [UnitPrice], [IsActive]) VALUES (4, N'D', 15.0000, 1)
SET IDENTITY_INSERT [dbo].[Sku] OFF
GO
ALTER TABLE [dbo].[Promotion] ADD  CONSTRAINT [DF_Promotion_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PromotionDetails] ADD  CONSTRAINT [DF_PromotionDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PromotionType] ADD  CONSTRAINT [DF_PromotionType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Sku] ADD  CONSTRAINT [DF_Sku_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Promotion]  WITH CHECK ADD  CONSTRAINT [FK_Promotion_PromotionType] FOREIGN KEY([PromotionTypeId])
REFERENCES [dbo].[PromotionType] ([Id])
GO
ALTER TABLE [dbo].[Promotion] CHECK CONSTRAINT [FK_Promotion_PromotionType]
GO
ALTER TABLE [dbo].[PromotionDetails]  WITH CHECK ADD  CONSTRAINT [FK_PromotionDetails_Promotion] FOREIGN KEY([PromotionId])
REFERENCES [dbo].[Promotion] ([Id])
GO
ALTER TABLE [dbo].[PromotionDetails] CHECK CONSTRAINT [FK_PromotionDetails_Promotion]
GO
ALTER TABLE [dbo].[PromotionDetails]  WITH CHECK ADD  CONSTRAINT [FK_PromotionDetails_Sku] FOREIGN KEY([SkuId])
REFERENCES [dbo].[Sku] ([Id])
GO
ALTER TABLE [dbo].[PromotionDetails] CHECK CONSTRAINT [FK_PromotionDetails_Sku]
GO
