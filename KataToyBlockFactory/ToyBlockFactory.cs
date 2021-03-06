using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class ToyBlockFactory
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _count;
        private readonly IInputOutput _iio;
        private readonly Dictionary<Block, int> _order = new Dictionary<Block, int>();

        public ToyBlockFactory(IInputOutput iio)
        {
            _iio = iio;
            foreach (var shape in GetAvailableShapes())
            {
                foreach (var color in GetAvailableColors())
                {
                    _order.Add(new Block(shape, color), 0);
                }
            }
        }
        
        public void StartOrder()
        {
            var name = _iio.AskQuestion("Please input your Name: ");
            var address = _iio.AskQuestion("Please input your Address: ");
            var dueDate = _iio.AskDate("Please input your Due Date:");
            var order = CreateOrder(name, address);
            order.DueDate = dueDate;

            GetBlockQuantity();

            AddBlocksToOrder(order);

            AssignOrderStatus(order);
        }

        private void GetBlockQuantity()
        {
            foreach (var (key, _) in _order.ToList())
            {
                var blockQuantity = _iio.AskBlockQuantity($"Please input the number of {key.Color} {key.Shape}s: ");
                _order[key] = blockQuantity;
            }
        }

        private void AddBlocksToOrder(Order order)
        {
            foreach (var (key, value) in _order)
            {
                for (var i = 1; i <= value; i++)
                {
                    order.AddBlock(key.Shape, key.Color);
                }
            }
        }
        
        private void AssignOrderStatus(Order order)
        {
            order.OrderStatus = OrderHasBlocks() ? OrderStatus.Processed : OrderStatus.None;
        }
        
        private bool OrderHasBlocks()
        {
            var sumOfValue = _order.Cast<int>().Sum();
            return sumOfValue > 0;
        }

        public Order CreateOrder(string name, string address)
        {
            var order = new Order(name, address) {OrderNumber = CreateOrderNumber(), OrderStatus = OrderStatus.New};
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

        public OrderStatus GetOrderStatus(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            return _orders.Any(x => x.OrderNumber == orderNumber) ? order.OrderStatus : OrderStatus.None;
        }

        public CuttingReport GetCuttingReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            return CuttingReport.CreateCuttingReport(order, GetAvailableShapes());
        }


        public CuttingReport GetDailyCuttingReport()
        {
            return CuttingReport.CreateCuttingReportTotalOrders(_orders, GetAvailableShapes());
        }

        public PaintingReport GetPaintingReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            return PaintingReport.CreatePaintingReport(order, GetAvailableShapes(), GetAvailableColors());
        }

        public PaintingReport GetDailyPaintingReport()
        {
            return PaintingReport.CreatePaintingReportTotalOrders(_orders, GetAvailableShapes(), GetAvailableColors());
        }

        public InvoiceReport GetInvoiceReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            return InvoiceReport.CreateInvoiceReport(order, GetAvailableShapes(), GetAvailableColors());
        }

        public InvoiceReport GetDailyInvoiceReport()
        {
            return InvoiceReport.CreateInvoiceReportTotalOrders(_orders, GetAvailableShapes(), GetAvailableColors());
        }

        public static IList<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }

        public static IList<Color> GetAvailableColors()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }
        
    }
}