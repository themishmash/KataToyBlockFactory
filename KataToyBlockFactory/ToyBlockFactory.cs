using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> orders = new List<Order>();
        public int GetTotalOrders()
        {
            return orders.Count;
        }
    }
}