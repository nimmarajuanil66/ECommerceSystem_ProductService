using MediatR;
using ProductService.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
