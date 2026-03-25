using MediatR;
using ProductService.Application.Common.Models;
using ProductService.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler:IRequestHandler<UpdateProductCommand,ApiResponse<bool>>
    {
        private readonly IProductRepository _repository;
        public UpdateProductHandler(IProductRepository repository)
        {
             _repository = repository;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateProductCommand request,CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Product not found");
            product.Update(request.Name, request.Price);


            await _repository.UpdateAsync(product);

            return ApiResponse<bool>.SuccessResponse(true);
        }
    }
}
