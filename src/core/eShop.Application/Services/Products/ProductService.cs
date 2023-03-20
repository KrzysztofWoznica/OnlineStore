using eShop.Application.Common.Paging;
using eShop.Application.Common.Validation;
using eShop.Application.Interfaces;
using eShop.Application.Interfaces.common;
using eShop.Application.Interfaces.common.Paging;
using eShop.Application.Services.Products.Repositories;
using eShop.Contracts.Products;
using eShop.Domain.Entities;



namespace eShop.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidationService _validationService;

        public ProductService(
            IProductRepository productRepository,
            IValidationService validationService)
        {
            _productRepository = productRepository;
            _validationService = validationService;
        }


        public async Task<ServiceResponse<PagedList<ProductDto>>> GetProductsAsync(FromQueryParameters? parameters)
        {
            var pagingParameters = new PagingParameters()
            {
                PageNumber = parameters?.PageNumber ?? PagingConstants.DefaultPageNumber,
                PageSize = parameters?.PageSize ?? PagingConstants.DefaultPageSize
            };

            var products = await _productRepository.GetAllPagedAsync(pagingParameters);

            var productDtos = new PagedList<ProductDto>()
            {
                PageNumber = products.PageNumber,
                PageSize = products.PageSize,
                TotalCount = products.TotalCount,
                Results = products.Results?.Select(p =>
                    new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        ImageUri = p.ImageUri
                    }) ?? new List<ProductDto>()
            };
            return new ServiceResponse<PagedList<ProductDto>>(productDtos);          
        }          

        
        public async Task<ServiceResponse<ProductDto>> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            if(product == null)
                return new ServiceResponse<ProductDto>(ServiceResponseStatus.NotFound);

            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUri = product.ImageUri
            };
            return new ServiceResponse<ProductDto>(dto);
        }


        public async Task<ServiceResponse<ProductDto>> CreateProductAsync(CreateProductRequest request)
        {
            var validationResult = await _validationService.ValidateAsync(request);
            if (!validationResult.IsValid)
                return new ServiceResponse<ProductDto>(validationResult);

            var entity = new Product()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUri = request.ImageUri,
                CategoryId = request.CategoryId
            };

            await _productRepository.CreateAndCommitAsync(entity);

            var dto = new ProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ImageUri = entity.ImageUri
            };
            return new ServiceResponse<ProductDto>(dto);
        }


        public async Task<ServiceResponse> DeleteProductAsync(Guid id) { 
            var product = await _productRepository.GetAsync(id);
            if (product == null)
                return new ServiceResponse<ProductDto>(ServiceResponseStatus.NotFound);

            await _productRepository.DeleteAndCommitAsync(product);         

            return new ServiceResponse(ServiceResponseStatus.Success);
        }            

            

    }
}
