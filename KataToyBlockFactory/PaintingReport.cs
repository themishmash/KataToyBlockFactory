using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class PaintingReport
    {
        private readonly List<Order> _orders;

        public PaintingReport(List<Order> orders)
        {
            _orders = orders;
        }

        public int GetBlockShapeAndColor(Shape shape, Color color)
        {
            return _orders.Sum(order => order.CountShapeAndColor(shape, color));
        }
    }
}