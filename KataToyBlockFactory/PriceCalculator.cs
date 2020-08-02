using System.Collections.Generic;

namespace KataToyBlockFactory
{
    public static class PriceCalculator
    {
        private static readonly Dictionary<Shape, int> _shapePrices = new Dictionary<Shape, int>
        {
            {Shape.Square, 1},
            {Shape.Triangle, 2},
            {Shape.Circle, 3}
        };
        
        private static readonly Dictionary<Color, int> _colorPrices = new Dictionary<Color, int>()
        {
            {Color.Red, 1}
        };

        public static int GetShapePrice(Dictionary<Shape, int> shapesCount)
        {
            var totalShapePrice = 0;
            foreach (var (key, value) in _shapePrices)
            {
                var shapeCount = shapesCount[key];
                totalShapePrice += shapeCount * value;
            }
            return totalShapePrice;
        }
        
        public static int GetColorPrice(Dictionary<Color, int> colorsCount)
        {
            var totalColorPrice = 0;
            foreach (var (key, value) in _colorPrices)
            {
                var colorCount = colorsCount[key];
                totalColorPrice += colorCount * value;
            }
            return totalColorPrice;
        }
    }
}