using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> orders = new List<Order>();

        public Order CreateOrder(string name, string address, string date, string blueSquare)
        {
            var order = new Order(name, address, date, blueSquare);
            orders.Add(order);
            return order;
        }
        
        public int GetTotalOrders()
        {
            return orders.Count;
        }
    }
}