using System;
namespace Product.API.Infra.Repositories
{
	public interface IProductRepository
	{
		public BusinessObjects.Models.Product CreateNewProduct
			(BusinessObjects.Models.Product product);

		public bool DeleteProduct(int id);

		public BusinessObjects.Models.Product GetProductById(int id);

		public List<BusinessObjects.Models.Product> GetProducts(string ids);
	}
}

