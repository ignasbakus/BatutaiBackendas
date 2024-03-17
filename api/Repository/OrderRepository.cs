using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApllicationDBContext _context;
        public OrderRepository(ApllicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> DeleteAsync(int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orderModel == null)
            {
                return null;
            }

            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order?> UpdateAsync(int id, Order orderModel)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            
            if(existingOrder == null)
            {
                return null;
            }

            existingOrder.CustomerName = orderModel.CustomerName;
            existingOrder.CustomerSurname = orderModel.CustomerSurname;
            existingOrder.PhoneNumber = orderModel.PhoneNumber;
            existingOrder.Email = orderModel.Email;
            existingOrder.Adress = orderModel.Adress;
            existingOrder.City = orderModel.City;
            existingOrder.ReservationTime = orderModel.ReservationTime;

            await _context.SaveChangesAsync();

            return existingOrder;
        }
    }
}