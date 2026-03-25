using MediatR;
using ProductService.Application.Common.Models;
using ProductService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ApiResponse<ProductDto>>
    {
        public Guid Id { get; set; } 
    }
}
