using Microsoft.AspNetCore.Mvc;
using Store.API.Models.InputModels;
using Store.API.Models.OutputModels;
using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    public interface IProductController
    {
        ValueTask<ActionResult<Order>> DeleteProduct(int productId);
        ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId);
        ValueTask<ActionResult<ProductOutputModel>> InsertOrUpdateProduct(ProductInputModel productInputModel);
    }
}