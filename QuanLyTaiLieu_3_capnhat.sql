USE [QuanLyTaiLieuSV]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Class] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[Birth] [date] NULL,
	[Image] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[StudentCode] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[LastLogin] [datetime2](7) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminMenu]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminMenu](
	[AdminMenuID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](50) NULL,
	[ItemLevel] [int] NULL,
	[ParentLevel] [int] NULL,
	[ItemOrder] [int] NULL,
	[IsActive] [bit] NULL,
	[ItemTarget] [nvarchar](50) NULL,
	[AreaName] [nvarchar](50) NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
	[IdName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AdminMenu] PRIMARY KEY CLUSTERED 
(
	[AdminMenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Alias] [nvarchar](50) NULL,
	[Description] [nvarchar](4000) NULL,
	[Detail] [nvarchar](4000) NULL,
	[Image] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[AccountID] [int] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogComment]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogComment](
	[BlogCommentID] [int] IDENTITY(1,1) NOT NULL,
	[BlogID] [int] NULL,
	[AccountID] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Detail] [nvarchar](4000) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_BlogComment] PRIMARY KEY CLUSTERED 
(
	[BlogCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Class] [nchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
	[Levels] [int] NULL,
	[ParentID] [int] NULL,
	[Link] [nvarchar](50) NULL,
	[MenuOrder] [int] NULL,
	[Position] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubComment]    Script Date: 11/11/2024 7:22:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubComment](
	[SubCommentID] [int] IDENTITY(1,1) NOT NULL,
	[AccountID] [int] NULL,
	[BlogCommentID] [int] NULL,
	[Detail] [text] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_SubComment] PRIMARY KEY CLUSTERED 
(
	[SubCommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountID], [UserName], [FullName], [Password], [Class], [Gender], [Birth], [Image], [Phone], [StudentCode], [RoleID], [IsActive], [LastLogin], [Email]) VALUES (2, N'demo', N'NGUYỄN TRỌNG THẮNG', N'202cb962ac59075b964b07152d234b70', N'62k7', N'Nam', CAST(N'2002-06-20' AS Date), N'/images/logo đại học vinh.jpg', N'0385537242', N'2100347', 2, 1, NULL, N'demo@gmail.com')
INSERT [dbo].[Account] ([AccountID], [UserName], [FullName], [Password], [Class], [Gender], [Birth], [Image], [Phone], [StudentCode], [RoleID], [IsActive], [LastLogin], [Email]) VALUES (5, N'admin', N'admin', N'202cb962ac59075b964b07152d234b70', N'62k5', N'Nam', CAST(N'2003-06-12' AS Date), N'/images/avatar_nguyentrongthang.jpg', N'0946352718', N'2100294', 1, 1, NULL, N'admin@gmail.com')
INSERT [dbo].[Account] ([AccountID], [UserName], [FullName], [Password], [Class], [Gender], [Birth], [Image], [Phone], [StudentCode], [RoleID], [IsActive], [LastLogin], [Email]) VALUES (6, N'Thang', N'Nguyễn Trọng Thắng', N'2213046aaf694f644a5516bf1b990fc2', N'62k5', N'Nam', CAST(N'2001-06-13' AS Date), N'/images/logovinh.jpg', N'0946352718', N'00239', 3, 1, NULL, N'trangs123@gmail.com')
INSERT [dbo].[Account] ([AccountID], [UserName], [FullName], [Password], [Class], [Gender], [Birth], [Image], [Phone], [StudentCode], [RoleID], [IsActive], [LastLogin], [Email]) VALUES (7, N'Hoàng ', N'Nguyễn Trọng Hoàng', N'4af3f0c2cd42a25d06eb34456f571ed2', N'62k7', N'Nam', CAST(N'2003-01-29' AS Date), NULL, N'0385577242', N'00456', 3, 1, NULL, N'hoang20002@gmail.com')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminMenu] ON 

INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (1, N'Quản lý Menu', 1, 0, 1, 1, N'forms-nav', N'Admin', N'Home', N'Index', N'bi bi-menu-button-wide', N'forms-nav')
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (2, N'Danh sách Menu', 2, 1, 1, 1, NULL, N'Admin', N'Menu', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (3, N'Quản lý bài viết', 1, 0, 1, 1, N'components-nav', N'Admin', N'Blogs', N'Index', N'bi bi-journal', N'components-nav')
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (4, N'Danh sách bài viết', 2, 3, 1, 1, NULL, N'Admin', N'Blogs', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (5, N'Danh sách menu admin', 2, 1, 2, 1, NULL, N'Admin', N'AdminMenus', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10004, N'Quản lý tài khoản', 1, 0, 1, 1, N'accounts-nav', N'Admin', N'Accounts', N'Index', N'bi bi-journal', N'accounts-nav')
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10005, N'Danh sách tài khoản', 2, 10004, 1, 1, NULL, N'Admin', N'Accounts', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10006, N'Quản lý tài liệu', 1, 0, 1, 1, N'documents-nav', N'Admin', N'Documents', N'Index', N'bi bi-journal-text', N'documents-nav')
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10007, N'Tài liệu', 2, 10006, 1, 1, NULL, N'Admin', N'Documents', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10008, N'Môn học', 2, 10006, 2, 1, NULL, N'Admin', N'Documents', N'Index', NULL, NULL)
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10009, N'Quản lý liên hệ', 1, 0, 1, 1, N'contact-nav', N'Admin', N'Contacts', N'Index', N'bi bi-journal-text', N'contact-nav')
INSERT [dbo].[AdminMenu] ([AdminMenuID], [ItemName], [ItemLevel], [ParentLevel], [ItemOrder], [IsActive], [ItemTarget], [AreaName], [ControllerName], [ActionName], [Icon], [IdName]) VALUES (10010, N'Danh sách liên hệ', 2, 10009, 1, 1, NULL, N'Admin', N'Contacts', N'Index', NULL, NULL)
SET IDENTITY_INSERT [dbo].[AdminMenu] OFF
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([BlogID], [Title], [Alias], [Description], [Detail], [Image], [CreatedDate], [CreatedBy], [IsActive], [AccountID]) VALUES (1, N'Thông báo bảo trì', N'dai-hoc-vinh', N'Bảo trì định kì', N'<div><span style="background-color: var(--bs-card-bg); font-size: var(--bs-body-font-size); font-weight: var(--bs-body-font-weight); text-align: var(--bs-body-text-align);">Kính gửi Người dùng hệ thống,</span></div><div><br></div><div>Hiện tại, hệ thống của chúng tôi đang được bảo trì để nâng cao chất lượng dịch vụ. Trong thời gian này, một số chức năng có thể không khả dụng. Chúng tôi xin lỗi vì sự bất tiện này và rất mong nhận được sự thông cảm từ Quý khách.</div><div>Thời gian bảo trì dự kiến: Từ [ngày, giờ bắt đầu] đến [ngày, giờ kết thúc].</div><div>Sau khi quá trình bảo trì hoàn tất, hệ thống sẽ hoạt động trở lại bình thường. Xin cảm ơn Quý khách đã luôn đồng hành và ủng hộ chúng tôi.</div><div>Trân trọng,&nbsp;&nbsp;</div><div>[Đội ngũ hỗ trợ khách hàng hoặc tên công ty]</div><div>Thông báo này sẽ giúp người dùng hiểu rõ lý do và thời gian dự kiến của việc bảo trì, đồng thời thể hiện sự chuyên nghiệp và trách nhiệm của hệ thống hỗ trợ.</div>', N'/files/Picture1.png', NULL, NULL, 1, NULL)
INSERT [dbo].[Blog] ([BlogID], [Title], [Alias], [Description], [Detail], [Image], [CreatedDate], [CreatedBy], [IsActive], [AccountID]) VALUES (4, N'Đại học vinh', N'dai-hoc-vinh', N'Bảo trì định kì', N'Thông báo bảo trì', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Blog] ([BlogID], [Title], [Alias], [Description], [Detail], [Image], [CreatedDate], [CreatedBy], [IsActive], [AccountID]) VALUES (6, N'Đại học vinh3', N'dai-hoc-vinh', N'Bảo trì định kì', N'<p>Thông báo bảo trì 1 2 3</p>', NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Blog] ([BlogID], [Title], [Alias], [Description], [Detail], [Image], [CreatedDate], [CreatedBy], [IsActive], [AccountID]) VALUES (8, N'Đại học vinh5', N'dai-hoc-vinh', N'Bảo trì định kì', N'<h3>1. Các bước xây dựng chương trình nhận diện đối tượng với YOLO</h3><ul><li><strong>Bước 1</strong>: Cài đặt các thư viện cần thiết, bao gồm các thư viện YOLO, OpenCV, hoặc các thư viện liên quan.</li><li><strong>Bước 2</strong>: Tải mô hình YOLO và các trọng số (weights). Các phiên bản YOLO phổ biến như YOLOv5 hoặc YOLOv8 có thể tải từ trang của Ultralytics hoặc các nguồn mở khác.</li><li><strong>Bước 3</strong>: Xử lý ảnh đầu vào bằng cách tải ảnh hoặc video và đưa vào mô hình.</li><li><strong>Bước 4</strong>: Mô hình YOLO sẽ trả về danh sách các đối tượng được phát hiện, kèm theo tọa độ bounding box, độ tin cậy (confidence), và nhãn lớp (class label).</li><li><strong>Bước 5</strong>: Hiển thị kết quả bằng cách vẽ bounding box và nhãn lớp lên ảnh hoặc video để minh họa các đối tượng đã được phát hiện.</li></ul><h3>2. Đầu ra mong đợi</h3><p>Kết quả sau khi sử dụng YOLO để nhận diện đối tượng thường bao gồm:</p><ul><li><strong>Bounding Box</strong>: Một hộp giới hạn cho từng đối tượng được phát hiện. Mỗi bounding box được xác định bởi tọa độ (x, y), chiều rộng và chiều cao.</li><li><strong>Nhãn lớp (Class label)</strong>: Nhãn cho biết loại đối tượng mà mô hình đã phát hiện, ví dụ: người, xe hơi, chó, mèo,…</li><li><strong>Độ tin cậy (Confidence Score)</strong>: Mỗi bounding box đi kèm với một độ tin cậy, cho biết mức độ chắc chắn của mô hình trong việc phát hiện đối tượng.</li></ul><p>Ví dụ: Nếu bạn dùng YOLO để nhận diện đối tượng trong một bức ảnh đường phố, kết quả có thể là:</p><ul><li><strong>Người</strong>: bounding box [x1, y1, x2, y2], độ tin cậy 95%</li><li><strong>Xe hơi</strong>: bounding box [x3, y3, x4, y4], độ tin cậy 90%</li><li><strong>Đèn giao thông</strong>: bounding box [x5, y5, x6, y6], độ tin cậy 85%</li></ul><h3>3. Hiển thị kết quả</h3><p>Một chương trình YOLO hoàn chỉnh sẽ hiển thị các bounding box lên hình ảnh hoặc video để dễ quan sát:</p><ul><li><strong>Bounding box</strong> được vẽ dưới dạng hình chữ nhật bao quanh đối tượng.</li><li><strong>Nhãn lớp và độ tin cậy</strong> được hiển thị phía trên bounding box.</li></ul>', N'/files/logo.jpg', NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogComment] ON 

