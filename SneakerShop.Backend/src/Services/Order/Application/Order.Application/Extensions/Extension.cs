using Microsoft.Extensions.DependencyInjection;
using Order.Application.Abstraction;
using Order.Application.Commands.DeleteOrder;
using Order.Application.Commands.UpdateOrder;
using Order.Application.Dto;
using Order.Application.Queries.GetOrdersByLogin;
using Order.Application.Queries.GetOrdersByName;

namespace Order.Application.Extensions
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQuery<DataServiceMessage>, GetOrdersQuery>();
            services.AddScoped<IQueryHandler<GetOrdersQuery, DataServiceMessage>, GetOrdersQueryHandler>();

            services.AddScoped<ICommand, UpdateOrderCommand>();
            services.AddScoped<ICommand, DeleteOrderCommand>();

            services.AddScoped<ICommandHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteOrderCommand>, DeleteOrderCommandHandler>();

            return services;
        }
    }
}
