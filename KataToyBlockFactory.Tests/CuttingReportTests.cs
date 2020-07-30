using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class CuttingReportTests
    {
        private readonly ToyBlockFactory _toyBlockFactory;

        public CuttingReportTests ()
        {
            var toyBlockFactory = new ToyBlockFactory();
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
            //Act
            var cuttingReportForOrder1 = _toyBlockFactory.GetCuttingReport(1);
            
            //assert
            Assert.Equal(2, cuttingReportForOrder1.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Daily_Total()
        {

            var cuttingReportForDailyTotal = _toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(3, cuttingReportForDailyTotal.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Default_Count_Set_To_Zero()
        {
            var cuttingReport = _toyBlockFactory.GetCuttingReport(1);
            
            Assert.Equal(0, cuttingReport.GetShapeCount(Shape.Triangle));
        }
        
        [Fact]
        public void Shapes_Not_Cut_In_Daily_Total()
        {
            var cuttingReport = _toyBlockFactory.GetDailyCuttingReport();
            
            //assert
            Assert.Equal(0, cuttingReport.GetShapeCount(Shape.Triangle));
        }

    }
}