INSERT [dbo].[BlogComment] ([BlogCommentID], [BlogID], [AccountID], [IsActive], [Detail], [CreatedDate]) VALUES (1, 8, 5, 1, N'xin chào', CAST(N'2024-11-08T02:48:45.817' AS DateTime))
INSERT [dbo].[BlogComment] ([BlogCommentID], [BlogID], [AccountID], [IsActive], [Detail], [CreatedDate]) VALUES (4, 8, 5, 1, N'Chức năng chia sẻ tài liệu thật tuyệt vời! Tôi có thể gửi tài liệu cho đồng nghiệp một cách dễ dàng mà không lo lắng về an toàn dữ liệu. Trang web rất hữu ích cho công việc nhóm', CAST(N'2024-11-08T03:10:55.307' AS DateTime))
INSERT [dbo].[BlogComment] ([BlogCommentID], [BlogID], [AccountID], [IsActive], [Detail], [CreatedDate]) VALUES (5, 8, 2, 1, N'Tôi rất hài lòng với tính năng lưu trữ đám mây của trang web. Việc lưu tài liệu trở nên dễ dàng, không lo bị mất. Đội ngũ hỗ trợ cũng rất nhiệt tình và chuyên nghiệp.', CAST(N'2024-11-08T03:11:53.880' AS DateTime))
INSERT [dbo].[BlogComment] ([BlogCommentID], [BlogID], [AccountID], [IsActive], [Detail], [CreatedDate]) VALUES (6, 8, 5, 1, N'Tôi thích giao diện gọn gàng và cách trang web tối ưu hóa trải nghiệm người dùng. Từ khi sử dụng, công việc của tôi trở nên dễ quản lý và hiệu quả hơn nhiều. Chân thành cảm ơn!', CAST(N'2024-11-08T03:26:15.343' AS DateTime))
INSERT [dbo].[BlogComment] ([BlogCommentID], [BlogID], [AccountID], [IsActive], [Detail], [CreatedDate]) VALUES (7, 8, 2, 1, N'Tôi thích giao diện gọn gàng và cách trang web tối ưu hóa trải nghiệm người dùng. Từ khi sử dụng, công việc của tôi trở nên dễ quản lý và hiệu quả hơn nhiều. Chân thành cảm ơn!', CAST(N'2024-11-08T03:27:46.573' AS DateTime))
SET IDENTITY_INSERT [dbo].[BlogComment] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (10, N'Hoàng Văn Nam', N'2100923   ', N'Vannam238@gmail.com', N'Khả năng quản lý các phiên bản tài liệu thật sự hữu ích, tránh được việc lưu trữ tài liệu trùng lặp. Cảm ơn trang web đã giúp công việc của tôi thuận lợi hơn rất nhiều!')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (11, N'Nguyễn Thị Hiền', N'2100992   ', N'hien12@gmail.com', N'Tôi đã thử nhiều trang web quản lý tài liệu nhưng đây là trang tốt nhất. Tính năng đa dạng, dễ sử dụng, và bảo mật cao. Chắc chắn sẽ giới thiệu cho đồng nghiệp và bạn bè!')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (12, N'Trần Hà My', N'2100348   ', N'hamydsd@gmail.com', N'Tính năng ')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (13, N'Nguyễn Đình Duy', N'2100341   ', N'duy6ye6y@gmail.com', N'Tôi đã thử nhiều trang web quản lý tài liệu nhưng đây là trang tốt nhất. Tính năng đa dạng, dễ sử dụng, và bảo mật cao. Chắc chắn sẽ giới thiệu cho đồng nghiệp và bạn bè!')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (15, N'Trần Đình Phong', N'2100233   ', N'phongdhfhd@gmail.com', N'Khả năng quản lý các phiên bản tài liệu thật sự hữu ích, tránh được việc lưu trữ tài liệu trùng lặp. Cảm ơn trang web đã giúp công việc của tôi thuận lợi hơn rất nhiều!')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (16, N'Trần Đình Hòa', N'2100215   ', N'hoadndhens@gmail.com', N'Chức năng chia sẻ tài liệu thật tuyệt vời! Tôi có thể gửi tài liệu cho đồng nghiệp một cách dễ dàng mà không lo lắng về an toàn dữ liệu. Trang web rất hữu ích cho công việc nhóm')
INSERT [dbo].[Contact] ([ContactID], [Name], [Class], [Email], [Message]) VALUES (17, N'Trần Hà Nam', N'2100398   ', N'nam2312@gmail.com', N'Tôi đánh giá cao khả năng bảo mật và lưu trữ của trang web. Tài liệu của tôi luôn an toàn và dễ dàng truy cập bất kỳ khi nào cần thiết. Đây là một nền tảng quản lý tài liệu rất đáng tin cậy!')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (1, N'Trang chủ', 1, NULL, NULL, 1, 0, N'Home/Index', 1, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (3, N'Khóa học', 1, NULL, NULL, 1, 0, NULL, 3, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (4, N'Quản lý tài liệu', 1, NULL, NULL, 1, 0, NULL, 5, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (5, N'Giới thiệu', 1, NULL, NULL, 2, 6, NULL, 1, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (6, N'Hỗ trợ và liên hệ', 1, NULL, NULL, 1, 0, NULL, 6, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (8, N'Bài Viết', 1, NULL, NULL, 1, 0, N'Blog/Index', 4, 1)
INSERT [dbo].[Menu] ([MenuID], [MenuName], [IsActive], [ControllerName], [ActionName], [Levels], [ParentID], [Link], [MenuOrder], [Position]) VALUES (12, N'Liên hệ', 1, NULL, NULL, 2, 6, N'Contact/Index', 2, 1)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
