using Xunit;

namespace KataToyBlockFactory.Tests
{
    public class CuttingReportTests
    {
        [Fact]
        public void Count_Totals_For_Different_Shapes()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            toyBlockFactory.GetCuttingReport(order);
            Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle));
            Assert.Equal(4, CuttingReport.GetShapeCount(Shape.Square));
        }

        [Fact]
        public void Default_Shape_Count_Set_To_Zero()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            toyBlockFactory.GetCuttingReport(order);
            
            Assert.Equal(0, CuttingReport.GetShapeCount(Shape.Circle));
        }
    }
}