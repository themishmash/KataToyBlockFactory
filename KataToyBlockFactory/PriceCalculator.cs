using System;

namespace KataToyBlockFactory
{
    public class PriceCalculator
    {
        
        public int GetCost(Block block)
        {
            var blockPrice = 0;
            if (block.Color == Color.Red)
            {
                blockPrice += 1;
            }

            switch (block.Shape)
            {
                case Shape.Square:
                    blockPrice += 1;
                    break;
                case Shape.Triangle:
                    blockPrice += 2;
                    break;
                case Shape.Circle:
                    blockPrice += 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return blockPrice;
        }
    }
}