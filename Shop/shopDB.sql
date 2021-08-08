create database Trade
go

USE [Trade]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 06.08.2021 17:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ItemName] [varchar](500) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06.08.2021 17:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NULL,
	[DeliveryRegionId] [int] NOT NULL,
	[OrderPrice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Regions]    Script Date: 06.08.2021 17:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Regions](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [varchar](500) NOT NULL,
	[ParentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 06.08.2021 17:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06.08.2021 17:31:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](255) NULL,
	[FirstName] [varchar](255) NULL,
	[UserName] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON 
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (1, 1, N'Телофон нокиа', 1, 10000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (2, 2, N'Наушники', 3, 5000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (3, 3, N'Шапка', 4, 2000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (4, 2, N'Шины', 5, 32000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (5, 1, N'Стол', 1, 12000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (6, 4, N'Стул', 5, 13000)
GO
INSERT [dbo].[Items] ([ItemId], [OrderId], [ItemName], [Quantity], [Price]) VALUES (7, 5, N'Дерево', 1, 1000)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [DeliveryRegionId], [OrderPrice]) VALUES (1, CAST(N'2021-08-01' AS Date), 3, 25000)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [DeliveryRegionId], [OrderPrice]) VALUES (2, CAST(N'2021-08-04' AS Date), 5, 25000)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [DeliveryRegionId], [OrderPrice]) VALUES (3, CAST(N'2021-08-05' AS Date), 6, 25000)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [DeliveryRegionId], [OrderPrice]) VALUES (4, CAST(N'2021-08-06' AS Date), 10, 25000)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [DeliveryRegionId], [OrderPrice]) VALUES (5, CAST(N'2021-08-08' AS Date), 9, 25000)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Regions] ON 
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (1, N'Алматинcкая область', NULL)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (2, N'Жамбылская область', NULL)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (3, N'Капшагай', 1)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (4, N'Талгар', 1)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (5, N'Талдыкорган', 1)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (6, N'Текели', 1)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (7, N'Тараз', 2)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (8, N'Шу', 2)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (9, N'Мойынкум', 2)
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName], [ParentId]) VALUES (10, N'Бурный', 2)
GO
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'user')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'admin')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [LastName], [FirstName], [UserName], [Password], [RoleId]) VALUES (1, N'Траволта', N'Джон', N'john', N'123', 1)
GO
INSERT [dbo].[Users] ([Id], [LastName], [FirstName], [UserName], [Password], [RoleId]) VALUES (2, N'Барак', N'Обама', N'blm', N'1234', 1)
GO
INSERT [dbo].[Users] ([Id], [LastName], [FirstName], [UserName], [Password], [RoleId]) VALUES (3, N'Кидман', N'Николь', N'nick', N'12345', 1)
GO
INSERT [dbo].[Users] ([Id], [LastName], [FirstName], [UserName], [Password], [RoleId]) VALUES (4, N'Уик', N'Джон', N'jony', N'222', 2)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
