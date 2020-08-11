using KataToyBlockFactory;
using Xunit;

namespace ToyBlockFactory.Tests
{
    public class CuttingReportTests
    {
        private readonly KataToyBlockFactory.ToyBlockFactory _toyBlockFactory;

        public CuttingReportTests ()
        {
            var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory(new NullInputOutput());
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Red);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);
            _toyBlockFactory = toyBlockFactory ;
        }
        
        [Fact]
        public void Total_Number_Of_Shapes_Is_Based_On_Order_Number()
        {
            var cuttingReportForOrder1 = _toyBlockFactory.GetCuttingReport(1);
            Assert.Equal(2, cuttingReportForOrder1.GetShapeTotal(Shape.Circle));
        }

        [Fact]
        public void Daily_Total()
        {
            var cuttingReportForDailyTotal = _toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(3, cuttingReportForDailyTotal.GetShapeTotal(Shape.Circle));
        }

        [Fact]
        public void No_Shapes_Cut()
        {
            var cuttingReport = _toyBlockFactory.GetCuttingReport(1);
            Assert.Equal(0, cuttingReport.GetShapeTotal(Shape.Triangle));
        }
        
        [Fact]
        public void Shapes_Not_Cut_In_Daily_Total()
        {
            var cuttingReport = _toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(0, cuttingReport.GetShapeTotal(Shape.Triangle));
        }

    }
}