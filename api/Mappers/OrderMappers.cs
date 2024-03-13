using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Models;

namespace api.Mappers
{
    public static class OrderMappers
    {
        public static OrderDto toOrderDto(this Order orderModel)
        {
            return new OrderDto
            {
                Id = orderModel.Id,
                CustomerName = orderModel.CustomerName,
                CustomerSurname = orderModel.CustomerSurname,
                PhoneNumber = orderModel.PhoneNumber,
                Email = orderModel.Email,
                Adress = orderModel.Adress,
                City = orderModel.City,
                ReservationTime = orderModel.ReservationTime,
                TrampolineId = orderModel.TrampolineId
            };
        }
    }
}