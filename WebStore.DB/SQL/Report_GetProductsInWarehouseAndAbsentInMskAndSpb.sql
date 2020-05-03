drop proc if exists [dbo].[Report_GetProductsInWarehouseAndAbsentInMskAndSpb]	
go

create proc [dbo].[Report_GetProductsInWarehouseAndAbsentInMskAndSpb]	
AS 
--какие товары есть на Складе, но при этом отсутствуют в СПб и Москве
BEGIN 
SELECT
	Manufacturer,
	Model,
	Price,
	city.id,
	city.[Name],
	st.Id,
	st.[Address]
  FROM dbo.Store_Product
  inner join dbo.Product on ProductId = Product.Id
  inner join dbo.Store as st on StoreId = st.Id
  inner join dbo.CityDictionary as city on city.Id = st.CityId
  where st.Id = 5 and ProductId
  not in (
	SELECT
	Store_Product.ProductId
	FROM dbo.Store_Product
	where Store_Product.StoreId in (1, 2))
end