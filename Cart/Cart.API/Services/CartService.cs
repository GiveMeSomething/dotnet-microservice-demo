using System;
using Cart.API.Infra.Repositories;
using Grpc.Core;

namespace Cart.API.Services
{
    public class CartService : CartRPC.CartRPCBase
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public override Task<CustomerCartResponse> GetCartById(
            CartRequest request,
            ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override Task<CustomerCartResponse> UpdateCart(
            CustomerCartRequest request,
            ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}

