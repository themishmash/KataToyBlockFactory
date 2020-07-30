using System.Collections.Generic;
using System.Linq;

namespace KataToyBlockFactory
{
    public class InvoiceReport
    {
        private readonly Dictionary<Shape, int> _shapesCount = new Dictionary<Shape, int>();
        private readonly Dictionary<Color, int> _colorsCount = new Dictionary<Color, int>();
        private InvoiceReport(IEnumerable<Order> orders, IEnumerable<Shape> shapes, IEnumerable<Color> colors)
        {
            foreach (var shape in shapes)
            {
               _shapesCount.Add(shape, GetSumOfShapes(shape, orders));
            }

            foreach (var color in colors)
            {
                _colorsCount.Add(color, GetSumOfColors(color, orders));
            }
        }

        internal static InvoiceReport CreateInvoiceReport(Order order, IEnumerable<Shape> shapes, IEnumerable<Color>
            colors)
        {
            return new InvoiceReport(new List<Order>{order}, shapes, colors );
        }

        public int GetCostTotal()
        {
            return PriceCalculator.GetShapePrice(_shapesCount) + PriceCalculator.GetColorPrice(_colorsCount);
        }

        //todo this one below is repeated from cutting report...
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