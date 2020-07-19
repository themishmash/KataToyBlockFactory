using System.Collections.Generic;
using System.Net.NetworkInformation;
using Xunit;
namespace KataToyBlockFactory
{
    public class Order
    {
        public string Name { get; }
        public OrderStatus OrderStatus { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public int OrderNumber { get; set; }

        public Order(string name, string address, string date, int orderNumber, OrderStatus orderStatus = OrderStatus.New)
        {
            Name = name;
            Address = address;
            Date = date;
            OrderNumber = orderNumber;
            OrderStatus = orderStatus;
        }

        
    }
}