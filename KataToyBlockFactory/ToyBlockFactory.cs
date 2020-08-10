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
                var orderNumber = _iio.AskBlockQuantity($"Please input the number of {key.Color} {key.Shape}s: ");
                _order[key] = orderNumber;
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
            var orderStatus = OrderHasBlocks() ? OrderStatus.Processed : OrderStatus.None;
            order.OrderStatus = orderStatus;
        }
        
        private bool OrderHasBlocks()
        {
            var sumOfValue = 0;
            foreach (var (key, value) in _order)
            {
                sumOfValue += value;
            }
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
            return _orders.Any(order => order.OrderNumber == orderNumber) ? order.OrderStatus : OrderStatus.None;
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

        private static IList<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }

        private static IList<Color> GetAvailableColors()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }


        public void PrintCuttingReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            Console.WriteLine("Your cutting list has been generated:");
            Console.WriteLine(
                $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order Number: {order.OrderNumber}");
            Console.WriteLine($"|{"",10}|{" Qty ",4}|");
            Console.WriteLine($"|{"----------",10}|{"-----",4}|");

            var cuttingReport = GetCuttingReport(orderNumber);
            foreach (var shape in GetAvailableShapes())
            {
                Console.WriteLine($"|{shape,10}|{cuttingReport.GetShapeCount(shape),5}|");
            }
        }

        public void PrintPaintingReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            Console.WriteLine("Your painting report has been generated:");
            Console.WriteLine(
                $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order Number: {order.OrderNumber}");

            var paintingReport = GetPaintingReport(orderNumber);

            // foreach (var color in GetAvailableColors())
            // {
            //     Console.Write($"|{"",10}|{color}");
            // }

           // DataTable table = new DataTable();
            //
            // table.Columns.Add("      ");
            // foreach (var color in GetAvailableColors())
            // {
            //     table.Columns.Add($"{color}", typeof(int));
            // }
            //
            // foreach (var shape in GetAvailableShapes())
            // {
            //     table.Rows.Add($"{shape}");
            // }


           

        }
    }
}