using MediatR;
using ProductService.Application.Common.Models;
using ProductService.Application.Features.Products.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery :IRequest<ApiResponse<PagedResult<ProductDto>>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
