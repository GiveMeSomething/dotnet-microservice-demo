using System;
namespace Cart.API.Infra.Repositories
{
	public interface ICartRepository
	{
		public BusinessObjects.Models.Cart GetCartById(int id);

		public bool UpdateCart(int id, List<BusinessObjects.Models.Product> products);
	}
}

