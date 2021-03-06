USE [WareHouse]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 28/12/2020 15:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [nvarchar](50) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 28/12/2020 15:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[arrive_time] [datetime] NOT NULL,
	[orderAmount] [decimal](10, 1) NOT NULL,
	[customer_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28/12/2020 15:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [nvarchar](50) NOT NULL,
	[quantity] [decimal](10, 1) NOT NULL,
	[description] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sellers]    Script Date: 28/12/2020 15:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sellers](
	[seller_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[seller_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (1, N'cname1', N'csurname1', N'email1.com', N'505050', N'adress1')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (2, N'cname2', N'csurname2', N'email2.com', N'515151', N'adress2')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (3, N'cname3', N'csurname3', N'email3.com', N'525252', N'adress3')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (4, N'cname4', N'csurname4', N'email4.com', N'88755', N'adress4')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (6, N'Farid', N'Imanzade', N'farid.com', N'(50) 517-84-54', N'Baku, Nizami dist.')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (7, N'Rasim', N'Mammadov', N'rasim.com', N'(50) 589-64-36', N'Baku, yasamal dist')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (8, N'Rafiq', N'Aliyev', N'rafiq.com', N'(99) 784-67-85', N'Baku, Khatai dist.')
INSERT [dbo].[Customers] ([customer_id], [name], [surname], [email], [phone], [address]) VALUES (9, N'Ramil', N'Ibrahimov', N'ramil.com', N'(70) 892-45-54', N'Baku, Sabuncu dist,')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (1, CAST(N'2020-06-07T00:00:00.000' AS DateTime), CAST(10.0 AS Decimal(10, 1)), 1, 2)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (2, CAST(N'2020-03-09T00:00:00.000' AS DateTime), CAST(18.0 AS Decimal(10, 1)), 4, 3)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (3, CAST(N'2020-10-19T07:15:30.000' AS DateTime), CAST(20.0 AS Decimal(10, 1)), 3, 1)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (4, CAST(N'2019-01-12T00:00:00.000' AS DateTime), CAST(100.0 AS Decimal(10, 1)), 2, 5)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (5, CAST(N'2020-06-07T00:00:00.000' AS DateTime), CAST(2.0 AS Decimal(10, 1)), 3, 3)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (14, CAST(N'2020-07-21T21:26:31.000' AS DateTime), CAST(7.0 AS Decimal(10, 1)), 6, 8)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (15, CAST(N'2020-07-16T21:28:47.000' AS DateTime), CAST(4.0 AS Decimal(10, 1)), 6, 8)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (19, CAST(N'2020-07-30T21:38:01.000' AS DateTime), CAST(4.0 AS Decimal(10, 1)), 6, 8)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (20, CAST(N'2020-07-11T22:50:07.000' AS DateTime), CAST(35.0 AS Decimal(10, 1)), 8, 9)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (21, CAST(N'2020-07-18T00:35:53.000' AS DateTime), CAST(17.0 AS Decimal(10, 1)), 8, 10)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (22, CAST(N'2020-07-18T00:55:14.000' AS DateTime), CAST(42.0 AS Decimal(10, 1)), 9, 11)
INSERT [dbo].[Orders] ([order_id], [arrive_time], [orderAmount], [customer_id], [product_id]) VALUES (23, CAST(N'2020-07-23T13:57:19.000' AS DateTime), CAST(4.0 AS Decimal(10, 1)), 6, 8)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (1, N'pname1', N'150', CAST(500.0 AS Decimal(10, 1)), N'good')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (2, N'pname2', N'160', CAST(230.0 AS Decimal(10, 1)), N'old')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (3, N'pname3', N'550', CAST(35.0 AS Decimal(10, 1)), N'well')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (5, N'pname5', N'350', CAST(789.0 AS Decimal(10, 1)), N'medium')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (7, N'pname7', N'1000', CAST(15.0 AS Decimal(10, 1)), N'perfect')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (8, N'iphoneX', N'1500', CAST(17.0 AS Decimal(10, 1)), N'new')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (9, N'Samsung', N'1250', CAST(1.0 AS Decimal(10, 1)), N'New TV')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (10, N'HP', N'2500', CAST(25.0 AS Decimal(10, 1)), N'Gaming New')
INSERT [dbo].[Products] ([product_id], [name], [price], [quantity], [description]) VALUES (11, N'Lenovo', N'300', CAST(8.0 AS Decimal(10, 1)), N'old')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Sellers] ON 

INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (1, N'username1', N'password1', N'name1', N'surname1')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (2, N'username2', N'password2', N'name2', N'surname2')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (3, N'username3', N'password3', N'name3', N'surname3')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (4, N'username4', N'password4', N'name4', N'surname4')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (5, N'Ahmet', N'999', N'Ahmet', N'Soylu')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (6, N'Seymur', N'100', N'Seymur', N'Mahmudov')
INSERT [dbo].[Sellers] ([seller_id], [username], [password], [name], [surname]) VALUES (7, N'Rasim', N'45', N'Rasim', N'Mammadov')
SET IDENTITY_INSERT [dbo].[Sellers] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customers] ([customer_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([product_id])
GO
