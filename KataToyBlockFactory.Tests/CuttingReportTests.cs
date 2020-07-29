using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class CuttingReportTests
    {
        [Fact]
        public void Return_Total_Based_On_Order_Number()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Blue);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);
            order2.AddBlock(Shape.Circle, Color.Blue);

            var cuttingReport = toyBlockFactory.GetCuttingReport(1);
            Assert.Equal(1, cuttingReport.GetShapeCount(Shape.Circle)); 
            Assert.Equal(2, cuttingReport.GetShapeCount(Shape.Square));
            Assert.Equal(2, cuttingReport.GetShapeCount(Shape.Triangle));

            var cuttingReport1 = toyBlockFactory.GetCuttingReport(2);
            Assert.Equal(2, cuttingReport1.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Return_Daily_Total()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Blue);

            var order2 = toyBlockFactory.CreateOrder("", "");
            order2.AddBlock(Shape.Circle, Color.Blue);
            order2.AddBlock(Shape.Circle, Color.Blue);

            var cuttingReport = toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(3, cuttingReport.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Default_Count_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            var cuttingReport = toyBlockFactory.GetCuttingReport(1);
            
            Assert.Equal(0, cuttingReport.GetShapeCount(Shape.Circle));
        }
    }
}