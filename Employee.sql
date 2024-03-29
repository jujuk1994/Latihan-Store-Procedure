USE [master]
GO
/****** Object:  Database [Employes]    Script Date: 09-Oct-19 10:49:24 ******/
CREATE DATABASE [Employes]
 
CREATE TABLE [dbo].[Tbl_Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Adrress] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Pin_code] [bigint] NULL,
	[Designation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[Sp_Add_Employee]    Script Date: 09-Oct-19 10:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Add_Employee]
@Name varchar(max),
@Adrress varchar(max),
@City varchar(max),
@Pin_Code bigint,
@Designation varchar(max)
as
begin
insert into Tbl_Employee values(
@Name,
@Adrress,
@City,
@Pin_Code,
@Designation
)
end

GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Employee]    Script Date: 09-Oct-19 10:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Delete_Employee]
@Id int
as
begin
delete from Tbl_Employee where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Select_Employee]    Script Date: 09-Oct-19 10:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Select_Employee]
@Id int
as
begin
select * from Tbl_Employee where Id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_SelectAll_Employee]    Script Date: 09-Oct-19 10:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_SelectAll_Employee]
as
begin
select * from Tbl_Employee
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Employee]    Script Date: 09-Oct-19 10:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Update_Employee]
@Id int,
@Name nvarchar(max),
@Adrress nvarchar(max),
@City nvarchar(max),
@Pin_Code bigint,
@Designation nvarchar(max)
as
begin
update Tbl_Employee set
Name = @Name,
Adrress = @Adrress, 
City = @City,
Pin_Code = @Pin_Code,
Designation = @Designation
where Id = @Id
end

GO
USE [master]
GO
ALTER DATABASE [Employes] SET  READ_WRITE 
GO
