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

        public CuttingReport GetCuttingReport(int orderNumber) //todo why is this void???
        {
            var order = GetOrder(orderNumber);
            return CuttingReport.CreateCuttingReport(order);
        }
        
        public CuttingReport GetDailyCuttingReport()
        {
            return CuttingReport.CreateCuttingReportTotalOrders(_orders);
        }
        
        public PaintingReport GetPaintingReport(int orderNumber)
        {
            var order = GetOrder(orderNumber);
            return PaintingReport.CreatePaintingReport(order);
        }

        public PaintingReport GetDailyPaintingReport()
        {
            return PaintingReport.CreatePaintingReportTotalOrders(_orders);
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

    }
}