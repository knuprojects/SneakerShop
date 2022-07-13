using Microsoft.EntityFrameworkCore;
using Order.Application.Dto;
using Order.Application.MiddleTier.Contracts;
using Order.Domain.Entities;
using Order.Infrastructure.Dal;
using Order.Infrastructure.Exceptions;
using System.Threading.Tasks;

namespace Order.Infrastructure.MiddleTier.Services
{
    public class OrderProccesing : IOrderProccesing
    {
        private readonly OrderContext _context;

        public OrderProccesing(OrderContext context)
        {
            _context = context;
        }

        public async Task<DataServiceMessage> DeleteOrderAsync(int orderId)
        {
            var existingOrder = await _context.AppOrder.FirstOrDefaultAsync(x => x.OrderId == orderId);

            if (existingOrder == null)
                throw new InvalidOrderIdException(orderId);

            _context.AppOrder.Remove(existingOrder);
            await _context.SaveChangesAsync();

            var result = new DataServiceMessage(true, orderId);

            return result;
        }

        public async Task<DataServiceMessage> UpdateOrderAsync(OrderDto dto)
        {
            var existingOrder = await _context.AppOrder.FirstOrDefaultAsync(x => x.OrderId == dto.OrderId);

            if (existingOrder == null)
                throw new InvalidOrderIdException(dto.OrderId);

            var newOrder = new AppOrder
            {
                OrderId = dto.OrderId,
                Login = dto.Login,
                TotalPrice = dto.TotalPrice,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                AddressLine = dto.AddressLine,
                Country = dto.Country,
                State = dto.State,
                ZipCode = dto.ZipCode,
                CardName = dto.CardName,
                CardNumber = dto.CardNumber,
                Expiration = dto.Expiration,
                CVV = dto.CVV,
                PaymentMethod = dto.PaymentMethod
            };

            _context.AppOrder.Update(newOrder);
            await _context.SaveChangesAsync();

            var result = new DataServiceMessage(true, newOrder.OrderId);

            return result;
        }
    }
}
