using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public static class PriceCalculator
    {
        private static readonly Dictionary<Shape, int> ShapePrices = new Dictionary<Shape, int>
        {
            {Shape.Square, 1},
            {Shape.Triangle, 2},
            {Shape.Circle, 3}
        };
        
        private static readonly Dictionary<Color, int> ColorPrices = new Dictionary<Color, int>()
        {
            {Color.Red, 1},
            {Color.Blue, 0},
            {Color.Yellow, 0}
        };

        public static int GetShapePrice(Dictionary<Shape, int> shapeCounts)
        {
            var totalShapePrice = 0;
            foreach (var (shape, count) in shapeCounts)
            {
                totalShapePrice += count * ShapePrices.GetValueOrDefault(shape, 0);
            }
            
            return totalShapePrice;
        }
        
        public static int GetColorPrice(Dictionary<Color, int> colorCounts)
        {
            var totalColorPrice = 0;
            foreach (var (color, count) in colorCounts)
            {
                totalColorPrice += count * ColorPrices.GetValueOrDefault(color, 0);

            }
            return totalColorPrice;
        }
    }
}