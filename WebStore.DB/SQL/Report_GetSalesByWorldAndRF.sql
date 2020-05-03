drop proc if exists [dbo].[Report_GetSalesByWorldAndRF]	
go

create proc [dbo].[Report_GetSalesByWorldAndRF]	
AS 
 
-- Узнать сумму заказов внутри РФ и за рубежом (должна вывестись одна строка с двумя столбцами: Продажи в РФ, Продажи за рубежом)
BEGIN  
select [1] AS SalesInRF, [0] AS SalesInTheWorld
	from (select sum(summ) as total, v.Ru from V_City_SumSales as v
	group by v.Ru) as sm
	pivot 
	(
	Sum(total) for sm.Ru in ([0],[1])
	) as pvt
end