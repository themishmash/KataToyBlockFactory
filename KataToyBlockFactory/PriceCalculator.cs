using System;

namespace KataToyBlockFactory
{
    public static class PriceCalculator
    {
        
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