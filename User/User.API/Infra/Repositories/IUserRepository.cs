using System;
using BusinessObjects.Models;

namespace User.API.Infra.Repositories
{
	public interface IUserRepository
	{
		public Customer CreateNewUser(Customer customer);

		public Customer GetCustomerById(int id);
	}
}

