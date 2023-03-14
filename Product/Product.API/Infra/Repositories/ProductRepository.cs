using System;
using BusinessObjects.Models;

namespace Product.API.Infra.Repositories
{
	public class ProductRepository: IProductRepository
	{
        private readonly EShopContext _context;

		public ProductRepository(EShopContext context)
		{
            _context = context;
		}

        public BusinessObjects.Models.Product CreateNewProduct
            (BusinessObjects.Models.Product product)
        {
            var newProduct = _context.Products.Add(product);
            _context.SaveChanges();
            return newProduct.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var foundProduct = GetProductById(id);
            if(foundProduct == null)
            {
                return false;
            }

            _context.Products.Remove(foundProduct);
            _context.SaveChanges();
            return true;
        }

        public BusinessObjects.Models.Product GetProductById(int id)
        {
            var foundProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
            return foundProduct;
        }

        public List<BusinessObjects.Models.Product> GetProducts(string ids)
        {
            var numIds = ids
                .Split(',')
                .Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            if(numIds.All(nid => nid.Ok))
            {
                return new List<BusinessObjects.Models.Product>();
            }

            var validIds = numIds.Select(nid => nid.Value);
            var result = _context.Products.Where(p => validIds.Contains(p.ProductId)).ToList();

            return result;
        }
    }
}

