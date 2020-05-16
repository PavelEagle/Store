drop proc if exists [dbo].[Order_GetById]	
go

create proc [dbo].[Order_GetById]	
	@OrderId int
as
begin
	 SELECT
		po.OrderId,
		o.OrderAddress,
		o.[Date],
		city.Id,
		city.[Name],
		st.id as Id,
		st.Address,
		prod.Id,
		po.Quantity, 
		Sum(Price*Quantity) as Total,
		prod.Manufacturer, 
		prod.Model, 
		prod.Price
  FROM dbo.Product prod 
  inner join dbo.Product_Order po on po.ProductId = prod.Id 
  inner join dbo.[Order] o on o.Id=po.OrderId
  inner join dbo.Store st on o.StoreId = st.Id 
  inner join dbo.CityDictionary city on st.CityId = city.Id 
  WHERE o.Id = @OrderId
  GROUP BY o.[Date], city.Id, city.[Name], st.id, st.Address,prod.Id, prod.Manufacturer, prod.Model, prod.Price, o.Id , po.OrderId, o.OrderAddress, Quantity
  ORDER BY po.OrderId, o.[Date], city.Name 
end