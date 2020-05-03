using Microsoft.AspNetCore.Mvc;
using WebStore.API.Models.InputModels;
using WebStore.API.Models.OutputModels;
using System.Threading.Tasks;

namespace WebStore.API.Controllers
{
    public interface IProductController
    {
        ValueTask<ActionResult<string>> DeleteProduct(int productId);
        ValueTask<ActionResult<ProductOutputModel>> GetProductById(int productId);
        ValueTask<ActionResult<ProductOutputModel>> InsertOrUpdateProduct(ProductInputModel productInputModel);
    }
}