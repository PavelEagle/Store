drop proc if exists [dbo].[Report_GetMoneyInEachCity]	
go

create proc [dbo].[Report_GetMoneyInEachCity]	
AS 
 
-- Сколько у тебя гипотетических денег в каждом городе, а также на складе
BEGIN  
select city.Name,
	   Sum(Quantity*Price) as TotalMoney
from dbo.Store_Product sp
inner join dbo.Store as st on sp.StoreId = st.Id
inner join dbo.CityDictionary as city on st.CityId = city.Id
inner join dbo.Product prod on sp.ProductId = prod.Id
group by city.Name
end