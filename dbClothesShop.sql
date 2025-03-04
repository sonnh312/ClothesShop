CREATE DATABASE dbClothesShop
GO
USE dbClothesShop
GO
/****** Object:  Table [dbo].[tb_Category]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Category](
	[ID_Category] [nchar](50) NOT NULL,
	[Name] [nchar](50) NULL,
	[Description] [nchar](50) NULL,
	[ID_Product] [nchar](50) NULL,
 CONSTRAINT [PK_tb_Category] PRIMARY KEY CLUSTERED 
(
	[ID_Category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Discount]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Discount](
	[ID_Cupon] [int] NULL,
	[Cupon_code] [nvarchar](50) NULL,
	[Discount_percent] [decimal](4, 0) NULL,
	[Valid_from] [datetime] NULL,
	[Valid_until] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Order_items]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Order_items](
	[ID_Order_items] [nvarchar](50) NULL,
	[ID_Order] [nchar](50) NULL,
	[ID_Product] [nchar](50) NULL,
	[Quantity] [text] NULL,
	[Unit_price] [float] NULL,
	[ID_Cupon] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Orders]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Orders](
	[ID_Order] [nchar](50) NOT NULL,
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Order_date] [date] NULL,
	[Total_amount] [float] NULL,
	[ID_Order_items] [nchar](50) NULL,
 CONSTRAINT [PK_tb_Orders] PRIMARY KEY CLUSTERED 
(
	[ID_Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Products]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Products](
	[ID_Product] [nchar](50) NOT NULL,
	[ID_Category] [nchar](50) NULL,
	[Name] [nchar](50) NULL,
	[Description] [nchar](50) NULL,
	[Price] [float] NULL,
	[Image] [image] NULL,
	[Stock_quantity] [int] NULL,
	[Created_at] [datetime] NULL,
	[Updated_at] [datetime] NULL,
	[Type] [text] NULL,
	[Size] [text] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Review]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Review](
	[ID_Review] [nchar](50) NOT NULL,
	[ID_Product] [nchar](50) NULL,
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [char](5) NULL,
	[Comment] [text] NULL,
	[Review_date] [datetime] NULL,
 CONSTRAINT [PK_tb_Review] PRIMARY KEY CLUSTERED 
(
	[ID_Review] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Supplier]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Supplier](
	[ID_Supplier] [int] IDENTITY(1,1) NOT NULL,
	[Suppiler_name] [nvarchar](50) NULL,
	[ID_Product] [nchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[ID_Supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_User]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_User](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Last Name] [nchar](50) NULL,
	[First Name] [nchar](50) NULL,
	[Email] [nchar](50) NULL,
	[Address] [nchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[ID_Order] [nchar](50) NULL,
	[ID_Review] [nchar](50) NULL,
	[ID_Wishlist] [nchar](50) NULL,
 CONSTRAINT [PK_tb_User] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Wishlist]    Script Date: 6/23/2024 1:00:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Wishlist](
	[ID_Wishlist] [nchar](50) NULL,
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[ID_Product] [nchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_Order_items]  WITH CHECK ADD  CONSTRAINT [FK_tb_Order_items_tb_Orders] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[tb_Orders] ([ID_Order])
GO
ALTER TABLE [dbo].[tb_Order_items] CHECK CONSTRAINT [FK_tb_Order_items_tb_Orders]
GO
ALTER TABLE [dbo].[tb_Order_items]  WITH CHECK ADD  CONSTRAINT [FK_tb_Order_items_tb_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[tb_Products] ([ID_Product])
GO
ALTER TABLE [dbo].[tb_Order_items] CHECK CONSTRAINT [FK_tb_Order_items_tb_Products]
GO
ALTER TABLE [dbo].[tb_Orders]  WITH CHECK ADD  CONSTRAINT [FK_tb_Orders_tb_User] FOREIGN KEY([ID_User])
REFERENCES [dbo].[tb_User] ([ID_User])
GO
ALTER TABLE [dbo].[tb_Orders] CHECK CONSTRAINT [FK_tb_Orders_tb_User]
GO
ALTER TABLE [dbo].[tb_Products]  WITH CHECK ADD  CONSTRAINT [FK_tb_Products_tb_Category] FOREIGN KEY([ID_Category])
REFERENCES [dbo].[tb_Category] ([ID_Category])
GO
ALTER TABLE [dbo].[tb_Products] CHECK CONSTRAINT [FK_tb_Products_tb_Category]
GO
ALTER TABLE [dbo].[tb_Review]  WITH CHECK ADD  CONSTRAINT [FK_tb_Review_tb_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[tb_Products] ([ID_Product])
GO
ALTER TABLE [dbo].[tb_Review] CHECK CONSTRAINT [FK_tb_Review_tb_Products]
GO
ALTER TABLE [dbo].[tb_Review]  WITH CHECK ADD  CONSTRAINT [FK_tb_Review_tb_User] FOREIGN KEY([ID_User])
REFERENCES [dbo].[tb_User] ([ID_User])
GO
ALTER TABLE [dbo].[tb_Review] CHECK CONSTRAINT [FK_tb_Review_tb_User]
GO
ALTER TABLE [dbo].[tb_Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_tb_Wishlist_tb_Products] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[tb_Products] ([ID_Product])
GO
ALTER TABLE [dbo].[tb_Wishlist] CHECK CONSTRAINT [FK_tb_Wishlist_tb_Products]
GO
ALTER TABLE [dbo].[tb_Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_tb_Wishlist_tb_User] FOREIGN KEY([ID_User])
REFERENCES [dbo].[tb_User] ([ID_User])
GO
ALTER TABLE [dbo].[tb_Wishlist] CHECK CONSTRAINT [FK_tb_Wishlist_tb_User]
GO
