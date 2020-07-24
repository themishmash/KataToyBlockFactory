using System;
using System.Linq;
using KataToyBlockFactory;
using Xunit;

namespace KataToyBlockFactory.Tests
{
    //These tests are intended a happy path flow through the entire application
    public class AcceptanceTests
    {
        [Fact]
        public void GetNumberOfBlocksToBePainted()
        {
            // var order = new Order("James", "123 Smith Street, Fitzroy");
            // var paintingReport = new PaintingReport();
            // var cuttingReport = new CuttingReport();
            // var priceCalculator = new PriceCalculator();
            // var toyBlockFactory = new ToyBlockFactory(order, paintingReport, cuttingReport, priceCalculator);
            //
            // Assert.Equal(1, toyBlockFactory.GetNumberOfBlocksToBePainted());
        }

        [Fact]
        public void GetTotalOrders()
        {
            // var toyBlockFactory = new KataToyBlockFactory.ToyBlockFactory();
            // Assert.Equal(1, toyBlockFactory.GetTotalOrders());
        }
        
        [Fact]
        public void PlacingAnOrder()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
            Assert.Equal(DateTime.Today.AddDays(7), order.DueDate.Date);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(1, order.CountShape(Shape.Circle));
            Assert.Equal(1, order.CountColor(Color.Red));

            Assert.Equal(OrderStatus.New, toyBlockFactory.GetOrderStatus(1));
            Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void CreateCuttingReport()
        {
            //Arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);
        
            var cuttingReport = toyBlockFactory.GetCuttingReport();
            
            Assert.Equal(2, cuttingReport.GetShape(Shape.Triangle));
            Assert.Equal(2, cuttingReport.GetShape(Shape.Triangle));
            Assert.Equal(1, cuttingReport.GetShape(Shape.Circle));
            
        }

        [Fact]
        public void CreatePaintingReport()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            
            var order2 = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Blue);
            order2.AddBlock(Shape.Triangle, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Yellow);
            order2.AddBlock(Shape.Square, Color.Red);

            var paintingReport = toyBlockFactory.GetPaintingReport();
            
            //Assert.Equal(2, paintingReport.GetBlockShapeAndColor(Shape.Square, Color.Red));
            Assert.Equal(2, paintingReport.GetBlockShapeAndColor(Shape.Triangle, Color.Blue));
        }

        // [Fact]
        // public void Experiment()
        // {
        //     var toyBlockFactory = new ToyBlockFactory();
        //     var cuttingReport = toyBlockFactory.GetCuttingReport();
        //     foreach (Shape shape in toyBlockFactory.GetAvailableShapes())
        //     {
        //         cuttingReport.GetShape(shape);
        //     }
        //    
        //     
        // }

       //ordernumbertest - in toyblock factory
       //due date test - in order class
       //order status - toyblock factory
    }
}