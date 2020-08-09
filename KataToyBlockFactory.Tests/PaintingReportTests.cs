using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class PaintingReportTests
    {
        private readonly ToyBlockFactory _toyBlockFactory;

        public PaintingReportTests()
        {
            var toyBlockFactory = new ToyBlockFactory(new NullInputOutput());
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
            Assert.Equal(1, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void Daily_Total()
        {
            var paintingReport = _toyBlockFactory.GetDailyPaintingReport();
            Assert.Equal(2, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }

        [Fact]
        public void No_Painted_Blocks()
        {
         
            _toyBlockFactory.CreateOrder("", "");

            var paintingReport = _toyBlockFactory.GetPaintingReport(1);
            
            Assert.Equal(0, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }
        
        [Fact]
        public void No_Painted_Blocks_In_Daily_Total()
        {
            _toyBlockFactory.CreateOrder("", "");

            var paintingReport = _toyBlockFactory.GetPaintingReport(1);
            
            Assert.Equal(0, paintingReport.GetShapeColorCount(Shape.Circle, Color.Blue));
        }
    }
}