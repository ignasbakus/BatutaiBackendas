using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepo.GetAllAsync();

            var orderDto = orders.Select(s => s.toOrderDto());

            return Ok(orderDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order.toOrderDto());
        }

        [HttpPost("{trampolineId}")]
        public async Task<IActionResult> Create([FromRoute] int trampolineId, CreateOrderDto orderDto)
        {
            var orderModel = orderDto.toOrderFromCreate(trampolineId);
            await _orderRepo.CreateAsync(orderModel);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequestDto updateDto)
        {
            var order = await _orderRepo.UpdateAsync(id, updateDto.toOrderFromUpdate());

            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order.toOrderDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var orderModel = await _orderRepo.DeleteAsync(id);

            if (orderModel == null)
            {
                return NotFound("Order does not exist");
            }

            return NoContent();
        }
    }
}