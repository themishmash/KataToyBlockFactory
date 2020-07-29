using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class PaintingReport
    {
        
        private static Dictionary<Block, int> _blocksCount;

        private PaintingReport(Dictionary<Block, int> blocksCount)
        {
            _blocksCount = blocksCount;
        }

        public static PaintingReport CreatePaintingReport(Order order)
        {
            _blocksCount = new Dictionary<Block, int>();
            foreach (var shape in GetAvailableShapes())
            foreach (var color in GetAvailableColors())
            {
                _blocksCount.Add(new Block(shape, color), order.CountShapeAndColor(shape, color));
            }
            return new PaintingReport(_blocksCount);
        }
        
        public static PaintingReport CreatePaintingReportTotalOrders(IEnumerable<Order> orders)
        {
            _blocksCount = new Dictionary<Block, int>();
            foreach (var shape in GetAvailableShapes())
            foreach (var color in GetAvailableColors())
            {
                _blocksCount.Add(new Block(shape, color), GetSumOfShapeColors(shape, color, orders));
            }
            return new PaintingReport(_blocksCount);
        }
        
        public static int GetShapeColorCount(Shape shape, Color color)
        {
            var foundKey = _blocksCount.Keys.FirstOrDefault(x => x.Shape == shape && x.Color == color);
            return _blocksCount.GetValueOrDefault(foundKey, 0);
        }
        
        private static IEnumerable<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }
        
        private static IEnumerable<Color> GetAvailableColors()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }

        private static int GetSumOfShapeColors(Shape shape, Color color, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountShapeAndColor(shape, color));
        }

        
    }
    
}