using System;
using Grpc.Core;

namespace User.API.Services
{
    public class CustomerService : CustomerRPC.CustomerRPCBase
    {
        public override Task<CustomerResponse> GetCustomerById(
            CustomerRequest request,
            ServerCallContext context)
        {
            return base.GetCustomerById(request, context);
        }
    }
}

