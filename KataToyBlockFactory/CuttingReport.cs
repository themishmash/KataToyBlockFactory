using System;
using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class CuttingReport
    {
       private readonly Dictionary<Shape, int> _shapesCount = new Dictionary<Shape, int>();

        private CuttingReport(IEnumerable<Order> orders, IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                _shapesCount.Add(shape, GetSumOfShapes(shape, orders));
            }
        }

        internal static CuttingReport CreateCuttingReport(Order order, IEnumerable<Shape> shapes) 
        {
            return new CuttingReport(new List<Order>{order}, shapes);
        }

        internal static CuttingReport CreateCuttingReportTotalOrders(IEnumerable<Order> orders, IEnumerable<Shape> 
        shapes)
        {
            return new CuttingReport(orders, shapes);
        }
        
        public int GetShapeCount(Shape shape)
        {
            return _shapesCount[shape];
            return _shapesCount.GetValueOrDefault(shape, 0);
        }

        private static int GetSumOfShapes(Shape shape, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountShape(shape));
        }
        
    }
}