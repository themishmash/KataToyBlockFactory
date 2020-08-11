using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
       private readonly Dictionary<Shape, int> _shapesCount = new Dictionary<Shape, int>();

        private CuttingReport(IList<Order> orders, IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                _shapesCount.Add(shape, orders.Sum(order => order.CountShape(shape)));
            }
        }

        internal static CuttingReport CreateCuttingReport(Order order, IEnumerable<Shape> shapes) 
        {
            return CreateCuttingReportTotalOrders(new List<Order>{order}, shapes);
        }

        internal static CuttingReport CreateCuttingReportTotalOrders(IList<Order> orders, IEnumerable<Shape> 
        shapes)
        {
            return new CuttingReport(orders, shapes);
        }
        
        public int GetShapeCount(Shape shape)
        {
            return _shapesCount.GetValueOrDefault(shape, 0);
        }
    }
}