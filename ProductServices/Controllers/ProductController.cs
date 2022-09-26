using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Commands;
using ProductServices.DataLayer;
using ProductServices.Models;
using ProductServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EcomProducts>> GetAllProducts()
        {
            return await mediator.Send(new GetAllProductsQuery());
        }


        [HttpGet]
        public async Task<EcomProducts> GetProductbyId(int productId)
        {
            return await mediator.Send(new GetProductByIdQuery { productId=productId});
        }

        [HttpPost]
        public async Task<EcomProducts> AddProduct(int categoryId,string productName, string productType,decimal productPrice, string productDescription)
        {
            return await mediator.Send(new AddProductCommand {categoryId=categoryId, productName=productName,productType=productType,productPrice=productPrice,productDescription=productDescription });
        }


    }
}
