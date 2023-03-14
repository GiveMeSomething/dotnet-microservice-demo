using System;
using Grpc.Core;
using Product.API.Infra.Repositories;

namespace Product.API.Services
{
	public class ProductService: ProductRPC.ProductRPCBase
	{
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override Task<ProductResponse> GetItemById(
            ProductRequest request,
            ServerCallContext context)
        {
            return Task.FromResult(
                MapToProductResponse(_productRepository.GetProductById(request.Id))
            );
        }

        public override Task<ProductsResponse> GetItemByIds(ProductsRequest request, ServerCallContext context)
        {
            var products = _productRepository.GetProducts(request.Ids);

            var result = new ProductsResponse
            {
                Count = products.Count
            };
            result.Data.AddRange(products.Select(p => MapToProductResponse(p)).ToList());
            return Task.FromResult(result);
        }

        private static ProductResponse MapToProductResponse
            (BusinessObjects.Models.Product product)
        {
            return new ProductResponse
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity
            };
        }
    }
}

