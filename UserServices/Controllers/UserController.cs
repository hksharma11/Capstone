using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserServices.Command;
using UserServices.Models;
using UserServices.Queries;

namespace UserServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<EcomCustomers> GetCustomerById(int customerId)
        {
            return await mediator.Send(new GetCustomerByIdQuery { CustomerId=customerId});
        }

        [HttpPost]
        public async Task<EcomCustomers> AddCustomer(string customerName, string customerAddress, string customerPhone, string customerEmail,int loginId)
        {
            return await mediator.Send(new AddCustomerCommand { customerName=customerName, customerAddress = customerAddress, customerPhone=customerPhone,customerEmail=customerEmail, loginId=loginId});
        }
    }
}
