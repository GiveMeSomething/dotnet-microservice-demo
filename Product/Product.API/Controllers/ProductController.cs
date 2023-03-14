using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessObjects;
using Product.API.Infra.Repositories;

namespace Product.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult<BusinessObjects.Models.Product> CreateNewProduct
        (BusinessObjects.Models.Product product)
        {
            return _productRepository.CreateNewProduct(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _productRepository.DeleteProduct(id);
            if(!deleted)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

