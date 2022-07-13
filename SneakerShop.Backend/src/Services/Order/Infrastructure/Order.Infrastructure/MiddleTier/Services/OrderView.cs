using Microsoft.EntityFrameworkCore;
using Order.Application.Dto;
using Order.Application.MiddleTier.Contracts;
using Order.Infrastructure.Dal;
using System.Threading.Tasks;

namespace Order.Infrastructure.MiddleTier.Services
{
    public class OrderView : IOrderView
    {
        private readonly OrderContext _context;

        public OrderView(OrderContext context)
        {
            _context = context;
        }

        public async Task<DataServiceMessage> GetOrderByLoginAsync(string login)
        {
            var existingLogin = await _context.AppOrder.FirstOrDefaultAsync(x => x.Login == login);
            var result = new DataServiceMessage(true, existingLogin);
            return result;
        }
    }
}
