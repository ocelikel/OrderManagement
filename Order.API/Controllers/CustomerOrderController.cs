using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.API.Model;
using Order.API.Repository;
using Order.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper _mapper;
        public CustomerOrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this._mapper = mapper;
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Get()
        {

            var listOrder = await orderRepository.GetAll();

            return Ok(listOrder);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> Create([FromBody] OrderViewModel viewModel)
        {
            Model.Order order = _mapper.Map<Model.Order>(viewModel);

            await orderRepository.CreateOrder(order);

            return Ok();
        }

        [HttpDelete("orders/{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var order = await orderRepository.GetOrderById(orderId);
            await orderRepository.Delete(order);

            return Ok();
        }
        
        [HttpPut("orders")]
        public async Task<IActionResult> Update([FromBody] Model.Order order)
        {

            await orderRepository.UpdateOrder(order);

            return Ok();
        }
    }
}
