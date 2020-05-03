drop proc if exists [dbo].[Product_InsertOrUpdate]
go

create proc [dbo].[Product_InsertOrUpdate]
	@id bigint,
	@Manufacturer nvarchar(50),
	@Model nvarchar(50),
	@Price int,
	@SubcategoryId int

as
begin
merge 
	dbo.Product as prod
using 
	(values (@Id)) n(Id) on prod.Id = n.Id
when matched then 
	update set Manufacturer = @Manufacturer,
				Model = @Model,
				Price = @Price,
				SubcategoryId = @SubcategoryId
when not matched then 
	insert (Manufacturer, Model, Price, SubcategoryId)
	values (@Manufacturer, @Model, @Price, @SubcategoryId);
	select scope_identity();
end