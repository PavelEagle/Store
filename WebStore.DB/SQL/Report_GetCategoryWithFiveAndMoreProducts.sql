drop proc if exists [dbo].[Report_GetCategoryWithFiveAndMoreProducts]
go

create proc [dbo].[Report_GetCategoryWithFiveAndMoreProducts]
as
begin
	select	
	c.Name,
	COUNT(*) as CountProduct
  FROM dbo.CategoryDictionary as c
  inner join dbo.Subcategory subcat on c.Id = subcat.CategoryId
  inner join dbo.Product on subcat.Id = Product.SubcategoryId
  group by c.Name
  having COUNT(*) >= 5
end