drop proc if exists [dbo].[Report_GetInfoAboutOrdersByDate]	
go

create proc [dbo].[Report_GetInfoAboutOrdersByDate]	
@startDate Date, @endDate Date
AS 
 
-- Информацию о продажах за определённый период времени: 
-- в таком-то городе было куплено столько то единиц такого-то товара за такую-то сумму

BEGIN  
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
  WHERE o.Date > @startDate AND o.Date < @endDate
  GROUP BY o.[Date], city.Id, city.[Name], st.id, st.Address,prod.Id, prod.Manufacturer, prod.Model, prod.Price, o.Id , po.OrderId, o.OrderAddress, Quantity
  ORDER BY po.OrderId, o.[Date], city.Name 
end