using System;
using BusinessObjects.Models;

namespace Cart.API.Infra.Repositories
{
	public class CartRepository: ICartRepository
	{
        private readonly EShopContext _context;

		public CartRepository(EShopContext context)
		{
            _context = context;
		}

        public bool UpdateCart(int id, List<Product> products)
        {
            throw new NotImplementedException();
        }

        BusinessObjects.Models.Cart ICartRepository.GetCartById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

