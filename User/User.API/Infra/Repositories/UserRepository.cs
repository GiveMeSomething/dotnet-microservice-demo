using System;
using BusinessObjects.Models;

namespace User.API.Infra.Repositories
{
	public class UserRepository: IUserRepository
	{
		private readonly EShopContext _context;

		public UserRepository(EShopContext context)
		{
			_context = context;
		}

		public Customer CreateNewUser(Customer customerInfo)
		{
			var newCustomer = _context.Customers.Add(customerInfo);
			_context.SaveChanges();
			return newCustomer.Entity;
		}

		public Customer GetCustomerById(int id)
		{
			var foundCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if(foundCustomer == null)
			{
				throw new Exception("Customer with id {id} is non-existent");
			}

			return foundCustomer;
		}
    }
}

