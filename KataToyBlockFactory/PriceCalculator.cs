using System;
using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public static class PriceCalculator
    {
        public static int GetShapePrice(Dictionary<Shape, int> shapesCount)
        {
            var totalShapePrice = 0;
            foreach (var (key, value) in shapesCount)
            {
                switch (key)
                {
                    case Shape.Square:
                        totalShapePrice += 1 * value;
                        break;
                    case Shape.Triangle:
                        totalShapePrice += 2 * value;
                        break;
                    case Shape.Circle:
                        totalShapePrice += 3 * value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return totalShapePrice;
        }
        

        public static int GetColorPrice(Dictionary<Color, int> colorsCount)
        {
            var totalColorPrice = 0;
            foreach (var colorCount in colorsCount)
            {
                if (colorCount.Key == Color.Red)
                {
                    totalColorPrice += 1 * colorCount.Value;
                }
            }
            return totalColorPrice;
        }
    }

   
}