drop proc if exists [dbo].[Report_GetBestSellingProducts]
go

create proc [dbo].[Report_GetBestSellingProducts]
AS 

--узнать самый часто продаваемый товар в каждом городе

BEGIN 
SELECT city.Name, 
	   city.Id,	
	   st.[Address], 
	   st.Id,
	   prod.Model, 
	   prod.Manufacturer, 
	   prod.Price
FROM dbo.Store as st
inner join dbo.CityDictionary as city on city.Id = st.CityId 
outer apply (SELECT top 1 Product.Id, Manufacturer, Model, Price FROM dbo.Product
    inner join dbo.Product_Order as po on po.ProductId = Product.Id
    inner join dbo.[Order] as ord on ord.Id = po.OrderId 
    where ord.StoreId = st.Id
    group by Product.Id, Manufacturer, Model, Price
    order by SUM(Quantity) desc
    ) prod
end