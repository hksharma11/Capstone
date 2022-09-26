using CategoryServices.Command;
using CategoryServices.DataLayer;
using CategoryServices.Models;
using CategoryServices.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EcomCategory>> GetAllCategory()
        {
            return await mediator.Send(new GetAllCategoryQuery());
        }


        [HttpGet]
        public async Task<EcomCategory> GetCategoryById(int categoryId)
        {
            return await mediator.Send(new GetCategoryByIdQuery() {categoryId=categoryId });
        }

        [HttpPost]
        public async Task<EcomCategory> AddCategory(string category)
        {
            return await mediator.Send(new AddCategoryCommand { categoryName=category });
        }

    }
}
