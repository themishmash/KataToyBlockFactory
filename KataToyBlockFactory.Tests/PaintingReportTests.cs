using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class PaintingReportTests
    {
        [Fact]
        public void Return_Total_Based_On_Order()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("", "");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Blue);

            var paintingReport = toyBlockFactory.GetPaintingReport(1);

            Assert.Equal(2, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Return_Daily_Total()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("", "");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Blue);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Circle, Color.Blue);

            var paintingReport = toyBlockFactory.GetDailyPaintingReport();

            Assert.Equal(3, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Default_Count_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("", "");

            var paintingReport = toyBlockFactory.GetPaintingReport(1);
            
            Assert.Equal(0, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }
    }
}