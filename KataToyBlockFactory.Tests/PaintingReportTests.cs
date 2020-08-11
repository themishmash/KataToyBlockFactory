using KataToyBlockFactory;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class PaintingReportTests
    {
        private readonly KataToyBlockFactory.ToyBlockFactory _toyBlockFactory;

        public PaintingReportTests()
        {
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(new NullInputOutput());
            var order = toyBlockFactory.CreateOrder("", "");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Red);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);
           _toyBlockFactory = toyBlockFactory;
        }
        
        [Fact]
        public void Total_Is_Based_On_Order_Number()
        {
            var paintingReport = _toyBlockFactory.GetPaintingReport(1);
            Assert.Equal(1, paintingReport.GetShapeColorTotal(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Daily_Total()
        {
            var paintingReport = _toyBlockFactory.GetDailyPaintingReport();
            Assert.Equal(2, paintingReport.GetShapeColorTotal(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void No_Painted_Blocks()
        {
           var order = _toyBlockFactory.CreateOrder("", "");
           var paintingReport = _toyBlockFactory.GetPaintingReport(order.OrderNumber);
            
           Assert.Equal(0, paintingReport.GetShapeColorTotal(Shape.Circle, Color.Blue));
        }
        
        [Fact]
        public void No_Painted_Blocks_In_Daily_Total()
        { 
            var order =_toyBlockFactory.CreateOrder("", "");
            var paintingReport = _toyBlockFactory.GetPaintingReport(order.OrderNumber);
            
            Assert.Equal(0, paintingReport.GetShapeColorTotal(Shape.Circle, Color.Blue));
        }
    }
}