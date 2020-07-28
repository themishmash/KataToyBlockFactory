using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class CuttingReportTests
    {
        [Fact]
        public void Return_Shape_Total_Based_On_Order_Number()
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
           
        
            toyBlockFactory.GetCuttingReport(1);
            Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle)); //this does it for all shapes!
            Assert.Equal(2, CuttingReport.GetShapeCount(Shape.Square));
            Assert.Equal(2, CuttingReport.GetShapeCount(Shape.Triangle));

            toyBlockFactory.GetCuttingReport(2);
            Assert.Equal(2, CuttingReport.GetShapeCount(Shape.Circle));
            //Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Default_Shape_Count_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            toyBlockFactory.GetCuttingReport(1);
            
            Assert.Equal(0, CuttingReport.GetShapeCount(Shape.Circle));
        }
    }
}