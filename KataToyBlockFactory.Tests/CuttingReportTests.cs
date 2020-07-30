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
        public void Return_Total_Based_On_Order_Number()
        {
            //Act
            var cuttingReportForOrder1 = _toyBlockFactory.GetCuttingReport(1);
            
            //assert
            Assert.Equal(2, cuttingReportForOrder1.GetShapeCount(Shape.Circle));
        }

        

        [Fact]
        public void Shapes_Not_Cut_In_Daily_Total()
        {
            //arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Red);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);

            //Act
            var cuttingReport = toyBlockFactory.GetDailyCuttingReport();
            
            //assert
            Assert.Equal(0, cuttingReport.GetShapeCount(Shape.Triangle));
        }

        [Fact]
        public void Daily_Total()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Red);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);

            var cuttingReport = toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(3, cuttingReport.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Default_Count_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Circle, Color.Red);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);

            var cuttingReport = toyBlockFactory.GetCuttingReport(1);
            
            Assert.Equal(0, cuttingReport.GetShapeCount(Shape.Triangle));
        }
        
        //todo repeat above test for daily cutting report. 
        
    }
}