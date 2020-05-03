drop proc if exists [dbo].[Product_DeleteById]
go

create proc [dbo].[Product_DeleteById]
	@Id bigint
as
begin 
delete from dbo.Product
	where Id=@Id
end