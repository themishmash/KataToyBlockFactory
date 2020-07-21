using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> _totalToyBlockOrders = new List<Order>();
        private int _count;

        public Order CreateOrder(string name, string address, string date, string redSquare, string blueSquare, string yellowSquare)
        {
            var order = new Order(name, address, date, redSquare, blueSquare, yellowSquare) {OrderNumber = CreateOrderNumber()};
            _totalToyBlockOrders.Add(order);
            return order;
        }

        private int CreateOrderNumber()
        {
            _count++;
            return _count;
        }
        
        public int GetTotalOrders()
        {
            return _totalToyBlockOrders.Count;
        }

        public PaintingReport CreatePaintingReport(Order order)
        {
            return new PaintingReport(order);
        }
    }
}