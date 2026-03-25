using MediatR;
using ProductService.Application.Interfaces.Repositories;
using ProductService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand,Guid>
    {
        private IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand reqst,CancellationToken cancellationToken)
        {
            var product = new Product(reqst.Name, reqst.Price);

            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
