drop proc if exists dbo.City_Insert
go

create proc [dbo].[City_Insert]
	@Id int,
	@Name nvarchar(50),
	@RU bit
as
begin
	insert into dbo.CityDictionary (Id, [Name], RU)
	values (@Id, @Name, @RU)
end