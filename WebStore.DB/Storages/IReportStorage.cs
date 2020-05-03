﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.DB.Models;
using WebStore.DB.Models.Reports;

namespace WebStore.DB.Storages
{
    public interface IReportStorage
    {
        ValueTask<List<ProductInStore>> GetBestSellingProducts();
        ValueTask<List<Category>> GetCategoryWithFiveAndMoreProducts();
        ValueTask<List<OrderInfo>> GetInfoAboutOrdersByDate(string startDate, string endDate);
        ValueTask<List<City>> GetMoneyInEachCity();
        ValueTask<List<Product>> GetNoOrderedProducts();
        ValueTask<List<ProductInStore>> GetProductsInWarehouseAndAbsentInMskAndSpb();
        ValueTask<List<Product>> GetSoldOutProduct();
        ValueTask<SalesByWorldAndRF> GetSalesByWorldAndRF();
    }
}