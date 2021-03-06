USE [master]
GO
/****** Object:  Database [QuanLyKhoThuocBenhVien]    Script Date: 23/10/2018 12:20:54 SA ******/
CREATE DATABASE [QuanLyKhoThuocBenhVien]
GO
USE [QuanLyKhoThuocBenhVien]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[MoreInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Input]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Input](
	[Id] [nvarchar](128) NOT NULL,
	[DateInput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InputInfo]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdInput] [nvarchar](128) NOT NULL,
	[Count] [int] NULL,
	[InputPrice] [float] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Object]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Object](
	[Id] [nvarchar](128) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[IdUnit] [int] NOT NULL,
	[IdSuplier] [int] NOT NULL,
	[Price] [float] NULL,
	[QRCode] [nvarchar](max) NULL,
	[BarCode] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Output]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Output](
	[Id] [nvarchar](128) NOT NULL,
	[DateOutput] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OutputInfo]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutputInfo](
	[Id] [nvarchar](128) NOT NULL,
	[IdObject] [nvarchar](128) NOT NULL,
	[IdOutput] [nvarchar](128) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[Count] [int] NULL,
	[OutputPrice] [float] NULL,
	[Status] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Suplier]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[MoreInfo] [nvarchar](max) NULL,
	[ContractDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[IdRole] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 23/10/2018 12:20:54 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (1, N'Khoa tim mạch', N'123456', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (2, N'Khoa cấp cứu', N'123789', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (3, N'Khoa tai-mũi-họng', N'456789', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (4, N'Khoa tiêu hóa', N'123478', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (5, N'Khoa chấn thương chỉnh hình', N'123456', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (6, N'Khoa phụ sản', N'0123456', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (7, N'Khoa thần kinh', N'0123456', NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Phone], [MoreInfo]) VALUES (8, N'Khoa khám bệnh', N'0123456789', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'3642d049-28b6-4319-a571-d36634bc5689', CAST(0x0000A97B00000000 AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'6ac8bbc2-9c8f-4264-9d2b-e92bf8fe1bcf', CAST(0x0000A97F00000000 AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'7f4ebf2b-d428-429e-b316-53a5a4019775', CAST(0x0000A97800000000 AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'84ef755b-c2fe-4171-8ee2-0fa3ffeb1091', CAST(0x0000A97300000000 AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'bf495897-7d5a-47fa-817d-36023c416ab4', CAST(0x0000A97F00000000 AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'c15f0ce7-5050-4a06-99ec-30d07e08b55f', CAST(0x0000A97500000000 AS DateTime))
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'0f20c2f6-80eb-4c11-b82e-e2924c00f97f', N'923a0dc7-ffda-44be-adcb-9b2ad8c7a320', N'7f4ebf2b-d428-429e-b316-53a5a4019775', 100, 1500000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'2f316047-0fd6-48fa-89a7-8cfb6bf1b5c0', N'3804a76b-e0e9-4992-b38e-59eb8e58dbf8', N'c15f0ce7-5050-4a06-99ec-30d07e08b55f', 5, 800000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'337f3c14-1494-4bdb-91c4-a16c5955d8d4', N'8d0d9b11-d116-440a-bfe3-5ea0d9c68663', N'c15f0ce7-5050-4a06-99ec-30d07e08b55f', 15, 150000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'374b2ccb-2c04-4f97-8ff4-199ec7d753dc', N'84315e1e-97c2-4a70-be65-19a27fe3f3b1', N'7f4ebf2b-d428-429e-b316-53a5a4019775', 50, 500000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'54d91c5d-f950-4d58-82d4-a647440ceca1', N'2cb21d65-7bcc-4480-a7aa-f44ddb3cef2c', N'c15f0ce7-5050-4a06-99ec-30d07e08b55f', 30, 200000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'73240f97-2063-487d-b461-1a12cd694ea9', N'2028d571-d9d2-4aaa-991f-26f6d256915f', N'84ef755b-c2fe-4171-8ee2-0fa3ffeb1091', 10, 100000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'74e5c805-7aa7-4fe8-92d3-a2d8f321c463', N'8d0d9b11-d116-440a-bfe3-5ea0d9c68663', N'6ac8bbc2-9c8f-4264-9d2b-e92bf8fe1bcf', 20, 400000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'7baf91dd-32e4-415c-a25a-2d149eae6528', N'b3d3c5cb-fec8-46ad-97ef-baa725a41150', N'3642d049-28b6-4319-a571-d36634bc5689', 30, 300000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'9459ed62-b2b5-4868-9543-108c2621058c', N'f24c5778-0b4a-497c-a180-83885acc8979', N'bf495897-7d5a-47fa-817d-36023c416ab4', 30, 400000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'c8dbe828-802f-49dd-ada6-9e517c8ca537', N'dd813ec7-32f9-44dd-a429-53c460f716fb', N'6ac8bbc2-9c8f-4264-9d2b-e92bf8fe1bcf', 10, 230000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'e441994a-efb4-467e-b599-ff8f7b03ee2b', N'30d87268-f4c0-49a4-91b1-1ec661eb28c5', N'84ef755b-c2fe-4171-8ee2-0fa3ffeb1091', 15, 150000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'ece8ff8c-d250-42d1-a044-79e103175ca8', N'df9fe6e6-0bb4-4fb9-8393-b5952120ba95', N'3642d049-28b6-4319-a571-d36634bc5689', 25, 250000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'fdee78fc-0446-4b08-b5b8-88ae68c4b94f', N'84315e1e-97c2-4a70-be65-19a27fe3f3b1', N'6ac8bbc2-9c8f-4264-9d2b-e92bf8fe1bcf', 15, 150000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [Status]) VALUES (N'fe3a1251-6662-4a2c-b480-c4b78feea8f3', N'7a1b1c54-9a46-4a65-a644-aa63a18520a7', N'3642d049-28b6-4319-a571-d36634bc5689', 20, 150000, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'2028d571-d9d2-4aaa-991f-26f6d256915f', N'Efferalgan', 7, 1, 6000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'2cb21d65-7bcc-4480-a7aa-f44ddb3cef2c', N'Paracetamol', 2, 1, 20000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'30d87268-f4c0-49a4-91b1-1ec661eb28c5', N'Dextromethophan', 7, 3, 4000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'3804a76b-e0e9-4992-b38e-59eb8e58dbf8', N'Salonpas', 4, 3, 200000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'7a1b1c54-9a46-4a65-a644-aa63a18520a7', N'Rhumenol', 5, 4, 34000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'7a4c6f9b-4937-44bd-906d-5e5c2dc80f07', N'Decolsin', 1, 2, 26000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'84315e1e-97c2-4a70-be65-19a27fe3f3b1', N'Vaseline', 3, 2, 40000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'8d0d9b11-d116-440a-bfe3-5ea0d9c68663', N'Aspirin', 1, 4, 50000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'923a0dc7-ffda-44be-adcb-9b2ad8c7a320', N'Chlorpheniramine', 8, 5, 15000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'b3d3c5cb-fec8-46ad-97ef-baa725a41150', N'Panadol', 3, 1, 16000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'dd813ec7-32f9-44dd-a429-53c460f716fb', N'Naphazolin', 5, 1, 30000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'df9fe6e6-0bb4-4fb9-8393-b5952120ba95', N'Oxymetazolin', 2, 4, 30000, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [Price], [QRCode], [BarCode]) VALUES (N'f24c5778-0b4a-497c-a180-83885acc8979', N'Thuốc nhỏ mắt', 3, 4, 60000, NULL, NULL)
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'1f71faeb-0383-4d29-80ea-d0e114374ead', CAST(0x0000A97C00000000 AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'60a3dbc5-97b9-4af6-ae31-5ec3d0d39bc8', CAST(0x0000A97900000000 AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'790b7275-15cc-4993-90b5-15458d288caf', CAST(0x0000A98101353E1A AS DateTime))
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'096d83a5-f866-4494-9adf-0859825c03ee', N'30d87268-f4c0-49a4-91b1-1ec661eb28c5', N'60a3dbc5-97b9-4af6-ae31-5ec3d0d39bc8', 1, 15, 60000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'2334bc25-ed72-452a-a2cb-4f4638904784', N'2cb21d65-7bcc-4480-a7aa-f44ddb3cef2c', N'60a3dbc5-97b9-4af6-ae31-5ec3d0d39bc8', 1, 10, 200000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'5df00e62-8899-41f1-bba9-0a2b693eb49d', N'7a1b1c54-9a46-4a65-a644-aa63a18520a7', N'1f71faeb-0383-4d29-80ea-d0e114374ead', 2, 20, 680000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'9d601533-50d7-410c-940f-4fd8a6322afd', N'84315e1e-97c2-4a70-be65-19a27fe3f3b1', N'790b7275-15cc-4993-90b5-15458d288caf', 4, 10, 400000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'a3bc32d2-abb7-421b-9024-246cc2c82f03', N'2028d571-d9d2-4aaa-991f-26f6d256915f', N'60a3dbc5-97b9-4af6-ae31-5ec3d0d39bc8', 1, 5, 30000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'af3d6197-47b4-47cd-8251-f2b20401edad', N'b3d3c5cb-fec8-46ad-97ef-baa725a41150', N'790b7275-15cc-4993-90b5-15458d288caf', 4, 20, 320000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'cc1b6ad9-4547-471d-867f-6d5a1a4769ec', N'923a0dc7-ffda-44be-adcb-9b2ad8c7a320', N'790b7275-15cc-4993-90b5-15458d288caf', 4, 10, 150000, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutput], [IdCustomer], [Count], [OutputPrice], [Status]) VALUES (N'fb990adc-52d5-4fed-b3ca-875297418595', N'3804a76b-e0e9-4992-b38e-59eb8e58dbf8', N'1f71faeb-0383-4d29-80ea-d0e114374ead', 2, 1, 200000, NULL)
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'Pharmaland', N'2/21 Quách Văn Tuấn, P.12, Q.Tân Bình, TP.HCM', N'08.6262 1619', N'info@pharmaland.vn', NULL, CAST(0x0000A96C00000000 AS DateTime))
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'Công Ty TNHH Onplaza Việt Pháp', N'618 đường 3 tháng 2 P.14, Quận 10, TP. HCM', N'01234567', N'onplaza@gmail.com', NULL, CAST(0x0000A96F00000000 AS DateTime))
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (3, N'Công Ty Cổ Phần Difoco', N'289 Đinh Bộ Lĩnh, P. 26, Q. Bình Thạnh, TpHCM ', N'(028) 6685 7787', N'difoco@gmail.com', NULL, CAST(0x0000A981012DCD21 AS DateTime))
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (4, N'Công Ty Cổ Phần Neemtree', N'37/5B Trung Mỹ Tây, Trung Chánh, Hóc Môn, Tp.HCM ', N'02871066869', N'neemtree@gmail.com', NULL, CAST(0x0000A97800000000 AS DateTime))
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (5, N'Công Ty Cổ Phần Four-H', N'57/7F, Hồ Bá Phấn, P. Phước Long A, Q. 9, TpHCM ', N'(028) 62808488', N'fourh@gmail.com', NULL, CAST(0x0000A97D00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Suplier] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (1, N'Lọ')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (2, N'Vỉ')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (3, N'Hộp')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (4, N'Thùng')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (5, N'Gói')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (6, N'Bao')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (7, N'Viên')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (8, N'Ống')
SET IDENTITY_INSERT [dbo].[Unit] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'ADMIN', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[User] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân viên', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
INSERT [dbo].[User] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (15, N'Trường ĐH Mở TPHCM', N'ou', N'332335c624ea98b6015a68962a8259a0', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
ALTER TABLE [dbo].[InputInfo] ADD  DEFAULT ((0)) FOR [InputPrice]
GO
ALTER TABLE [dbo].[Object] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[OutputInfo] ADD  DEFAULT ((0)) FOR [OutputPrice]
GO
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdInput])
REFERENCES [dbo].[Input] ([Id])
GO
ALTER TABLE [dbo].[InputInfo]  WITH CHECK ADD FOREIGN KEY([IdObject])
REFERENCES [dbo].[Object] ([Id])
GO
ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([IdSuplier])
REFERENCES [dbo].[Suplier] ([Id])
GO
ALTER TABLE [dbo].[Object]  WITH CHECK ADD FOREIGN KEY([IdUnit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdObject])
REFERENCES [dbo].[Object] ([Id])
GO
ALTER TABLE [dbo].[OutputInfo]  WITH CHECK ADD FOREIGN KEY([IdOutput])
REFERENCES [dbo].[Output] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[UserRole] ([Id])
GO
USE [master]
GO
ALTER DATABASE [QuanLyKhoThuocBenhVien] SET  READ_WRITE 
GO
