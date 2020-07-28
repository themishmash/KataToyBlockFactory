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
           var order = new Order(name, address){OrderNumber = CreateOrderNumber(), OrderStatus = OrderStatus.New};
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
            return _orders.Any(order => order.OrderNumber == orderNumber) ? OrderStatus.New : OrderStatus.None;
        }
        
        public InvoiceReport GetInvoiceReport()
        {
            var invoiceReport = new InvoiceReport();
            foreach (var order in _orders)
            {
                invoiceReport.GetPrice(order);
            }
            return invoiceReport;
        }

        public void GetCuttingReport(Order order)
        {
            CuttingReport.CreateCuttingReport(order);
        }
        
        public void GetDailyCuttingReport()
        {
            CuttingReport.CreateCuttingReportTotalOrders(_orders);
        }
        
        public void GetPaintingReport(Order order)
        {
            PaintingReport.CreatePaintingReport(order);
        }

        private static IEnumerable<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }

        private static IEnumerable<Color> GetAvailableColors()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }
        
        // public PaintingReport GetPaintingReport()
        // {
        //     var paintingReport = new PaintingReport(_orders);
        //     foreach (var shape in GetAvailableShapes())
        //     {
        //         foreach (var color in GetAvailableColors())
        //         {
        //             paintingReport.GetBlockShapeAndColor(shape, color);
        //         }
        //     }
        //     return paintingReport;
        // }



        
    }
}