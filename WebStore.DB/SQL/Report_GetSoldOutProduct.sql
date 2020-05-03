drop proc if exists [dbo].[Report_GetSoldOutProduct]
go

create proc [dbo].[Report_GetSoldOutProduct]
AS 

--товары, по которым были продажи, но которых нет ни в представительствах, ни на Складе
BEGIN 
SELECT 
   Manufacturer,
   Model,
   Price
  FROM dbo.Product as prod
  inner join dbo.Product_Order as po on po.ProductId = prod.Id
  left join dbo.Store_Product as sp on prod.Id = sp.ProductId
  where sp.ProductId IS NULL
end