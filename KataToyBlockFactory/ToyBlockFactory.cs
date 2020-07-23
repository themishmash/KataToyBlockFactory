using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
       
        private readonly List<Order> _orders = new List<Order>();
        private int _count;
        
        public Order CreateOrder(string name, string address)
        {
           var order = new Order(name, address){OrderNumber = CreateOrderNumber()};
           _orders.Add(order);
           return order;
        }
        
        public Order GetOrder(int orderNumber)
        {
            return _orders.FirstOrDefault(order => order.OrderNumber == orderNumber);
        }

        private int CreateOrderNumber()
        {
            _count++;
            return _count;
        }
        
        
       

        public IEnumerable<Shape> GetAvailableShapes()
        {
            throw new NotImplementedException();
        }

        public OrderStatus GetOrderStatus(int i)
        {
            throw new NotImplementedException();
        }

        public CuttingReport GetCuttingReport()
        {
            throw new NotImplementedException();
        }
    }
}