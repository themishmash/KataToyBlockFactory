using System;

namespace KataToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the Toy Block Factory.");
            var consoleInputOutput = new ConsoleInputOutput();
           var toyBlockFactory = new ToyBlockFactory(consoleInputOutput);
           toyBlockFactory.StartOrder();

           Console.WriteLine("What would you like to do now?");
           Console.WriteLine("1. Create a new order.");
           Console.WriteLine("2. Create a cutting report.");
           Console.WriteLine("3. Create a painting report.");
           Console.WriteLine("4. Create an invoice.");

           var selection = int.Parse(Console.ReadLine());
           switch (selection)
           {
               case 1:
                   toyBlockFactory.StartOrder();
                   break;
               case 2:
               {
                   Console.WriteLine("Please input the order number you'd like to see the cutting report for: ");
                   var orderNumber = int.Parse(Console.ReadLine());
                   PrintCuttingReport(toyBlockFactory, orderNumber);
                   break;
               }
               case 3:
               {
                   Console.WriteLine("Please input the order number you'd like to see the painting report for: ");
                   var orderNumber = int.Parse(Console.ReadLine());
                   PrintPaintingReport(toyBlockFactory, orderNumber);
                   break;
               }
               case 4:
               {
                   Console.WriteLine("Please input the order number you'd like to see the invoice report for: ");
                   var orderNumber = int.Parse(Console.ReadLine());
                   PrintInvoiceReport(toyBlockFactory,orderNumber);
                   break;
               }
           }
        }

        private static void PrintCuttingReport(ToyBlockFactory toyBlockFactory, int orderNumber)
        {
            var order = toyBlockFactory.GetOrder(orderNumber);
            Console.WriteLine("Your cutting list has been generated:");
            Console.WriteLine(
                $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order Number: {order.OrderNumber}");
            Console.WriteLine($"|{"",10}|{" Qty ",4}|");
            Console.WriteLine($"|{"----------",10}|{"-----",4}|");

            var cuttingReport = toyBlockFactory.GetCuttingReport(orderNumber);
            foreach (var shape in ToyBlockFactory.GetAvailableShapes())
            {
                Console.Write($"|{shape,10}|");

                if (cuttingReport.GetShapeCount(shape) > 0)
                {
                    Console.Write($"{cuttingReport.GetShapeCount(shape),5}|");
                }
                else if (cuttingReport.GetShapeCount(shape) == 0)
                {
                    Console.Write($"{"-", 4} |");
                }
                Console.WriteLine("");
            }
        }
        
        private static void PrintPaintingReport(ToyBlockFactory toyBlockFactory, int orderNumber)
        {
            var order = toyBlockFactory.GetOrder(orderNumber);
            Console.WriteLine("Your painting report has been generated:");
            Console.WriteLine(
                $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order Number: {order.OrderNumber}");
        
            var paintingReport = toyBlockFactory.GetPaintingReport(orderNumber);
            Console.Write($"|{"          ",10}|");
            
            foreach (var color in ToyBlockFactory.GetAvailableColors())
            {
                Console.Write($"{color,6} |");
            }
            
            Console.WriteLine("");
            Console.Write($"|{"----------",10}|");
            foreach (var color in ToyBlockFactory.GetAvailableColors())
            {
                Console.Write($"{"-----",6} |");
            }
        
            Console.WriteLine("");
        
            foreach (var shape in ToyBlockFactory.GetAvailableShapes())
            {
                Console.Write($"|{shape,10}|");
                
                foreach (var color in ToyBlockFactory.GetAvailableColors())
                {
                    if (paintingReport.GetShapeColorCount(shape, color) > 0)
                    {
                        Console.Write($"{paintingReport.GetShapeColorCount(shape, color), 6} |");
                    }
                    else if (paintingReport.GetShapeColorCount(shape, color) == 0)
                    {
                        Console.Write($"{"-", 6} |");
                    }
                }
                Console.WriteLine("");
            }
        }
        
        private static void PrintInvoiceReport(ToyBlockFactory toyBlockFactory, int orderNumber)
        {
            var order = toyBlockFactory.GetOrder(orderNumber);
            Console.WriteLine("Your invoice report has been generated:");
            Console.WriteLine(
                $"Name: {order.Name} Address: {order.Address} Due Date: {order.DueDate} Order Number: {order.OrderNumber}");
        
            var invoiceReport = toyBlockFactory.GetInvoiceReport(orderNumber);
            
            PrintPaintingReport(toyBlockFactory,orderNumber);
            
            Console.WriteLine("");
            
            foreach (var shape in ToyBlockFactory.GetAvailableShapes())
            {
                Console.WriteLine($"{shape, 13}s            {order.CountShape(shape), 3} @${PriceCalculator.ShapePrices[shape], 3} ppi = ${order.CountShape(shape) * PriceCalculator.ShapePrices[shape], 2}");
            }
        
            foreach (var color in ToyBlockFactory.GetAvailableColors())
            {
                if (PriceCalculator.ColorPrices[color] > 0)
                {
                    Console.WriteLine($"{color, 4} color surcharge      {order.CountColor(color), 3} @${PriceCalculator.ColorPrices[color], 3} ppi = ${order.CountColor(color)*PriceCalculator.ColorPrices[color], 2}");
                }
            }
            Console.WriteLine($"Total : ${invoiceReport.GetCostTotal(), 3}");
        }
        
    }
}