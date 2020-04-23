using Store.API.Models.OutputModels;
using Store.DB.Models;
using System.Collections.Generic;


namespace Store.API.Models.Mapping
{
    public class ProductMapper
    {
		public static List<ProductOutputModel> toOutputModels(List<Product> products)
		{
			List<ProductOutputModel> result = new List<ProductOutputModel>();
			foreach (Product product in products)
			{
				result.Add(ToOutputModel(product));
			}
			return result;
		}

		public static ProductOutputModel ToOutputModel(Product product)
		{
			return new ProductOutputModel
			{
				Id = product.Id,
				Manufacturer = product.Manufacturer,
				Model = product.Model,
				Price = product.Price,
				CategoryName = product.Subcategory.Category.Name,
				Subcategory =  product.Subcategory.Name
			};
		}

	}
}
