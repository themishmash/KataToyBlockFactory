using System.Collections.Generic;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class PaintingReportTests
    {
        [Fact]
        public void Return_Total_Based_On_Order()
        {
            var order = new Order("", "");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Blue);

            PaintingReport.CreatePaintingReport(order);

            Assert.Equal(2, PaintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Return_Daily_Total()
        {
            var order = new Order("", "");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Blue);
            
            var order2 = new Order("", "");
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Circle, Color.Blue);
            
            PaintingReport.CreatePaintingReportTotalOrders(new List<Order>() {order, order2});
            
            Assert.Equal(3, PaintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Default_Count_Set_To_Zero()
        {
            var order = new Order("", "");

            PaintingReport.CreatePaintingReport(order);
            
            Assert.Equal(0, PaintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }
    }
}