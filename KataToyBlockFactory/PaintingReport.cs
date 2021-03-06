using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class PaintingReport
    {
        private readonly Dictionary<Block, int> _blocksCount = new Dictionary<Block, int>();

        private PaintingReport(IList<Order> orders, IList<Shape> shapes, IList<Color> colors)
        {
            foreach (var shape in shapes)
            {
                foreach (var color in colors)
                {
                    {
                        _blocksCount.Add(new Block(shape, color), GetSumOfShapeColors(shape, color, orders));
                    }
                }
            }
        }

        internal static PaintingReport CreatePaintingReport(Order order, IList<Shape> shapes, IList<Color> 
        colors)
        {
            return CreatePaintingReportTotalOrders(new List<Order>{order}, shapes, colors);
        }
        
        internal static PaintingReport CreatePaintingReportTotalOrders(IList<Order> orders, IList<Shape> 
        shapes, IList<Color> colors)
        {
            return new PaintingReport(orders, shapes, colors);
        }
        
        public int GetShapeColorTotal(Shape shape, Color color)
        {
            var foundKey = _blocksCount.Keys.FirstOrDefault(x => x.Shape == shape && x.Color == color);
            return _blocksCount.GetValueOrDefault(foundKey, 0);
        }

        private static int GetSumOfShapeColors(Shape shape, Color color, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountShapeAndColor(shape, color));
        }
    }
}