using System;

namespace KataToyBlockFactory
{
    public static class PriceCalculator
    {
        
        public static int GetCost(Block block)
        {
            var blockPrice = 0;
            if (block.Color == Color.Red)
            {
                blockPrice += block.Price = 1;
            }

            switch (block.Shape)
            {
                case Shape.Square:
                    blockPrice += block.Price = 1;
                    break;
                case Shape.Triangle:
                    blockPrice += block.Price = 2;
                    break;
                case Shape.Circle:
                    blockPrice += block.Price = 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return blockPrice;
        }
    }
}