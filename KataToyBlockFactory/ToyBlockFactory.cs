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

        private static IEnumerable<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }
        
        private static IEnumerable<Color> GetAvailableColors()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }

       
    }
}