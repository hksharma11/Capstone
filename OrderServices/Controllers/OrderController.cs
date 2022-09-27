using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServices.Commands;
using OrderServices.Models;
using OrderServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EcomOrders>> GetAllOrders()
        {
            return await mediator.Send(new GetAllOrdersQuery());
        }

        [HttpGet]
        public async Task<EcomOrders> GetOrderById(int orderId)
        {
            return await mediator.Send(new GetOrderByIdQuery {orderId=orderId });
        }

        [HttpPost]
        public async Task<EcomOrders> AddOrder(int productId, int customerId, int quantity, decimal price, string shippment_address)
        {
            return await mediator.Send(new AddOrderCommand { productId=productId, customerId=customerId,quantity=quantity,price=price,shippmentAddress=shippment_address });
        }
    }
}
