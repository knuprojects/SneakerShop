namespace Order.Domain.Const
{
    public static class Routes
    {
        public const string GetOrdersByLogin = "/orders/{login}";
        public const string UpdateOrder = "/orders";
        public const string DeleteOrder = "/orders/{orderId}";
    }
}
