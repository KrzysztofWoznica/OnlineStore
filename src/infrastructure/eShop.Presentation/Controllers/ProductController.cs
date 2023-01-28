using eShop.Application.Interfaces;
using eShop.Application.Interfaces.common;
using eShop.Contracts.Products;
using Microsoft.AspNetCore.Mvc;


namespace eShop.Presentation.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            if (id == default)
                return BadRequest();

            var result = await _productService.GetProductAsync(id);
            return ActionResultFromServiceResponse<ProductDto>(result);
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(422, Type = typeof(IEnumerable<ServiceResponseValidationResult>))]
        public async Task<IActionResult> CreateProduct(CreateProductRequest? request)
        {
            if (request == null)
                return BadRequest();

            var result = await _productService.CreateProductAsync(request);

            return ActionResultFromServiceResponse(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id == default)
                return BadRequest();

            var result = await _productService.DeleteProductAsync(id);
            return ActionResultFromServiceResponse(result);
        }


    }
}
