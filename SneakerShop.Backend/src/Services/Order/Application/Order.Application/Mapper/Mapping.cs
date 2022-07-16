using Order.Application.Commands.UpdateOrder;
using Order.Application.Dto;

namespace Order.Application.Mapper
{
    public static class Mapping
    {
        public static OrderDto UpdateCommandToOrder(this UpdateOrderCommand dto)
        {
            return new OrderDto
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
        }
    }
}
