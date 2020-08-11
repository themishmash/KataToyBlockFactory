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
                   toyBlockFactory.PrintCuttingReport(orderNumber);
                   break;
               }
               case 3:
               {
                   Console.WriteLine("Please input the order number you'd like to see the painting report for: ");
                   var orderNumber = int.Parse(Console.ReadLine());
                   toyBlockFactory.PrintPaintingReport(orderNumber);
                   break;
               }
               case 4:
               {
                   Console.WriteLine("Please input the order number you'd like to see the invoice report for: ");
                   var orderNumber = int.Parse(Console.ReadLine());
                   toyBlockFactory.PrintInvoiceReport(orderNumber);
                   break;
               }
           }

        }
    }
}