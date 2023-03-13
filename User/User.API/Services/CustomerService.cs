using System;
using Grpc.Core;
using BusinessObjects.Models;
using User.API.Infra.Repositories;

namespace User.API.Services
{
    public class CustomerService : CustomerRPC.CustomerRPCBase
    {
        private readonly IUserRepository _userRepository;

        public CustomerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override Task<CustomerResponse> CreateCustomer(
            NewCustomerRequest request,
            ServerCallContext context)
        {
            var newCustomer = MapFromCustomerRequest(request);
            newCustomer = _userRepository.CreateNewUser(newCustomer);
            return Task.FromResult(MapToCustomerResponse(newCustomer));
        }

        public override Task<CustomerResponse> GetCustomerById(
            CustomerRequest request,
            ServerCallContext context)
        {
            return Task.FromResult(
                MapToCustomerResponse(
                    _userRepository.GetCustomerById(request.Id)
                )
            );
        }

        private static CustomerResponse MapToCustomerResponse(Customer customer)
        {
            return new CustomerResponse
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                Address = customer.Address
            };
        }

        private static Customer MapFromCustomerRequest(NewCustomerRequest request)
        {
            return new Customer
            {
                CustomerName = request.CustomerName,
                Address = request.Address
            };
        }
    }
}

