USE [master]
GO
/****** Object:  Database [HDMarketing]    Script Date: 2018-05-16 16:36:33 ******/
CREATE DATABASE [HDMarketing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HDMarketing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HDMarketing.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HDMarketing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\HDMarketing_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HDMarketing] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HDMarketing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HDMarketing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HDMarketing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HDMarketing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HDMarketing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HDMarketing] SET ARITHABORT OFF 
GO
ALTER DATABASE [HDMarketing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HDMarketing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HDMarketing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HDMarketing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HDMarketing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HDMarketing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HDMarketing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HDMarketing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HDMarketing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HDMarketing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HDMarketing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HDMarketing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HDMarketing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HDMarketing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HDMarketing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HDMarketing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HDMarketing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HDMarketing] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HDMarketing] SET  MULTI_USER 
GO
ALTER DATABASE [HDMarketing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HDMarketing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HDMarketing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HDMarketing] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HDMarketing] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HDMarketing]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[IDHopDong] [int] IDENTITY(1,1) NOT NULL,
	[MaHopDong] [nvarchar](50) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
	[IDKhachHang] [int] NULL,
	[IDLoaiHD] [int] NULL,
	[Active] [tinyint] NULL,
	[ChiPhi] [decimal](18, 0) NULL,
	[DaThanhToan] [decimal](18, 0) NULL,
	[NgayKy] [date] NULL,
	[NoiDung] [nvarchar](max) NULL,
	[HanHD] [date] NULL,
	[NguoiPhuTrach] [int] NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[IDHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[CongTy] [nvarchar](50) NULL,
	[NguoiDaiDien] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDTCTy] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Active] [tinyint] NULL,
	[MSThue] [nvarchar](50) NULL,
	[SDTLienHe] [nvarchar](50) NULL,
	[Logo] [nvarchar](500) NULL,
	[GhiChu] [nvarchar](2000) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiHD]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHD](
	[IDLoaiHD] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiHD] [nvarchar](50) NULL,
	[TenLoaiHD] [nvarchar](50) NULL,
	[Active] [tinyint] NULL,
	[Mota] [nvarchar](500) NULL,
 CONSTRAINT [PK_LoaiHD] PRIMARY KEY CLUSTERED 
