using MediatR;
using ProductService.Application.Common.Models;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.Repositories;

namespace ProductService.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<ProductDto>> Handle(GetProductByIdQuery reqest, CancellationToken token)
        {
            var product = await _productRepository.GetByIdAsync(reqest.Id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            var dto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
            return ApiResponse<ProductDto>.SuccessResponse(dto);
        }
    }
}
