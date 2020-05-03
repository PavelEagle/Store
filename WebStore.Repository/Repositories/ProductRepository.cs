﻿using WebStore.DB.Models;
using WebStore.DB.Storages;
using System;
using System.Threading.Tasks;

namespace WebStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductStorage _productStorage;

        public ProductRepository(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public async ValueTask<RequestResult<Product>> ProductGetById(int productId)
        {
            var result = new RequestResult<Product>();
            try
            {
                result.RequestData = await _productStorage.ProductGetById(productId);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<string>> ProductDelete(int id)
        {
            var result = new RequestResult<string>();
            try
            {
                await _productStorage.ProductDeleteById(id);
                result.RequestData = $"Model with id {id} was deleted";
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<Product>> ProductInsertOrUpdate(Product dataModel)
        {
            var result = new RequestResult<Product>();
            try
            {
                //_productStorage.TransactionStart();
                result.RequestData = await _productStorage.ProductInsertOrUpdate(dataModel);
                //_productStorage.TransactionCommit();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                //_productStorage.TransactioRollBack();
                result.ExMessage = ex.Message;
            }
            return result;
        }

    }
}
