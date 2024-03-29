USE [libruary]
GO
/****** 对象:  Table [dbo].[bookstable]    脚本日期: 04/21/2008 13:21:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bookstable](
	[idBook] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[numCopies] [smallint] NOT NULL CONSTRAINT [DF_bookstable_numCopies]  DEFAULT ((0)),
	[abstract] [varchar](150) NOT NULL,
	[author] [varchar](20) NOT NULL,
	[publishCompany] [varchar](40) NOT NULL,
	[comment] [varchar](100) NOT NULL,
	[donatePerson] [varchar](50) NOT NULL,
	[state] [nchar](9) NOT NULL CONSTRAINT [DF_bookstable_state]  DEFAULT (N'FREE'),
	[bookName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_bookstable] PRIMARY KEY CLUSTERED 
(
	[idBook] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  Table [dbo].[userinformation]    脚本日期: 04/21/2008 13:21:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userinformation](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[trueName] [varchar](10) NOT NULL,
	[college] [varchar](20) NOT NULL,
	[address] [varchar](60) NOT NULL,
	[birthday] [datetime] NOT NULL,
	[sex] [nchar](6) NOT NULL CONSTRAINT [DF_userinformation_sex]  DEFAULT (N'MALE'),
	[email] [varchar](40) NOT NULL,
	[telnumber] [varchar](15) NOT NULL,
	[description] [varchar](300) NOT NULL,
	[mark] [int] NOT NULL,
 CONSTRAINT [PK_userinformation] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  Table [dbo].[admininformation]    脚本日期: 04/21/2008 13:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admininformation](
	[idAdmin] [int] NOT NULL,
 CONSTRAINT [PK_admininformation] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[board]    脚本日期: 04/21/2008 13:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[board](
	[context] [varchar](200) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  Table [dbo].[borrowtable]    脚本日期: 04/21/2008 13:21:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[borrowtable](
	[idBook] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[deadLine] [datetime] NOT NULL,
 CONSTRAINT [PK_borrowtable] PRIMARY KEY CLUSTERED 
(
	[idBook] ASC,
	[idUser] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[bookcomment]    脚本日期: 04/21/2008 13:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bookcomment](
	[idBook] [int] NOT NULL,
	[idUser] [int] NOT NULL,
	[comment] [varchar](200) NOT NULL,
	[commentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_bookcomment] PRIMARY KEY CLUSTERED 
(
	[idBook] ASC,
	[idUser] ASC,
	[commentDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  Table [dbo].[toadmincomment]    脚本日期: 04/21/2008 13:21:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[toadmincomment](
	[idUser] [int] NOT NULL,
	[idAdmin] [int] NOT NULL,
	[comment] [varchar](200) NOT NULL,
	[commentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_toadmincomment] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC,
	[idAdmin] ASC,
	[commentDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** 对象:  ForeignKey [FK_bookcomment_bookstable]    脚本日期: 04/21/2008 13:21:15 ******/
ALTER TABLE [dbo].[bookcomment]  WITH CHECK ADD  CONSTRAINT [FK_bookcomment_bookstable] FOREIGN KEY([idBook])
REFERENCES [dbo].[bookstable] ([idBook])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bookcomment] CHECK CONSTRAINT [FK_bookcomment_bookstable]
GO
/****** 对象:  ForeignKey [FK_bookcomment_userinformation]    脚本日期: 04/21/2008 13:21:16 ******/
ALTER TABLE [dbo].[bookcomment]  WITH CHECK ADD  CONSTRAINT [FK_bookcomment_userinformation] FOREIGN KEY([idUser])
REFERENCES [dbo].[userinformation] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[bookcomment] CHECK CONSTRAINT [FK_bookcomment_userinformation]
GO
/****** 对象:  ForeignKey [FK_borrowtable_bookstable]    脚本日期: 04/21/2008 13:21:20 ******/
ALTER TABLE [dbo].[borrowtable]  WITH CHECK ADD  CONSTRAINT [FK_borrowtable_bookstable] FOREIGN KEY([idBook])
REFERENCES [dbo].[bookstable] ([idBook])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[borrowtable] CHECK CONSTRAINT [FK_borrowtable_bookstable]
GO
/****** 对象:  ForeignKey [FK_borrowtable_userinformation]    脚本日期: 04/21/2008 13:21:21 ******/
ALTER TABLE [dbo].[borrowtable]  WITH CHECK ADD  CONSTRAINT [FK_borrowtable_userinformation] FOREIGN KEY([idUser])
REFERENCES [dbo].[userinformation] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[borrowtable] CHECK CONSTRAINT [FK_borrowtable_userinformation]
GO
/****** 对象:  ForeignKey [FK_toadmincomment_admininformation]    脚本日期: 04/21/2008 13:21:22 ******/
ALTER TABLE [dbo].[toadmincomment]  WITH CHECK ADD  CONSTRAINT [FK_toadmincomment_admininformation] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[admininformation] ([idAdmin])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[toadmincomment] CHECK CONSTRAINT [FK_toadmincomment_admininformation]
GO
/****** 对象:  ForeignKey [FK_toadmincomment_userinformation]    脚本日期: 04/21/2008 13:21:22 ******/
ALTER TABLE [dbo].[toadmincomment]  WITH CHECK ADD  CONSTRAINT [FK_toadmincomment_userinformation] FOREIGN KEY([idUser])
REFERENCES [dbo].[userinformation] ([idUser])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[toadmincomment] CHECK CONSTRAINT [FK_toadmincomment_userinformation]
GO
