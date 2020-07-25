using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public static class Calculator
    {
        //private readonly List<Order> _orders;
        //
        // public InvoiceReport(List<Order> orders)
        // {
        //     _orders = orders;
        // }

        // private readonly List<Order> _orders;
        //
        // public InvoiceReport(List<Order> orders)
        // {
        //     _orders = orders;
        // }
        // public int GetOrder()
        // {
        //     throw new System.NotImplementedException();
        //order.PriceCalculator?
        // }
      

        public static int GetPrice(Order order)
        {
            var total = 0;
           
                foreach (var block in order.GetBlock())
                {
                    if (block.Color == Color.Red)
                    {
                        total += 1;
                    }

                    switch (block.Shape)
                    {
                        case Shape.Square:
                            total += 1;
                            break;
                        case Shape.Triangle:
                            total += 2;
                            break;
                        case Shape.Circle:
                            total += 3;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                
            return total;
        }
    }
}