using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
        private static Dictionary<Shape, int> _shapesCount;

        private CuttingReport(Dictionary<Shape, int> shapesCount)
        {
            _shapesCount = shapesCount;
        }

        internal static CuttingReport CreateCuttingReport(Order order) //make this internal as factory method. wont' test this. need to use toyblock fac for unit test. make painting use public and cutting use internal. 
        {
            _shapesCount = new Dictionary<Shape, int>();
            foreach (var shape in GetAvailableShapes())
            {
                _shapesCount.Add(shape, order.CountShape(shape));
            }
            return new CuttingReport(_shapesCount);
        }

        internal static CuttingReport CreateCuttingReportTotalOrders(IEnumerable<Order> orders)
        {
            _shapesCount = new Dictionary<Shape, int>();
            foreach (var shape in GetAvailableShapes())
            {
                _shapesCount.Add(shape, GetSumOfShapes(shape, orders));
            }
            return new CuttingReport(_shapesCount);
        }
        
        public static int GetShapeCount(Shape shape)
        {
            return _shapesCount.GetValueOrDefault(shape, 0);
        }

        private static int GetSumOfShapes(Shape shape, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountShape(shape));
        }

        private static IEnumerable<Shape> GetAvailableShapes()
        {
            return Enum.GetValues(typeof(Shape)).Cast<Shape>().ToList();
        }

    }
}