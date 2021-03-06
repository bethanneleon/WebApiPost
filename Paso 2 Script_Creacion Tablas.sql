USE [PostBD]
GO
/****** Object:  User [usr_post]    Script Date: 9/9/2021 8:52:02 PM ******/
CREATE USER [usr_post] FOR LOGIN [usr_post] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Entity]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entity](
	[IdEntity] [int] IDENTITY(1,1) NOT NULL,
	[NameEntity] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Entity] PRIMARY KEY CLUSTERED 
(
	[IdEntity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operation]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operation](
	[IdOperation] [int] IDENTITY(1,1) NOT NULL,
	[NameOperation] [varchar](20) NOT NULL,
	[IdEntity] [int] NOT NULL,
 CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED 
(
	[IdOperation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[TextContent] [varchar](500) NOT NULL,
	[PublishingDate] [datetime] NULL,
	[IdUser] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostComment]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[IdComment] [int] IDENTITY(1,1) NOT NULL,
	[TextComment] [varchar](500) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IdPost] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostStatus]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostStatus](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PostStatus] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleOperation]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleOperation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRole] [int] NOT NULL,
	[IdOperation] [int] NOT NULL,
	[IdStatus] [varchar](10) NULL,
 CONSTRAINT [PK_RoleOperation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/9/2021 8:52:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](10) NOT NULL,
	[IdRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Entity] ON 

INSERT [dbo].[Entity] ([IdEntity], [NameEntity]) VALUES (1, N'Post')
INSERT [dbo].[Entity] ([IdEntity], [NameEntity]) VALUES (2, N'PostComment')
SET IDENTITY_INSERT [dbo].[Entity] OFF
GO
SET IDENTITY_INSERT [dbo].[Operation] ON 

INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (1, N'GetAll', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (2, N'Create', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (3, N'Edit', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (4, N'Submit', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (5, N'Approve', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (6, N'Reject', 1)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (7, N'Add', 2)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (8, N'Get', 2)
INSERT [dbo].[Operation] ([IdOperation], [NameOperation], [IdEntity]) VALUES (9, N'Get', 1)
SET IDENTITY_INSERT [dbo].[Operation] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (1, N'Prueba', N'lkjfklsj sifjsjf kfjslji', NULL, 1, 5)
INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (2, N'Prueba 2', N'Tierra grita en la proa el navengante y confusa y distante una linea indecisa entre brumas y hondas se divisa...', NULL, 1, 5)
INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (3, N'Prueba 3', N'Abajo cadenas abajo cadenas gritaba el señor gritaba el señor...', NULL, 1, 5)
INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (4, N'Prueba 4', N'En salamanca famoso por su vida y buen talante al ataviado estudiante lo señalan entre mil ...', NULL, 1, 4)
INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (5, N'Prueba 5', N'Aunque la virgen sea blancao pintame angelitos negros...', CAST(N'2021-09-09T20:23:42.350' AS DateTime), 1, 5)
INSERT [dbo].[Post] ([IdPost], [Title], [TextContent], [PublishingDate], [IdUser], [IdStatus]) VALUES (6, N'Prueba 6', N'A la vuelta del amor nube eterna entre altas rocas, cita eterna tarde rota vuelvo sola como mi corazon...', NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[PostComment] ON 

INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (1, N'Prueba comentario', CAST(N'2021-09-08T20:44:44.177' AS DateTime), 2, 2)
INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (2, N'Rechazado por mala redacción.', CAST(N'2021-09-08T21:12:00.177' AS DateTime), 2, 2)
INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (3, N'Rechazado por mala redacción.', CAST(N'2021-09-08T21:44:26.727' AS DateTime), 4, 2)
INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (4, N'Rechazado por mala incompleto.', CAST(N'2021-09-09T20:19:53.877' AS DateTime), 5, 2)
INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (5, N'Prueba comentario', CAST(N'2021-09-09T20:24:30.187' AS DateTime), 5, 1)
INSERT [dbo].[PostComment] ([IdComment], [TextComment], [CreatedDate], [IdPost], [IdUser]) VALUES (6, N'Prueba comentario Role Public', CAST(N'2021-09-09T20:28:06.873' AS DateTime), 5, 3)
SET IDENTITY_INSERT [dbo].[PostComment] OFF
GO
SET IDENTITY_INSERT [dbo].[PostStatus] ON 

INSERT [dbo].[PostStatus] ([IdStatus], [Name]) VALUES (1, N'New')
INSERT [dbo].[PostStatus] ([IdStatus], [Name]) VALUES (2, N'Pending Publishing')
INSERT [dbo].[PostStatus] ([IdStatus], [Name]) VALUES (4, N'Rejected')
INSERT [dbo].[PostStatus] ([IdStatus], [Name]) VALUES (5, N'Published')
SET IDENTITY_INSERT [dbo].[PostStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (1, N'Writer')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (2, N'Editor')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (3, N'Public')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[RoleOperation] ON 

INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (1, 1, 1, N'5')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (2, 1, 2, NULL)
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (5, 1, 3, N'1,4')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (6, 1, 4, N'1,4')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (7, 1, 7, N'5')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (9, 2, 1, N'5,2')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (10, 2, 5, N'2')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (11, 2, 6, N'2')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (12, 2, 7, N'2,5')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (13, 1, 8, N'4')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (14, 3, 1, N'5')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (15, 3, 7, N'5')
INSERT [dbo].[RoleOperation] ([Id], [IdRole], [IdOperation], [IdStatus]) VALUES (16, 1, 9, N'1,4')
SET IDENTITY_INSERT [dbo].[RoleOperation] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [UserName], [Password], [IdRole]) VALUES (1, N'writer1', N'writer1', 1)
INSERT [dbo].[User] ([IdUser], [UserName], [Password], [IdRole]) VALUES (2, N'editor1', N'editor1', 2)
INSERT [dbo].[User] ([IdUser], [UserName], [Password], [IdRole]) VALUES (3, N'public1', N'public1', 3)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[PostComment] ADD  CONSTRAINT [DF_PostComment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Operation]  WITH CHECK ADD  CONSTRAINT [FK_Operation_Entity] FOREIGN KEY([IdEntity])
REFERENCES [dbo].[Entity] ([IdEntity])
GO
ALTER TABLE [dbo].[Operation] CHECK CONSTRAINT [FK_Operation_Entity]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_PostStatus] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[PostStatus] ([IdStatus])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_PostStatus]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_Post] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_Post]
GO
ALTER TABLE [dbo].[PostComment]  WITH CHECK ADD  CONSTRAINT [FK_PostComment_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[PostComment] CHECK CONSTRAINT [FK_PostComment_User]
GO
ALTER TABLE [dbo].[RoleOperation]  WITH CHECK ADD  CONSTRAINT [FK_RoleOperation_Operation] FOREIGN KEY([IdOperation])
REFERENCES [dbo].[Operation] ([IdOperation])
GO
ALTER TABLE [dbo].[RoleOperation] CHECK CONSTRAINT [FK_RoleOperation_Operation]
GO
ALTER TABLE [dbo].[RoleOperation]  WITH CHECK ADD  CONSTRAINT [FK_RoleOperation_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[RoleOperation] CHECK CONSTRAINT [FK_RoleOperation_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
