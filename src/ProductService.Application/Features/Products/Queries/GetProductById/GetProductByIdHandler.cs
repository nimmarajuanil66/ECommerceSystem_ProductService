using MediatR;
using ProductService.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler:IRequestHandler<GetProductByIdQuery,ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery reqest,CancellationToken token)
        {
            var product = await _productRepository.GetByIdAsync(reqest.Id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }
    }
}
