drop proc if exists [dbo].[Report_GetNoOrderedProducts]	
go

create proc [dbo].[Report_GetNoOrderedProducts]	
AS 
 
--Товары, которые никто ни разу не заказывал

BEGIN  
  SELECT Manufacturer, Model, Price
  FROM dbo.Product as p
  left join dbo.Product_Order as po on po.ProductId = p.Id 
  WHERE po.ProductId IS NULL
end