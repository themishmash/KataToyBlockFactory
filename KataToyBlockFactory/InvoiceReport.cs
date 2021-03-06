using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class InvoiceReport
    {
        private readonly Dictionary<Shape, int> _shapesCount = new Dictionary<Shape, int>();
        private readonly Dictionary<Color, int> _colorsCount = new Dictionary<Color, int>();
        
        private InvoiceReport(IList<Order> orders, IList<Shape> shapes, IList<Color> colors)
        {
            foreach (var shape in shapes) _shapesCount.Add(shape, GetSumOfShapes(shape, orders));

            foreach (var color in colors)
            {
                _colorsCount.Add(color, GetSumOfColors(color, orders));
            }
        }

        internal static InvoiceReport CreateInvoiceReport(Order order, IList<Shape> shapes, IList<Color>
            colors)
        {
            return CreateInvoiceReportTotalOrders(new List<Order>{order}, shapes, colors );
        }
        
        internal static InvoiceReport CreateInvoiceReportTotalOrders(IList<Order> orders, IList<Shape> shapes, 
        IList<Color> colors)
        {
           return new InvoiceReport(orders, shapes, colors);
        }

        public int GetCostTotal()
        {
            return PriceCalculator.GetShapePrice(_shapesCount) + PriceCalculator.GetColorPrice(_colorsCount);
        }
        
        private static int GetSumOfShapes(Shape shape, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountShape(shape));
        }
        
        private static int GetSumOfColors(Color color, IEnumerable<Order> orders)
        {
            return orders.Sum(order => order.CountColor(color));
        }

      
    }
}