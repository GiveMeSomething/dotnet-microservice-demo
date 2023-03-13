using System;
using Grpc.Core;

namespace Cart.API.Services
{
    public class CartService : CartRPC.CartRPCBase
    {
        public override Task<CustomerCartResponse> GetCartById(
            CartRequest request,
            ServerCallContext context)
        {
            return base.GetCartById(request, context);
        }

        public override Task<CustomerCartResponse> UpdateCart(
            CustomerCartRequest request,
            ServerCallContext context)
        {
            return base.UpdateCart(request, context);
        }
    }
}