(
	[IDLoaiHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IDTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[FullName] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
	[Adress] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Active] [tinyint] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[IDTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieu]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu](
	[IDTaiLieu] [int] IDENTITY(1,1) NOT NULL,
	[TenTaiLieu] [nvarchar](500) NULL,
	[IDHopDong] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
	[MoTa] [nvarchar](2000) NULL,
	[File] [nvarchar](500) NULL,
 CONSTRAINT [PK_TaiLieu] PRIMARY KEY CLUSTERED 
(
	[IDTaiLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 2018-05-16 16:36:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[IDThanhToan] [int] IDENTITY(1,1) NOT NULL,
	[NgayTT] [date] NULL,
	[NguoiTao] [int] NULL,
	[SoTien] [decimal](18, 0) NULL,
	[IDHopDong] [int] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[IDThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[HopDong] ON 

INSERT [dbo].[HopDong] ([IDHopDong], [MaHopDong], [NgayTao], [NguoiTao], [IDKhachHang], [IDLoaiHD], [Active], [ChiPhi], [DaThanhToan], [NgayKy], [NoiDung], [HanHD], [NguoiPhuTrach]) VALUES (1, N'HD - abc', NULL, NULL, 2, 1, 1, CAST(90000000 AS Decimal(18, 0)), NULL, CAST(N'2018-01-06' AS Date), N'0987654321', CAST(N'2018-01-01' AS Date), 1)
INSERT [dbo].[HopDong] ([IDHopDong], [MaHopDong], [NgayTao], [NguoiTao], [IDKhachHang], [IDLoaiHD], [Active], [ChiPhi], [DaThanhToan], [NgayKy], [NoiDung], [HanHD], [NguoiPhuTrach]) VALUES (2, N'HD - abc', NULL, NULL, 2, 1, 1, CAST(90000000 AS Decimal(18, 0)), NULL, CAST(N'2018-01-01' AS Date), N'0987654321', CAST(N'2018-01-01' AS Date), 1)
INSERT [dbo].[HopDong] ([IDHopDong], [MaHopDong], [NgayTao], [NguoiTao], [IDKhachHang], [IDLoaiHD], [Active], [ChiPhi], [DaThanhToan], [NgayKy], [NoiDung], [HanHD], [NguoiPhuTrach]) VALUES (3, N'GG demo', CAST(N'2018-05-03 11:56:33.927' AS DateTime), 1, 3, 3, 1, CAST(5600000 AS Decimal(18, 0)), CAST(5600000 AS Decimal(18, 0)), CAST(N'2018-05-04' AS Date), N'NoiDung', CAST(N'2018-07-21' AS Date), 1)
INSERT [dbo].[HopDong] ([IDHopDong], [MaHopDong], [NgayTao], [NguoiTao], [IDKhachHang], [IDLoaiHD], [Active], [ChiPhi], [DaThanhToan], [NgayKy], [NoiDung], [HanHD], [NguoiPhuTrach]) VALUES (4, N'002', CAST(N'2018-05-15 16:18:30.660' AS DateTime), 1, 2, 1, 1, CAST(20000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), CAST(N'2018-05-15' AS Date), N'abc', CAST(N'2018-05-22' AS Date), 1)
SET IDENTITY_INSERT [dbo].[HopDong] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([IDKhachHang], [CongTy], [NguoiDaiDien], [DiaChi], [SDTCTy], [Email], [Active], [MSThue], [SDTLienHe], [Logo], [GhiChu]) VALUES (2, N'DoMiNa', N'Maketing', N'Maketing', N'0987654321', N'Maketing@gmail.com', 1, N'0987654321', N'Maketing', N'/Content/Upload\03052018112205_setting48.png', N'0987654321')
INSERT [dbo].[KhachHang] ([IDKhachHang], [CongTy], [NguoiDaiDien], [DiaChi], [SDTCTy], [Email], [Active], [MSThue], [SDTLienHe], [Logo], [GhiChu]) VALUES (3, N'demo', N'demo', N'HN', N'0987654321', N'tiephoang.dev@gmail.com', 1, N'0987654321', N'0987654321', N'/Content/Upload\03052018115505_Close Window_32px.png', NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiHD] ON 

INSERT [dbo].[LoaiHD] ([IDLoaiHD], [MaLoaiHD], [TenLoaiHD], [Active], [Mota]) VALUES (1, N'Facebook', N'HD Facebook', 1, N'Facebook')
INSERT [dbo].[LoaiHD] ([IDLoaiHD], [MaLoaiHD], [TenLoaiHD], [Active], [Mota]) VALUES (2, N'Maketing', N'Maketing', 1, N'Maketing')
INSERT [dbo].[LoaiHD] ([IDLoaiHD], [MaLoaiHD], [TenLoaiHD], [Active], [Mota]) VALUES (3, N'Google demo', N'Google', 1, N'Google')
SET IDENTITY_INSERT [dbo].[LoaiHD] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([IDTaiKhoan], [Username], [Password], [Avatar], [FullName], [Birthday], [Adress], [Phone], [Email], [ChucVu], [Active], [Description]) VALUES (1, N'admin', N'admin', NULL, N'Quản lý', CAST(N'1990-01-01' AS Date), N'Hà Nội', N'0987654321', N'QuanLy@gmail.com', N'ADMIN', 1, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[TaiLieu] ON 

INSERT [dbo].[TaiLieu] ([IDTaiLieu], [TenTaiLieu], [IDHopDong], [NgayTao], [NguoiTao], [MoTa], [File]) VALUES (1, N'123', 1, CAST(N'2018-05-03 11:54:01.313' AS DateTime), 1, N'123', N'/Content/Upload\03052018115401_New Text Document.txt')
INSERT [dbo].[TaiLieu] ([IDTaiLieu], [TenTaiLieu], [IDHopDong], [NgayTao], [NguoiTao], [MoTa], [File]) VALUES (2, N'123', 3, CAST(N'2018-05-03 11:56:56.533' AS DateTime), 1, N'Ảnh', N'/Content/Upload\03052018115656_vinacomin.JPG')
SET IDENTITY_INSERT [dbo].[TaiLieu] OFF
SET IDENTITY_INSERT [dbo].[ThanhToan] ON 

INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (1, CAST(N'2018-05-04' AS Date), NULL, CAST(89000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (3, CAST(N'2018-05-07' AS Date), 1, CAST(10000000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (4, CAST(N'2018-05-07' AS Date), 1, CAST(100000 AS Decimal(18, 0)), 3)
INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (5, CAST(N'2018-05-07' AS Date), 1, CAST(5000000 AS Decimal(18, 0)), 3)
INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (6, CAST(N'2018-05-07' AS Date), 1, CAST(500000 AS Decimal(18, 0)), 3)
INSERT [dbo].[ThanhToan] ([IDThanhToan], [NgayTT], [NguoiTao], [SoTien], [IDHopDong]) VALUES (7, CAST(N'2018-05-15' AS Date), 1, CAST(10000000 AS Decimal(18, 0)), 4)
SET IDENTITY_INSERT [dbo].[ThanhToan] OFF
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_KhachHang]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_LoaiHD] FOREIGN KEY([IDLoaiHD])
REFERENCES [dbo].[LoaiHD] ([IDLoaiHD])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_LoaiHD]
GO
ALTER TABLE [dbo].[HopDong]  WITH CHECK ADD  CONSTRAINT [FK_HopDong_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([IDTaiKhoan])
GO
ALTER TABLE [dbo].[HopDong] CHECK CONSTRAINT [FK_HopDong_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu_HopDong] FOREIGN KEY([IDHopDong])
REFERENCES [dbo].[HopDong] ([IDHopDong])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [FK_TaiLieu_HopDong]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([IDTaiKhoan])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [FK_TaiLieu_TaiKhoan]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_HopDong] FOREIGN KEY([IDHopDong])
REFERENCES [dbo].[HopDong] ([IDHopDong])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_HopDong]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([IDTaiKhoan])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_TaiKhoan]
GO
USE [master]
GO
ALTER DATABASE [HDMarketing] SET  READ_WRITE 
GO
