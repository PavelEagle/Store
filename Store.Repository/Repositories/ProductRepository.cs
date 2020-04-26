using Store.DB.Models;
using Store.DB.Storages;
using System;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductStorage _productStorage;

        public ProductRepository(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public async ValueTask<RequestResult<Product>> GetProductById(int productId)
        {
            var result = new RequestResult<Product>();
            try
            {
                result.RequestData = await _productStorage.GetProductById(productId);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
