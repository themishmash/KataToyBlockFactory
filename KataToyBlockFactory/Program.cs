using System;

namespace KataToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // var consoleInputOutput = new ConsoleInputOutput();
            // var orderTaker = new OrderTaker(consoleInputOutput);
            // var order = new Order(orderTaker.GetName(), orderTaker.GetAddress(), orderTaker.GetDate(), orderTaker
            // .GetOrderNumber(), orderTaker.GetSquareOrder());
            // Console.WriteLine(order.Name);
            // Console.WriteLine(order.Address);
            // Console.WriteLine(order.Date);
            // Console.WriteLine(order.OrderNumber);
            // Console.WriteLine(order.Blocks.Count);
            
            //order1
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10 October 2020", "5", "2", "1");
            // Console.WriteLine(order.Name);
            // Console.WriteLine(order.Address);
            // Console.WriteLine(order.Date);
            Console.WriteLine(order.OrderNumber);
            // Console.WriteLine(order.TotalBlocksOrder());
            // Console.WriteLine(toyBlockFactory.GetTotalOrders());
            
            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy", "10 October 2020", "5", "2", "1");
            // Console.WriteLine(order2.Name);
            // Console.WriteLine(order2.Address);
            // Console.WriteLine(order2.Date);
            Console.WriteLine(order2.OrderNumber);
            // Console.WriteLine(order2.TotalBlocksOrder());
            // Console.WriteLine(toyBlockFactory.GetTotalOrders());
            //
        }
    }
}