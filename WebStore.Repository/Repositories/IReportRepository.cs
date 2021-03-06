﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Core;
using WebStore.DB.Models;

namespace WebStore.Repository.Repositories
{
    public interface IReportRepository
    {
        ValueTask<RequestResult<List<ProductInStore>>> GetBestSellingProducts();
        ValueTask<RequestResult<List<Category>>> GetCategoryWithFiveAndMoreProducts();
        ValueTask<RequestResult<List<OrderInfo>>> GetInfoAboutOrdersByDate(DateModel dateModel);
        ValueTask<RequestResult<List<City>>> GetMoneyInEachCity();
        ValueTask<RequestResult<List<Product>>> GetNoOrderedProducts();
        ValueTask<RequestResult<List<ProductInStore>>> GetProductsInWarehouseAndAbsentInMskAndSpb();
        ValueTask<RequestResult<List<Product>>> GetSoldOutProduct();
        ValueTask<RequestResult<SalesByWorldAndRF>> GetSalesByWorldAndRF();
    }
}