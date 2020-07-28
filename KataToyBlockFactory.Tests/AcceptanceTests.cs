using System;
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
        public void Placing_An_Order_Will_Create_New_Order()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.DueDate = DateTime.Today;
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            Assert.Equal("James", order.Name);
            Assert.Equal("123 Smith Street, Fitzroy", order.Address);
            Assert.Equal(DateTime.Today, order.DueDate);
            Assert.Equal(1, order.OrderNumber);
            Assert.Equal(1, order.CountShape(Shape.Circle));
            Assert.Equal(1, order.CountColor(Color.Red));

            Assert.Equal(OrderStatus.New, toyBlockFactory.GetOrderStatus(1));
            Assert.Equal("James", toyBlockFactory.GetOrder(1).Name);
        }

        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Single_Order()
        {
            //Arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
        
            toyBlockFactory.GetCuttingReport(order); 
            
            Assert.Equal(2, CuttingReport.GetShapeCount(Shape.Triangle));
            Assert.Equal(4, CuttingReport.GetShapeCount(Shape.Square));
            Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle));
        }
        
        [Fact]
        public void Create_Cutting_Report_Will_Return_Number_Of_Shapes_For_Daily_Orders()
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
        
            toyBlockFactory.GetDailyCuttingReport();
            Assert.Equal(4, CuttingReport.GetShapeCount(Shape.Square));
        }
        
        //todo create test for single order cutting report and painting report
        [Fact]
        public void Create_Painting_Report_Will_Return_Number_For_Single_Order()
        {
            //Arrange
            var toyBlockFactory = new ToyBlockFactory();
            var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
            order.AddBlock(Shape.Circle, Color.Blue);
            order.AddBlock(Shape.Square, Color.Blue);
            order.AddBlock(Shape.Square, Color.Red);
            order.AddBlock(Shape.Triangle, Color.Blue);
            order.AddBlock(Shape.Triangle, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Yellow);
            order.AddBlock(Shape.Square, Color.Red);
            
            toyBlockFactory.GetPaintingReport(order);
            
            Assert.Equal(1, PaintingReport.GetShapeColorCount(Shape.Triangle, Color.Yellow));
            Assert.Equal(2, PaintingReport.GetShapeColorCount(Shape.Square, Color.Red));
            Assert.Equal(1, PaintingReport.GetShapeColorCount(Shape.Square, Color.Blue));
            //Assert.Equal(1, CuttingReport.GetShapeCount(Shape.Circle));
        }

        [Fact]
        public void Create_Painting_Report_Will_Return_Number_Of_Shapes_And_Number_Of_Colors()
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

           // var paintingReport = toyBlockFactory.GetPaintingReport();
            
            // Assert.Equal(2, paintingReport.GetBlockShapeAndColor(Shape.Square, Color.Red));
            // Assert.Equal(2, paintingReport.GetBlockShapeAndColor(Shape.Triangle, Color.Blue));
            // Assert.Equal(1, paintingReport.GetBlockShapeAndColor(Shape.Square, Color.Yellow));
        }
        
       
       //todo acceptance test for price/invoice stuff
       [Fact]
       public void Create_Invoice_Report_Will_Return_Price_Of_Order()
       {
           var toyBlockFactory = new ToyBlockFactory();
           var order = toyBlockFactory.CreateOrder("James", "123 Smith Street, Fitzroy");
           order.AddBlock(Shape.Circle, Color.Blue);
           order.AddBlock(Shape.Square, Color.Blue);
           order.AddBlock(Shape.Square, Color.Yellow);
           order.AddBlock(Shape.Triangle, Color.Red);
           
           var invoiceReport = toyBlockFactory.GetInvoiceReport();
           
           Assert.Equal(8, invoiceReport.GetPrice(order));
       }

    }
}