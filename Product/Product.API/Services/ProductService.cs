using System;
using Grpc.Core;

namespace Product.API.Services
{
	public class ProductService: ProductRPC.ProductRPCBase
	{
        public override Task<ProductResponse> GetItemById(
            ProductRequest request,
            ServerCallContext context)
        {
            return base.GetItemById(request, context);
        }

        public override Task<PaginatedProductsResponse> GetItemByIds(
            ProductsRequest request,
            ServerCallContext context)
        {
            return base.GetItemByIds(request, context);
        }
    }
}

