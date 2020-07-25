using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
        private readonly List<Order> _orders;

        public CuttingReport(List<Order> orders)
        {
            _orders = orders;
        }

        public int GetShape(Shape shape)
        {
            return _orders.Sum(order => order.CountShape(shape));
        }

    }
}